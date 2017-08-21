using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBoxController : MonoBehaviour {

    public Text text;
    public Inventory PlayerInventory;

    // Use this for initialization
    void Start()
    {
        text.text = "DEFAULT_INVENTORY_BOX_CONTROLLER_TEXT";
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//StateManager.Updated) //TODO Change to a Publisher-Subscriber (Observer) method
        {
            text.text = "Inventory\n---------\n";
            text.text += PlayerInventory.Contents;
        }
    }
}
