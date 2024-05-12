using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    public Map grid;
    PlayerMovement plr;
    public Image bg;

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
        
        foreach(GridSpace space in grid.spaces)
        {

            if (space.pos == plr.currentPos)
            {

                bg.sprite = space.background;
                space.currentSpace = true;

                if(space.spawn != null && !space.wasCollected && uimanage.isExamining)
                {
                    
                    ItemSpawn itm = space.spawn;

                    spawnedItem.GetComponent<ItemGet>().item = itm.targetItem;
                    spawnedItem.GetComponent<RectTransform>().LeanMoveLocal(new Vector3(itm.xSpawn, itm.ySpawn, 0), 0f);
                    spawnedItem.GetComponent<Image>().sprite = itm.targetItem.Image;
                    spawnedItem.SetActive(true);
                    

                }
                
                if(space.wasCollected || space.spawn == null)
                    spawnedItem.SetActive(false);

            }
            else
            {

                space.currentSpace = false;

            }

        }

    }

}
