using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class State
{
    private string Description;
    private Dictionary<KeyCode, State> CommandTable;
    private Dictionary<KeyCode, string> ActionTable;

    public State(string Description)
    {
        this.Description = Description;
        CommandTable = new Dictionary<KeyCode, State>();
        ActionTable = new Dictionary<KeyCode, string>();
    }


    public void SetCommand(KeyCode key, State state, string action)
    {
        CommandTable[key] = state;
        ActionTable[key] = action;
    }

    public State GetNextState(KeyCode key)
    {
        if (CommandTable.ContainsKey(key))
        {
            return CommandTable[key];
        }
        return null;
    }

    public string GetString()
    {
        string rval = "";
        rval += Description;
        rval += "\n\n[";
        foreach (KeyCode key in CommandTable.Keys)
        {
            rval += key.ToString() + ": " + ActionTable[key];
            rval += ", ";
        }
        rval = rval.Substring(0, rval.Length - 2);
        rval += "]";
        return rval;
    }
}

public class TextContoller : MonoBehaviour {

    public Text text;
    private State CurrentState;
    private bool UpdateText;

	// Use this for initialization
	void Start () {
        const string Cell_Text = "You wake up locked in a prison cell, you see a Mirror, some dirty Sheets, and a Locked set of bars.";
        const string Sheets_Text = "These sheets look like they haven't been cleaned in months...";
        const string Mirror_Text = "You look up at the dusty mirror, you reason you could Take it off the wall if you pry hard enough.";
        const string Lock_Text = "Luckily you never travel without a hairpin, unluckily the face of the lock is on the other side of the bars.";
        const string Freedom_Text = "You've made it out of your cell!";
        State cell = new State(Cell_Text);
        State sheets_0 = new State(Sheets_Text);
        State sheets_1 = new State(Sheets_Text);
        State mirror = new State(Mirror_Text);
        State lock_0 = new State(Lock_Text);
        State lock_1 = new State(Lock_Text);
        State cell_mirror = new State(Cell_Text);
        State freedom = new State(Freedom_Text);
        text.text = "Hello World";

        cell.SetCommand(KeyCode.S, sheets_0, "Look at the Sheets");
        cell.SetCommand(KeyCode.M, mirror, "Look at the Mirror");
        cell.SetCommand(KeyCode.L, lock_0, "Look at the Lock");
        sheets_0.SetCommand(KeyCode.R, cell, "Return to your Cell");
        lock_0.SetCommand(KeyCode.R, cell, "Return to your Cell");
        mirror.SetCommand(KeyCode.R, cell, "Return to your Cell");
        mirror.SetCommand(KeyCode.T, cell_mirror, "Take the Mirror and return to your cell");
        cell_mirror.SetCommand(KeyCode.S, sheets_1, "Look at the Sheets");
        cell_mirror.SetCommand(KeyCode.L, lock_1, "Look at the Lock");
        sheets_1.SetCommand(KeyCode.R, cell_mirror, "Return to your cell");
        lock_1.SetCommand(KeyCode.R, cell_mirror, "Return to your cell");
        lock_1.SetCommand(KeyCode.O, freedom, "Open the lock with the Mirror");
        freedom.SetCommand(KeyCode.P, cell, "Play again");

        CurrentState = cell;
        UpdateText = true;
        text.text = "Hello World1";

    }

    // Update is called once per frame
    void Update () {
        if (UpdateText)
        {
            text.text = "Hello World";
            text.text = CurrentState.GetString();
        }
        if (Input.anyKey)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    print(kcode);
                    State Next = CurrentState.GetNextState(kcode);
                    if (Next != null)
                    {
                        CurrentState = CurrentState.GetNextState(kcode);
                        UpdateText = true;
                    }
                }
            }
        }
	}
}
