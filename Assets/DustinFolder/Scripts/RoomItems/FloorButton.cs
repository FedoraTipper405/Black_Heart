using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // Object to trigger when the button is pressed
    [SerializeField] private string methodName = "SetPower"; // Method to call on the target object
    [SerializeField] private bool isPressed = false; // Whether the button is currently pressed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MoveableObject"))
        {
            if (!isPressed)
            {
                isPressed = true;
                TriggerTarget(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MovableObject"))
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
            bool stillPressed = false;
            foreach (Collider2D col in colliders)
            {
                if (col.CompareTag("Player") || col.CompareTag("MovableObject"))
                {
                    stillPressed = true;
                    break;
                }
            }

            if (!stillPressed)
            {
                isPressed = false;
                TriggerTarget(false);
            }
        }
    }

    private void TriggerTarget(bool powerState)
    {
        if (targetObject != null)
        {
            targetObject.SendMessage(methodName, powerState, SendMessageOptions.DontRequireReceiver);
        }
    }
}