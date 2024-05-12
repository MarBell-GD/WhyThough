using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{

    PlayerUIManager uimanage;

    [Header("Init")]
    public Queue<DialougeEntry> DialogueSentences;

    public TMPro.TextMeshProUGUI NameText;
    public TMPro.TextMeshProUGUI DialogueText;

    public float TypeTime; //Might make it so dialouge entires can change this, I dunno, will def speed it up tho
    public Dialouge.dialogConsequence aftermath;

    PlayerEmotions.Emotion targetEmotion;
    float emotionChange;
    bool subtract;

    Item givenItem;

    [Header("Choice-related")]
    public ChoiceButton c1button;
    public TMPro.TextMeshProUGUI c1Text;

    public ChoiceButton c2button;
    public TMPro.TextMeshProUGUI c2Text;

    public ChoiceButton c3button;
    public TMPro.TextMeshProUGUI c3Text;

    [Header("Other UI Stuff")]
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    // Start is called before the first frame update
    void Start()
    {
        
        uimanage = FindObjectOfType<PlayerUIManager>();
        DialogueSentences = new Queue<DialougeEntry>();

    }

    #region more free Update() code (GONE WRONG // SHOCKED EMOJI FACE)

    // Update is called once per frame
    void Update()
    {
        //okay there was update code this time lol, but not much

        if (Input.GetKeyDown(KeyCode.Space) && uimanage.choiceMade)
            DisplayNextEntry();

        //https://open.spotify.com/track/6bzpQS64UHCXnq19HDOnK7?si=0366336ffbbd413c

    }

    #endregion

    public void StartDialouge(Dialouge dialouge)
    {

        Debug.Log("Oh? Someone wants to talk.");
        uimanage.DialougeMoment();
        DialogueSentences.Clear();

        foreach (DialougeEntry entry in dialouge.dialouges)
        {

            DialogueSentences.Enqueue(entry);

        }

        aftermath = dialouge.consequence;

        if(aftermath == Dialouge.dialogConsequence.ChangeEmotion || aftermath == Dialouge.dialogConsequence.Both)
        {

            targetEmotion = dialouge.targetEmotion;
            emotionChange = dialouge.emotionChange;
            subtract = dialouge.subtract;

        }

        if (aftermath == Dialouge.dialogConsequence.GiveItem || aftermath == Dialouge.dialogConsequence.Both)
        {

            givenItem = dialouge.givenItem;

        }

        DisplayFirstEntry();

    }

    public void DisplayFirstEntry()
    {

        DialougeEntry entry = DialogueSentences.Dequeue();
        InstantDialougeInit(entry);
        StopAllCoroutines();
        StartCoroutine(TypingDialouge(entry.text));

        if (entry.char1present)
        {

            char1.GetComponent<RectTransform>().LeanMoveLocalY(-90f, 0.5f);
            char1.GetComponent<Image>().sprite = entry.char1;

        }
        else
        {

            char1.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.75f);

        }

        if (entry.char2present)
        {

            char2.GetComponent<RectTransform>().LeanMoveLocalY(-90f, 0.5f);
            char2.GetComponent<Image>().sprite = entry.char2;

        }
        else
        {

            char2.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.75f);

        }

        if (entry.char3present)
        {

            char3.GetComponent<RectTransform>().LeanMoveLocalY(-90f, 0.5f);
            char3.GetComponent<Image>().sprite = entry.char3;

        }
        else
        {

            char3.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.75f);

        }

    }

    public void DisplayNextEntry()
    {

        if(DialogueSentences.Count == 0)
        {

            switch (aftermath)
            {

                case (Dialouge.dialogConsequence.None):
                    //getting freaky on a friday night yeah :D
                    break;

                case (Dialouge.dialogConsequence.ChangeEmotion):
                    PlayerEmotions emotions = FindObjectOfType<PlayerEmotions>();
                    emotions.EmotionAdjust(targetEmotion, emotionChange, subtract);
                    break;

                case (Dialouge.dialogConsequence.GiveItem):
                    //me when the
                    break;

                case (Dialouge.dialogConsequence.Both):
                    PlayerEmotions emotionz = FindObjectOfType<PlayerEmotions>();
                    emotionz.EmotionAdjust(targetEmotion, emotionChange, subtract);
                    break;

            }

            EndDialouge();
            return;

        }

        DialougeEntry entry = DialogueSentences.Dequeue();
        DialougeInit(entry);
        StopAllCoroutines();
        StartCoroutine(TypingDialouge(entry.text));

        if(entry.type == DialougeEntry.dialougeType.Choice)
        {

            c1button.choice = entry.c1;

            if(entry.c2 != null)
                c2button.choice = entry.c2;

            if (entry.c3 != null)
                c3button.choice = entry.c3;

            c1Text.text = c1button.choice.ChoiceText;

            if (c2button.choice == null)
                c2Text.text = "...";
            else
                c2Text.text = c2button.choice.ChoiceText;

            if (c3button.choice == null)
                c3Text.text = "...";
            else
                c3Text.text = c3button.choice.ChoiceText;

            c1button.gameObject.SetActive(true);
            c2button.gameObject.SetActive(true);
            c3button.gameObject.SetActive(true);

            if(entry.choiceNum == 2)
                c3button.gameObject.SetActive(false);
            else if(entry.choiceNum == 1)
            {

                c2button.gameObject.SetActive(false);
                c3button.gameObject.SetActive(false);

            }

            uimanage.ChoicesAppear();

        }

        if (entry.char1present)
        {

            char1.GetComponent<RectTransform>().LeanMoveLocalY(-90f, 0.5f);
            char1.GetComponent<Image>().sprite = entry.char1;

        }
        else
        {

            char1.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.75f);

        }

        if (entry.char2present)
        {

            char2.GetComponent<RectTransform>().LeanMoveLocalY(-90f, 0.5f);
            char2.GetComponent<Image>().sprite = entry.char2;

        }
        else
        {

            char2.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.75f);

        }

        if (entry.char3present)
        {

            char3.GetComponent<RectTransform>().LeanMoveLocalY(-90f, 0.5f);
            char3.GetComponent<Image>().sprite = entry.char3;

        }
        else
        {

            char3.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.75f);

        }

    }

    IEnumerator TypingDialouge(string sentence)
    {

        DialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {

            DialogueText.text += letter;
            yield return new WaitForSeconds(TypeTime);

        }

    }

    //Happens before the *first* dialouge entry after dialouge is initiated starts typing
    //Makes it so the name box is already in position before the UI appears
    void InstantDialougeInit(DialougeEntry entry)
    {

        NameText.text = entry.Name;
        NameText.color = entry.nameColor;

        switch (entry.side)
        {

            case (DialougeEntry.nameSide.Left):
                uimanage.instLeft();
                break;

            case (DialougeEntry.nameSide.Middle):
                uimanage.instMiddle();
                break;

            case (DialougeEntry.nameSide.Right):
                uimanage.instRight();
                break;

        }

    }

    //Happens before the dialouge entry starts typing
    void DialougeInit(DialougeEntry entry)
    {

        NameText.text = entry.Name;
        NameText.color = entry.nameColor;

        switch(entry.side) 
        {

            case (DialougeEntry.nameSide.Left):
                uimanage.switchLeft();
                break;

            case (DialougeEntry.nameSide.Middle):
                uimanage.switchMiddle();
                break;

            case (DialougeEntry.nameSide.Right):
                uimanage.switchRight();
                break;

        }

    }

    void EndDialouge()
    {

        char1.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.4f);
        char2.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.4f);
        char3.GetComponent<RectTransform>().LeanMoveLocalY(-1090f, 0.4f);

        Debug.Log("Alright, we're done here...");
        uimanage.DialougeFinished();

    }

}
