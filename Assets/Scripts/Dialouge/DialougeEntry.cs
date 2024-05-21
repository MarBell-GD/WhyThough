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
    public dialougeType type; //If choice, the choice UI will show up and you can't proceed until a choice is made

    public string Name; //Who's saying it
    public enum nameSide
    {

        Left,
        Right,
        Middle

    }
    public nameSide side; //The name panel will move to the side dictated
    public Color nameColor; //For style!!

    [Header("Characters")]
    //Character 1 is the Left character
    //2 is the middle one
    //3 is the right one

    public bool char1present;
    public Sprite char1;
    [Space]
    public bool char2present;
    public Sprite char2;
    [Space]
    public bool char3present;
    public Sprite char3;

    [Header("Type: Dialouge")]
    [TextArea(3, 5)] public string text; //What they will say

    [Header("Type: Choice")]
    [Range(1, 3)] public int choiceNum; 
    //Will normally be 2 or 3, but still kept the ability to have 1 just bcuz
    //no idea if it works though, I freeballed it
    [Space]
    public Choice c1;
    public Choice c2;
    public Choice c3;

}
