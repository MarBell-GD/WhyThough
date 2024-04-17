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

    public GameObject status;
    public GameObject emoNeutral;
    public GameObject emoRage;
    public GameObject emoLazy;
    public GameObject emoFear;

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

    Vector3 statusOrigin;
    Vector3 statusOffscr;

    //Gameplay-affecting stuff
    [HideInInspector] public bool isDialouge;
    [HideInInspector] public bool isStatus;
    [HideInInspector] public bool cantMove; //Used to be only for dialouge - if true, player cannot move

    //Other
    [HideInInspector] PlayerEmotions emotions;

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

        statusOrigin = new Vector3(-750, 0, 0);
        statusOffscr = new Vector3(-1750, 0, 0);

        emotions = FindObjectOfType<PlayerEmotions>();

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

        //...character development happened, there is now update code. celebration will commence shortly...

        switch(emotions.playerEmotion)
        {

            case (PlayerEmotions.Emotion.Neutral):
                emoNeutral.SetActive(true);
                emoRage.SetActive(false);
                emoLazy.SetActive(false);
                emoFear.SetActive(false);
                break;

            case (PlayerEmotions.Emotion.Rage):
                emoNeutral.SetActive(false);
                emoRage.SetActive(true);
                emoLazy.SetActive(false);
                emoFear.SetActive(false);
                break;

            case (PlayerEmotions.Emotion.Laziness):
                emoNeutral.SetActive(false);
                emoRage.SetActive(false);
                emoLazy.SetActive(true);
                emoFear.SetActive(false);
                break;

            case (PlayerEmotions.Emotion.Fear):
                emoNeutral.SetActive(false);
                emoRage.SetActive(false);
                emoLazy.SetActive(false);
                emoFear.SetActive(true);
                break;

        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && !isDialouge)
        {

            if (!isStatus)
                StatusAppear();
            else
                StatusDisappear();

        }

    }

    #endregion

    #region Screen Dim
    public void DimScreen() //Dim the player view (Used for certain UI for clarity)
    {

        screenDim.SetActive(true);

    }

    public void undimScreen() //Self-explanatory lol
    {

        screenDim.SetActive(false);

    }

    #endregion

    #region Examine and Map UI

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

    #endregion

    #region Dialouge UI

    public void CallDialougeUI() //Move the dialouge UI onto the screen
    {

        dialougeBox.GetComponent<RectTransform>().LeanMoveLocal(dialougeOnscr, 0.5f);
        isDialouge = true;
        cantMove = true;

    }

    public void ReturnDialougeUI() //Return the dialouge UI offscreen
    {

        dialougeBox.GetComponent<RectTransform>().LeanMoveLocal(dialougeOrigin, 0.5f);
        isDialouge = false;
        cantMove = false;

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

    public void instLeft() //Reposition the dialouge name box to the left, but instant
    {

        dialougeName.GetComponent<RectTransform>().LeanMoveLocal(nameLeft, 0f);

    }

    public void instMiddle() //Reposition the dialouge name box to the middle, but instant
    {

        dialougeName.GetComponent<RectTransform>().LeanMoveLocal(nameMiddle, 0f);

    }

    public void instRight() //Reposition the dialouge name box to the right, but instant
    {

        dialougeName.GetComponent<RectTransform>().LeanMoveLocal(nameRight, 0f);

    }

    #endregion

    #region Status

    public void StatusAppear()
    {

        DimScreen();
        PutAwayUI();

        status.GetComponent<RectTransform>().LeanMoveLocal(statusOrigin, 0.25f);
        isStatus = true;
        cantMove = true;

    }

    public void StatusDisappear()
    {

        undimScreen();
        ReturnUI();

        status.GetComponent<RectTransform>().LeanMoveLocal(statusOffscr, 0.25f);
        isStatus = false;
        cantMove = false;

    }

    #endregion

}
