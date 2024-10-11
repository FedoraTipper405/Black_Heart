using UnityEngine;

public class DoorBlocker : MonoBehaviour
{
    private void Start()
    {
        // Hide the visual part of the GameObject while keeping the collider active
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Disable the visual representation in-game
        }
    }
}