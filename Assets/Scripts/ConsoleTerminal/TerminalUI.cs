using UnityEngine;
using TMPro;

public class TerminalUI : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Drag the visual console panel here (ConsolePanel)")]
    [SerializeField] private GameObject consolePanel;

    [Header("Settings")]
    [Tooltip("Key to open/close the console. BackQuote is usually the key to the left of 1 (| or ~)")]
    [SerializeField] private KeyCode toggleKey = KeyCode.BackQuote;

    private void Start()
    {
        // For safety, ensure the console is turned off when the game starts
        consolePanel.SetActive(false);
    }

    private void Update()
    {
        // Check if the user pressed the assigned toggle key
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleConsole();
        }
    }

    private void ToggleConsole()
    {
        // Toggle the current state. If off, turn it on. If on, turn it off.
        bool isActive = consolePanel.activeSelf;
        consolePanel.SetActive(!isActive);

        // Optional: Pause the game while the console is open
        if (!isActive) // If it was NOT active (meaning it just turned on)
        {
            Time.timeScale = 0f; // Pause the game
            // Here in the future we will tell the InputField to auto-select
        }
        else // If it just turned off
        {
            Time.timeScale = 1f; // Resume the game
        }
    }
}
