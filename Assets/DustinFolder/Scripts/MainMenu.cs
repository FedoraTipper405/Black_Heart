using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private string startSceneName = "GameScene";

    private PlayerInput playerInput;
    private InputAction clickAction;

    private void Awake()
    {
        // Assign button click events
        startButton.onClick.AddListener(OnStartButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        // Set up PlayerInput and Input Actions for mouse or pointer interactions
        playerInput = GetComponent<PlayerInput>();
        clickAction = playerInput.actions["Click"];

        clickAction.performed += OnClickPerformed;
    }

    private void OnDestroy()
    {
        // Unsubscribe from click action to prevent memory leaks
        clickAction.performed -= OnClickPerformed;
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        // Check which button was clicked
        Vector2 mousePosition = Pointer.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == startButton.transform)
            {
                OnStartButtonClicked();
            }
            else if (hit.transform == quitButton.transform)
            {
                OnQuitButtonClicked();
            }
        }
    }

    private void OnStartButtonClicked()
    {
        // Load the start scene
        SceneManager.LoadScene(startSceneName);
    }

    private void OnQuitButtonClicked()
    {
        // Quit the application
        Application.Quit();
    }
 }