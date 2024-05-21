using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

    public Dialouge dialouge;
    public Condition condition;

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

    [Header("Alternate Condition: Emotion")]
    public PlayerEmotions.Emotion AltemotionReq;
    [Range(1, 100)] public float AltemotionThreshold;



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
