using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougeEntry
{
    public enum dialougeType
    {

        Text,
        Choice

    }

    [Header("Init")]
    public dialougeType type;

    public string Name; //Who's saying it
    public enum nameSide
    {

        Left,
        Right,
        Middle

    }
    public nameSide side;
    public Color nameColor;

    [Header("Type: Dialouge")]
    [TextArea(3, 5)] public string text; //What they will say

    [Header("Type: Choice")]
    [Range(1, 3)] public int choiceNum; 
    //Will normally be 2 or 3, but still kept the ability to have 1 just bcuz
    [Space]
    public Choice c1;
    public Choice c2;
    public Choice c3;

}
