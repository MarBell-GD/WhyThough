using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    //marlon signature: stream camellia music

    public float spd; //The speed of which the player will move between spaces, configure this in the inspector not here

    //Map stuffs
    GridManager manager;
    Map grid;

    //Dw about these, but if ykyk
    [HideInInspector] public Vector2 currentPos;
    [HideInInspector] public bool isMoving;

    [HideInInspector] public Vector3 movePos;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

        //Init
        isMoving = false;
        movePos = transform.position;

        manager = FindObjectOfType<GridManager>();
        grid = manager.grid; //<== Map is extracted from GridManager

    }

    // Update is called once per frame
    void Update()
    {

        //Simple check to prevent the player inputs from affecting movement when alr moving to a space
        if (currentPos == new Vector2(movePos.x, movePos.z)) 
            isMoving = false;
        else
            isMoving = true;

        currentPos = new Vector2(transform.position.x, transform.position.z);

        //Won't elaborate on the input movement stuff because it doesn't matter if you're not me lol, just know it works
        //you get a cookie if you understand the code :v

        // Vertical/Up&Down check for open spaces to move to
        if (Input.GetKeyDown(KeyCode.W) && !isMoving || (Input.GetKeyDown(KeyCode.S) && !isMoving))
        {

            Vector2 moveTo = new Vector2(currentPos.x, currentPos.y + 10 * Input.GetAxisRaw("Vertical"));

            foreach(GridSpace space in grid.spaces)
            {

                if(space.pos == moveTo)
                {

                    movePos = new Vector3(transform.position.x, transform.position.y, moveTo.y);
                    Debug.Log("Moving to: " + movePos);

                }

            }

        }

        // Horizontal/Left&Right check for open spaces to move to
        if (Input.GetAxisRaw("Horizontal") == 1 && !isMoving || Input.GetAxisRaw("Horizontal") == -1 && !isMoving)
        {

            Vector2 moveTo = new Vector2(currentPos.x + 10 * Input.GetAxisRaw("Horizontal"), currentPos.y);

            foreach (GridSpace space in grid.spaces)
            {

                if (space.pos == moveTo)
                {

                    movePos = new Vector3(moveTo.x, transform.position.y, transform.position.z);
                    Debug.Log("Moving to: " + movePos);

                }

            }

        }

        //zzzzzzz
        transform.position = Vector3.MoveTowards(transform.position, movePos, spd * Time.deltaTime); //<==== Spd affects this

        //code finished, off to kareoke(did I even spell that right), will continue soonTM
        //horizontal movement does work btw just didn't make any horizontal spaces lol

    }

}
