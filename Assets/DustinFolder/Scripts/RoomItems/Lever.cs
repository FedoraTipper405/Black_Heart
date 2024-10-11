using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Reflection;

public class Lever : MonoBehaviour
{
    [System.Serializable]
    public class TargetItem
    {
        public MonoBehaviour targetScript; // The specific script to target
        public string methodName; // Name of the method to call on the target object
    }

    [SerializeField] private List<TargetItem> targetItems = new List<TargetItem>(); // List of items to control
    [SerializeField] private bool isOn = false; // State of the lever

    private bool playerInRange = false; // Track if the player is in range

    private void Update()
    {
        // Handle input from the new Input System
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleLever();
        }
    }

    private void ToggleLever()
    {
        isOn = !isOn;
        Debug.Log("Lever state: " + (isOn ? "On" : "Off"));
        SendOutputToTargets();
    }

    private void SendOutputToTargets()
    {
        foreach (TargetItem targetItem in targetItems)
        {
            if (targetItem.targetScript != null)
            {
                Debug.Log("Lever " + gameObject.name + " is trying to target: " + targetItem.targetScript.name);
                MethodInfo methodInfo = targetItem.targetScript.GetType().GetMethod(targetItem.methodName);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(targetItem.targetScript, new object[] { isOn });
                }
                else
                {
                    Debug.LogWarning("Method " + targetItem.methodName + " not found on " + targetItem.targetScript.name);
                }
            }
            else
            {
                Debug.LogWarning("Target script is not assigned.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player out of range");
        }
    }
}