using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Speed of piston movement
    [SerializeField] private bool fastRetract = false; // Retract at the same speed as extend
    [SerializeField] private bool useTimer = false; // Use timer for automatic cycles
    [SerializeField] private bool startEnabled = true; // Should the piston start enabled
    [SerializeField] private float timerInterval = 3f; // Time between piston cycles
    [SerializeField] private bool toggleMode = false; // Toggle between powered/unpowered states
    [SerializeField] private Transform targetNode; // Target node for piston movement
    [SerializeField] private float stayDownTime = 1f; // Time to stay down before moving up
    [SerializeField] private float stayUpTime = 1f; // Time to stay up before moving down

    private bool isExtended = false;
    private bool isPowered = false;
    private float retractSpeed;
    private Coroutine currentCoroutine;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float nextActionTime;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector2(startPosition.x, targetNode.position.y);
        retractSpeed = fastRetract ? speed : speed / 2f;
        isPowered = startEnabled;
        nextActionTime = Time.time + timerInterval;

        if (useTimer && isPowered)
        {
            currentCoroutine = StartCoroutine(TimerRoutine());
        }
    }

    private void Update()
    {
        if (useTimer && isPowered && Time.time >= nextActionTime)
        {
            nextActionTime += timerInterval;
            if (isExtended)
            {
                RetractPiston();
            }
            else
            {
                ExtendPiston();
            }
        }
    }

    public void SetPower(bool powerState)
    {
        isPowered = powerState;

        if (toggleMode)
        {
            if (powerState && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(TimerRoutine());
            }
            else if (!powerState && currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
            }
        }
        else
        {
            if (isPowered && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(ExtendPistonWithDelay());
            }
            else if (!isPowered && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(RetractPistonWithDelay());
            }
        }
    }

    private IEnumerator ExtendPistonWithDelay()
    {
        ExtendPiston();
        yield return new WaitForSeconds(stayDownTime);
        currentCoroutine = StartCoroutine(RetractPistonWithDelay());
    }

    private IEnumerator RetractPistonWithDelay()
    {
        RetractPiston();
        yield return new WaitForSeconds(stayUpTime);
        currentCoroutine = null;
    }

    private void ExtendPiston()
    {
        isExtended = true;
        StartCoroutine(MovePiston(endPosition, speed));
    }

    private void RetractPiston()
    {
        isExtended = false;
        StartCoroutine(MovePiston(startPosition, retractSpeed));
    }

    private IEnumerator MovePiston(Vector2 targetPosition, float moveSpeed)
    {
        targetPosition = new Vector2(startPosition.x, targetPosition.y); // Only move along the vertical axis

        while (Mathf.Abs(transform.position.y - targetPosition.y) > 0.10f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
    }

    private IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timerInterval);
            if (isExtended)
            {
                RetractPiston();
            }
            else
            {
                ExtendPiston();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isExtended)
        {
            Debug.Log("Player crushed by the piston.");
            // Future code will interact with HealthManager to deduct health or kill the player
        }
    }
}