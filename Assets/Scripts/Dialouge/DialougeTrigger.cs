using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

    //Don't worry about the actual code here honestly, just stick this into anything that you want to have dialogue
    //Make sure the object has a collider so it can be clicked! >:0

    #region Variables

    public Dialouge dialouge;
    public Condition condition; //<== Note: if you set a condition, the script will prioritize the ALTERNATE
    //dialogue if there is any until condition is met. If there isn't any...um...it might break...probably
    //And I didn't type this because I think whoever might read this script won't get how to use it, I'm typing this
    //because I completely forgot how to use it and it costed me dumb residue code -.-

    public enum Condition
    {

        None,
        Emotion

    }

    [Header("Condition: Emotion")]
    public PlayerEmotions.Emotion emotionReq;
    [Range(1, 100)] public float emotionThreshold;

    [Header("Alternate Dialouge")]
    public bool alternate;
    public Dialouge altDialouge;
    [HideInInspector] public bool hasInteracted;

    //This below is that residue code as result of me being a dumbass. ignore it.
    [Header("Alternate Condition: Emotion")] 
    public PlayerEmotions.Emotion AltemotionReq;
    [Range(1, 100)] public float AltemotionThreshold;

    #endregion

    private void Start()
    {

        hasInteracted = false;

    }

    public void TriggerDialouge()
    {

        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
        hasInteracted = true;

    }

    public void TriggerAltDialouge()
    {

        FindObjectOfType<DialougeManager>().StartDialouge(altDialouge);

    }

}
