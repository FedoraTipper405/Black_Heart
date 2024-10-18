using Unity.VisualScripting;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private Transform[] trackNodes; // Track nodes defining the path
    [SerializeField] private float speed = 2f; // Speed of the saw blade
    [SerializeField] private float waitTime = 1f; // Time to wait at each end before reversing
    [SerializeField] private bool oscillate = true; // Should the saw blade oscillate back and forth
    [SerializeField] private bool startPoweredOn = true; // Should the saw blade start powered on

    private int currentNodeIndex = 0;
    private bool movingForward = true;
    private float waitTimer = 0f;
    private bool isPowered = true; // Indicates if the saw blade is powered

    private void Start()
    {
        isPowered = startPoweredOn;

        // Hides track nodes in-game but keep them visible in the editor
        foreach (Transform node in trackNodes)
        {
            if (node != null)
            {
                node.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (!isPowered)
        {
            // If not powered, return to the start position or stay idle based on oscillate state
            if (!oscillate && transform.position != trackNodes[0].position)
            {
                MoveTowards(trackNodes[0].position);
            }
            return;
        }

        if (trackNodes.Length < 2) return;

        // Move towards the current target node
        MoveTowards(trackNodes[currentNodeIndex].position);

        // Check if the saw blade reached the target node
        if (Vector3.Distance(transform.position, trackNodes[currentNodeIndex].position) < 0.1f)
        {
            if (waitTimer <= 0f)
            {
                waitTimer = waitTime;
                if (oscillate)
                {
                    // Reverse direction if oscillating
                    movingForward = currentNodeIndex == trackNodes.Length - 1 ? false : currentNodeIndex == 0 ? true : movingForward;
                    currentNodeIndex = movingForward ? currentNodeIndex + 1 : currentNodeIndex - 1;
                }
                else
                {
                    // Move in one direction if not oscillating
                    currentNodeIndex = Mathf.Clamp(currentNodeIndex + 1, 0, trackNodes.Length - 1);
                }
            }
            else
            {
                waitTimer -= Time.deltaTime;
            }
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Keep the z value constant for 2D
    }

    public void SetPower(bool powerState)
    {
        isPowered = powerState;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // This is where you'll add the code for the saw blade to deduct health from the player
            Debug.Log("Saw blade has collided with the player");
        }
    }
}