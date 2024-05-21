using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    public Map grid; //The map in question
    PlayerMovement plr; //For cross-referencing position
    public Image bg; //Examine background

    public GameObject spawnedItem;
    PlayerUIManager uimanage;

    // Start is called before the first frame update
    void Start()
    {
        
        plr = FindObjectOfType<PlayerMovement>();
        uimanage = FindObjectOfType<PlayerUIManager>();

        foreach (GridSpace space in grid.spaces)
        {

            space.wasCollected = false;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        //Player position check
        foreach(GridSpace space in grid.spaces)
        {

            if (space.pos == plr.currentPos)
            {

                bg.sprite = space.background;
                space.currentSpace = true;

                //v - For finding items in certain map spaces
                if(space.spawn != null && !space.wasCollected && uimanage.isExamining)
                {
                    
                    ItemSpawn itm = space.spawn;

                    spawnedItem.GetComponent<ItemGet>().item = itm.targetItem;
                    spawnedItem.GetComponent<RectTransform>().LeanMoveLocal(new Vector3(itm.xSpawn, itm.ySpawn, 0), 0f);
                    spawnedItem.GetComponent<Image>().sprite = itm.targetItem.Image;
                    spawnedItem.SetActive(true);
                    

                }
                
                if(space.wasCollected || space.spawn == null) //Item disappears if collected already
                    spawnedItem.SetActive(false);

            }
            else
            {

                space.currentSpace = false;

            }

        }

    }

}
