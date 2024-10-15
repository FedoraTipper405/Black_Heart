using UnityEngine;

public class DoorBlocker : MonoBehaviour
{
    [SerializeField] private Door door;
    
    private void Start()
    {
        // Hide the visual part of the GameObject while keeping the collider active
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Disable the visual representation in-game
        }

        // Disables the blocker if the door is set to start reversed
        if (door != null && door.startReversed)
        {
            gameObject.SetActive(false);
        }
    }
}