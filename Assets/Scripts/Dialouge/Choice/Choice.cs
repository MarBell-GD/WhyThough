using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{

    public string ChoiceText;
    public enum choiceConsequence
    {

        None,
        StartNewDialog,
        ChangeEmotion,
        GiveItem,
        Multiple

    }

    public choiceConsequence consequence;

    [Header("Consequence: Dialog")]
    public Dialouge newDialouge;

    [Header("Consequence: Emotion")]
    public PlayerEmotions.Emotion targetEmotion;
    public float change;
    public bool subtract;

    [Header("Consequence: Item")]
    public Item givenItem;

}
