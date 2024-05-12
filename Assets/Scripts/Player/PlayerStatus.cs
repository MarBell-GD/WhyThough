using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    [HideInInspector] public int hp;
    [HideInInspector] public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {

        hp = 3;
        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0)
            BadEnd(null);

    }

    public void BadEnd(Dialouge dialouge)
    {

        if(dialouge == null)
        {

            Debug.Log("It's all over.");
            return;

        }

    }

}
