using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    // - Hub of UI-related calls -

    #region Variables

    //Basic vars
    public GameObject examineButton;
    public GameObject mapButton;

    public GameObject screenDim;

    public GameObject dialougeBox;
    public GameObject dialougeName;

    //Vectors
    Vector3 examineOffscr;
    Vector3 examineOrigin;

    Vector3 mapOrigin;
    Vector3 mapOffscr;

    Vector3 dialougeOrigin;
    Vector3 dialougeOnscr;

    Vector3 nameLeft;
    Vector3 nameRight;
    Vector3 nameMiddle;

    //Gameplay-affecting stuff
    [HideInInspector] public bool isDialouge; //If dialouge is initiated, player cannot move

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        screenDim.SetActive(false);

        examineOrigin = new Vector3(-390f, -450f, 0);
        mapOrigin = new Vector3(390f, -450f, 0);
        dialougeOrigin = new Vector3(0, -800f, 0);

        examineOffscr = new Vector3(-390f, -850f, 0);
        mapOffscr = new Vector3(390f, -850f, 0);
        dialougeOnscr = new Vector3(0, -350f, 0);

        nameLeft = new Vector3(-475f, 145f, 0);
        nameRight = new Vector3(475f, 145f, 0);
        nameMiddle = new Vector3(0, 145f, 0);

    }

    #region open this for free Update() code (NO SCAM NO CLICKBAIT)

    // Update is called once per frame
    void Update()
    {

        //YOU FOOL
        //YOU LOOKED AT UPDATE() EXPECTING SOME KIND OF CODE
        //I HAVE FINALLY TRAPPED YOU...

        //NOW...

        //I WILL GET YOU...

        //TO LISTEN TO...

        //...

        //https://open.spotify.com/album/1164QDi9CiftjLg0ecvooW?si=AWGgNSpYT4q62_08uQKVtQ

    }

    #endregion

    public void DimScreen() //Dim the player view (Used for certain UI for clarity)
    {

        screenDim.SetActive(true);

    }

    public void undimScreen() //Self-explanatory lol
    {

        screenDim.SetActive(false);

    }

    public void PutAwayUI() //Make the Examine and Map buttons go offscreen
    {

        examineButton.GetComponent<RectTransform>().LeanMoveLocal(examineOffscr, 0.25f);
        mapButton.GetComponent<RectTransform>().LeanMoveLocal(mapOffscr, 0.25f);

    }

    public void ReturnUI() //Return the main two UI buttons onto the screen
    {

        examineButton.GetComponent<RectTransform>().LeanMoveLocal(examineOrigin, 0.25f);
        mapButton.GetComponent<RectTransform>().LeanMoveLocal(mapOrigin, 0.25f);

    }

    public void CallDialougeUI() //Move the dialouge UI onto the screen
    {

        dialougeBox.GetComponent<RectTransform>().LeanMoveLocal(dialougeOnscr, 0.5f);
        isDialouge = true;

    }

    public void ReturnDialougeUI() //Return the dialouge UI offscreen
    {

        dialougeBox.GetComponent<RectTransform>().LeanMoveLocal(dialougeOrigin, 0.5f);
        isDialouge = false;

    }

    public void DialougeMoment() //Does all three things for dialouge UI
    {

        DimScreen();
        PutAwayUI();
        CallDialougeUI();

    }

    public void DialougeFinished() //Same as DialougeMoment, opposite purpose
    {

        undimScreen();
        ReturnUI();
        ReturnDialougeUI();

    }

    public void switchLeft() //Reposition the dialouge name box to the left
    {

        dialougeName.GetComponent<RectTransform>().LeanMoveLocal(nameLeft, 0.25f);

    }

    public void switchMiddle() //Reposition the dialouge name box to the middle
    {

        dialougeName.GetComponent<RectTransform>().LeanMoveLocal(nameMiddle, 0.15f);

    }

    public void switchRight() //Reposition the dialouge name box to the right
    {

        dialougeName.GetComponent<RectTransform>().LeanMoveLocal(nameRight, 0.15f);

    }

}
