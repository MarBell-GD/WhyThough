using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{

    PlayerUIManager uimanage;
    private Queue<DialougeEntry> DialogueSentences;

    public TMPro.TextMeshProUGUI NameText;
    public TMPro.TextMeshProUGUI DialogueText;

    public float TypeTime;

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

        if (Input.GetKeyDown(KeyCode.Space))
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

        DisplayFirstEntry();

    }

    public void DisplayFirstEntry()
    {

        DialougeEntry entry = DialogueSentences.Dequeue();
        InstantDialougeInit(entry);
        StopAllCoroutines();
        StartCoroutine(TypingDialouge(entry.text));

    }

    public void DisplayNextEntry()
    {

        if(DialogueSentences.Count == 0)
        {

            EndDialouge();
            return;

        }

        DialougeEntry entry = DialogueSentences.Dequeue();
        DialougeInit(entry);
        StopAllCoroutines();
        StartCoroutine(TypingDialouge(entry.text));

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

    void InstantDialougeInit(DialougeEntry entry) //Happens before the dialouge starts typing, to setup things like the name box
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

    void DialougeInit(DialougeEntry entry) //Happens before the dialouge starts typing, to setup things like the name box
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

        Debug.Log("Alright, we're done here...");
        uimanage.DialougeFinished();

    }

}
