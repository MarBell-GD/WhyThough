using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    [HideInInspector] public int hp;
    [HideInInspector] public bool gameOver;
    PlayerUIManager uimanage;

    public TMPro.TextMeshProUGUI deathdesc;

    // Start is called before the first frame update
    void Start()
    {

        hp = 3;
        gameOver = false;
        uimanage = FindObjectOfType<PlayerUIManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0 && !gameOver) //Automatically get a bad end once you run out of hp
            BadEnd(null);

        if(gameOver)
        {

            //uhhh I forgor why I put this...ah well

        }

    }

    public void BadEnd(string howithappen)
    {

        #region Filler Descriptions

        //A bunch of filler death descriptions for dying by running out of hp
        if (howithappen == null || howithappen == "")
        {

            int fillerDesc = Random.Range(0, 10);

            switch(fillerDesc)
            {

                case 0:
                    howithappen = "Truly unfortunate Little Red, but I know you can get up.";
                    break;

                case 1:
                    howithappen = "Listen, don't fret Red. We can try this again.";
                    break;

                case 2:
                    howithappen = "We're accepting this Red? Of course not, you're stubborn after all.";
                    break;

                case 3:
                    howithappen = "Wake up, you're not a heavy sleeper now...";
                    break;

                case 4:
                    howithappen = "I know you love the world, Red. Wake up and keep exploring.";
                    break;

                case 5:
                    howithappen = "Not yet Red. There's still more pages after this one.";
                    break;

                case 6:
                    howithappen = "You're right, that wasn't the right ending. Let's start from the top.";
                    break;

                case 7:
                    howithappen = "Hm, it can't end like that. Here, let's write a new chapter.";
                    break;

                case 8:
                    howithappen = "Don't worry Red, I still have more stories to tell you. Stay awake now...";
                    break;

                case 9:
                    howithappen = "Yeah, let's take that pencil and write a new one.";
                    break;

                case 10:
                    howithappen = "Don't worry Little Red, I got another tale for you.";
                    break;

            }

        }

        #endregion

        gameOver = true;
        deathdesc.text = howithappen;

        uimanage.GameEnd();
        Debug.Log("It's all over.");  // :(      

    }

}
