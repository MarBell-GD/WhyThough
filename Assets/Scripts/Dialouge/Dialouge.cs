using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialouge : ScriptableObject
{

    public dialogConsequence consequence;

    public DialougeEntry[] dialouges;

    public enum dialogConsequence
    {

        None,
        ChangeEmotion,
        GiveItem,
        Both

    }

    [Header("Consequence: Emotion")]
    public PlayerEmotions.Emotion targetEmotion;
    public float emotionChange;
    public bool subtract;

    [Header("Consequence: Item")]
    public Item givenItem;

}
