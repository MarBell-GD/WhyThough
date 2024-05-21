using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialouge : ScriptableObject
{

    public dialogConsequence consequence; //Happens after dialogue

    public DialougeEntry[] dialouges; 

    public enum dialogConsequence
    {

        None,
        ChangeEmotion,
        GiveItem,
        Both,
        Damage,
        BadEnding

    }

    [Header("Consequence: Emotion")]
    public PlayerEmotions.Emotion targetEmotion;
    public float emotionChange;
    public bool subtract;

    [Header("Consequence: Item")]
    public Item givenItem; //<=== doesn't do anything

    [Header("Consequence: Bad Ending")]
    public string deathDescription; //how did you fuck up

}
