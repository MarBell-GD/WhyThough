using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{

    public string ChoiceText;
    public enum choiceConsequence //<==== What happens directly after you make your choice
    {

        None,
        StartNewDialog,
        ChangeEmotion,
        GiveItem,
        Multiple

    }

    public choiceConsequence consequence;

    [Header("Consequence: Dialog")] //Alright, let's have...a different conversation...
    public Dialouge newDialouge;

    [Header("Consequence: Emotion")] //Self-explanatory I think
    public PlayerEmotions.Emotion targetEmotion;
    public float change;
    public bool subtract;

    [Header("Consequence: Item")]
    public Item givenItem; //As useless as Gohan in Super

}
