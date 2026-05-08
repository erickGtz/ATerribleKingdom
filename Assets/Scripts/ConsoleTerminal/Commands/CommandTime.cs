using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTime : ICommand
{
    public string CommandName => "set-time";
    public string Description => "Set the game velocity. Use: set_time [value]";

    public bool ExecuteCommand(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.LogError("Requires an argument!");
            return false;
        }

        if (!float.TryParse(args[0], out float newTimeScale))
        {
            Debug.LogError("Argument is not a valid number.");
            return false;
        }

        // We apply it immediately so you can see it in the background if you want
        Time.timeScale = newTimeScale;

        // We also tell the TerminalUI to save this new speed, so when it closes, it restores this one instead of 1f
        TerminalUI ui = GameObject.FindObjectOfType<TerminalUI>();
        if (ui != null)
        {
            ui.cachedTimeScale = newTimeScale;
        }

        return true;
    }

}
