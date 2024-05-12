using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{

    [HideInInspector] public Item item;

    PlayerInventory inventory;
    Map grid;

    private void Start()
    {
        
        inventory = FindObjectOfType<PlayerInventory>();
        grid = FindObjectOfType<GridManager>().grid;

    }

    public void AddItem()
    {

        foreach(GridSpace space in grid.spaces) 
        { 
            
            if(space.currentSpace)
            {

                space.wasCollected = true;

            }
            
        }

        Debug.Log("item collected!");
        inventory.inv.Add(item);

    }

}
