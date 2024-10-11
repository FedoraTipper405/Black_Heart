using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Speed of the piston movement
    [SerializeField] private float distance = 3f; // Distance the piston moves down
    [SerializeField] private bool fastRetract = false; // Retract at the same speed as extend
    [SerializeField] private bool useTimer = false; // Use timer for automatic cycles
    [SerializeField] private bool startEnabled = true; // Should the piston start enabled
    [SerializeField] private float timerInterval = 3f; // Time between piston cycles
    [SerializeField] private bool toggleMode = false; // Toggle between powered/unpowered states
    [SerializeField] private Piston nextPistion; // Link to the next pistion for wave effect

    private bool isExtended = false;
    private bool isPowered = false;
    private float retractSpeed;
    private Coroutine timerCoroutine;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private void Start()
    {
        
    }
}