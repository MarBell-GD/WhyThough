using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteract : MonoBehaviour
{

    //ripped from my code for games work

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        Ray interact = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(interact, out hit))
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                

            }

        }

    }
}
