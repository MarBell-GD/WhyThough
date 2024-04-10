using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTransition : MonoBehaviour
{

    Vector3 init;
    Vector3 dest;

    /*
     * Start/End Pos: 1937, 0, 0
     * In Pos: 0, 0, 0
     * End Pos: -1955, 0, 0
     */

    [HideInInspector] public PlayerMovement movement;
    RectTransform uiPos;

    // Start is called before the first frame update
    void Start()
    {
        
        movement = FindObjectOfType<PlayerMovement>();
        uiPos = GetComponent<RectTransform>();

        init = new Vector3(1937, 0, 0);
        dest = new Vector3(-1955, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (movement.isMoving && movement.currentPos == new Vector2(movement.movePos.x, movement.movePos.z)) 
        {

            uiPos.LeanMoveLocal(dest, 0.75f);

        }

    }

    public void CurtainsClose()
    {

        uiPos.LeanMoveLocal(init, 0f);
        uiPos.LeanMoveLocal(Vector3.zero, 0.5f);
        Debug.Log("curtains close...");

    }

}
