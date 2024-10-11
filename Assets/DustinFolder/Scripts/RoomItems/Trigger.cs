using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class Trigger : MonoBehaviour
{
    [System.Serializable]
    public class TargetItem
    {
        public MonoBehaviour targetScript; // The specific script to target
        public string methodName; // Name of the method to call on the target object
        public bool triggerOnce = false; // Should this target trigger only once
        public bool reversed = false; // Should this target act in reverse
    }

    [SerializeField] private List<TargetItem> targetItems = new List<TargetItem>(); // List of items to control

    private HashSet<MonoBehaviour> triggeredItems = new HashSet<MonoBehaviour>(); // Track triggered items

    private void Start()
    {
        // Make the object visible in the editor but hide its visual representation in the game
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Hide the SpriteRenderer during runtime
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger: " + gameObject.name);
            TriggerItems();
        }
    }

    private void TriggerItems()
    {
        foreach (TargetItem targetItem in targetItems)
        {
            if (targetItem.targetScript != null)
            {
                // Check if the item should only trigger once and if it has already been triggered
                if (targetItem.triggerOnce && triggeredItems.Contains(targetItem.targetScript))
                {
                    continue;
                }

                // Mark as triggered if the option is set
                if (targetItem.triggerOnce)
                {
                    triggeredItems.Add(targetItem.targetScript);
                }

                // Call the specified method
                bool powerState = targetItem.reversed ? false : true;
                MethodInfo methodInfo = targetItem.targetScript.GetType().GetMethod(targetItem.methodName);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(targetItem.targetScript, new object[] { powerState });
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger: " + gameObject.name);
            foreach (TargetItem targetItem in targetItems)
            {
                if (targetItem.targetScript != null && !targetItem.triggerOnce)
                {
                    // Call the specified method on exit, reversing the power state
                    bool powerState = targetItem.reversed ? true : false;
                    MethodInfo methodInfo = targetItem.targetScript.GetType().GetMethod(targetItem.methodName);
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(targetItem.targetScript, new object[] { powerState });
                    }
                    else
                    {
                        Debug.LogWarning("Method " + targetItem.methodName + " not found on " + targetItem.targetScript.name);
                    }
                }
            }
        }
    }
}