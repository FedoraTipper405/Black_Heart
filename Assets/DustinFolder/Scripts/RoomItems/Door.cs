using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f; // Distance to move when opening/closing
    [SerializeField] private float speed = 2f; // Speed of the door movement
    [SerializeField] public bool startReversed = false; // Should the door start in reverse mode (open or reversed behavior)
    [SerializeField] private Collider2D blockingCollider; // Collider to block player when door is closing
    [SerializeField] private bool useDoorBlocker = true; // Use blocking collider to block player when door is closing
    [SerializeField] private bool moveHorizontal = false; // Should the door move horizontally instead of vertically

    private Vector2 closedPosition;
    private Vector2 openPosition;
    private bool isPowered = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = moveHorizontal ? closedPosition + Vector2.right * moveDistance : closedPosition + Vector2.up * moveDistance;

        if (startReversed)
        {
            // Swap positions if starting reversed
            Vector2 temp = closedPosition;
            closedPosition = openPosition;
            openPosition = temp;
        }

        // Ensure blockingCollider is assigned in the Inspector
        if (useDoorBlocker && blockingCollider == null)
        {
            Debug.LogWarning("Blocking collider is not assigned for door: " + gameObject.name);
        }
        else if (useDoorBlocker && blockingCollider != null)
        {
            blockingCollider.enabled = !isPowered;
        }
    }

    private void Update()
    {
        // Move the door based on its powered state
        if (isPowered)
        {
            if (useDoorBlocker && blockingCollider != null)
            {
                blockingCollider.enabled = false; // Disable collider when door is opening
            }
            MoveTowards(openPosition);
        }
        else
        {
            if (useDoorBlocker && blockingCollider != null)
            {
                blockingCollider.enabled = true; // Enable collider immediately when door starts closing
            }
            MoveTowards(closedPosition);
        }
    }

    private void MoveTowards(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void SetPower(bool powerState)
    {
        isPowered = powerState;
    }
}