using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items {
    Debug,
    None,
    Mirror
}

public class Item
{
    public Items type { get; private set; }
    public string Description { get; private set; }

    public Item(Items item, string description)
    {
        this.type = item;
        this.Description = description;
    }
}

public class Inventory : MonoBehaviour {

    private Dictionary<Items, bool> ItemHeld;
    private Dictionary<Items, Item> ItemTable;

    public bool IsHeld(Items item) { return ItemHeld[item]; }
    public void AddItem(Items item)
    {
        if (!ItemHeld[item])
        {
            ItemHeld[item] = true;
        }
        else
        {
            print("Already holding item: " + item.ToString());
        }
    }
    public void RemoveItem(Items item)
    {
        if (ItemHeld[item])
        {
            ItemHeld[item] = false;
        }
        else
        {
            print("Item not held to remove: " + item.ToString());
        }
    }

    // Use this for initialization
    void Start () {
        ItemTable = new Dictionary<Items, Item>();
        ItemTable[Items.Debug] = new Item(Items.Debug, "DEBUG_ITEM_TEXT_DESCRIPTION");
        ItemTable[Items.None] = new Item(Items.None, "NONE_ITEM_TEXT_DESCRIPTION USED FOR NOT HAVING AN ITEM SOMETHING IS WRONG");
        ItemTable[Items.Mirror] = new Item(Items.Mirror, "A fractured piece of the mirror that used to hang on your cell wall");
        ItemHeld = new Dictionary<Items, bool>();
        foreach (Items item in Enum.GetValues(typeof(Items)))
        {
            ItemHeld[item] = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {	
	}
}
