using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionBoxController : MonoBehaviour {

    public Text text;
    public StateManager StateManager;

	// Use this for initialization
	void Start () {
        text.text = "DEFAULT_DESCRIPTION_CONTROLLER_TEXT";
    }

    // Update is called once per frame
    void Update () {
        if (true)//StateManager.Updated) //TODO Change to a Publisher-Subscriber (Observer) method
        {
            text.text = StateManager.CurrentState.Description;
        }
    }
}
