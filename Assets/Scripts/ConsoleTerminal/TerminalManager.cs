using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class TerminalManager : MonoBehaviour
{
    // Singleton pattern so any script can easily access the terminal manager
    public static TerminalManager Instance { get; private set; }
    public Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    private void Awake()
    {
        // Setup Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        RegisterAllCommands();
    }

    private void RegisterAllCommands()
    {
        commands.Clear();

        CommandTime timeCmd = new CommandTime();
        commands.Add(timeCmd.CommandName, timeCmd);
    }


    /// <summary>
    /// Processes the raw string received from the UI
    /// </summary>
    public void ProcessCommand(string rawInput)
    {
        // 1. Clean the input
        string input = rawInput.Trim();

        // 2. Ignore if empty
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        // For now, let's just log it to the Unity Console to prove it works!
        Debug.Log($"[Terminal] User entered: {input}");

        // TODO in Phase 3: Split the string by spaces, identify the command, and execute it.

        string[] splitArgsInput = rawInput.Split(' ');
        string commandName = splitArgsInput[0];

        if (commands.ContainsKey(commandName))
        {
            string[] cleanArgs = splitArgsInput.Skip(1).ToArray();
            commands[commandName].ExecuteCommand(cleanArgs);
        }
        else
        {
            Debug.LogError($"[Terminal] Command '{commandName}' not found.");
        }


    }
}
