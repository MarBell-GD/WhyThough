using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougeEntry
{

    public string Name; //Who's saying it
    public enum nameSide
    {

        Left,
        Right,
        Middle

    }
    public nameSide side;
    public Color nameColor;

    [TextArea(3, 5)] public string text; //What they will say

}
