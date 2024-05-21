using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{

    //All item related scripts and functions are completely unused

    public string Name;
    public Sprite Image;
    [TextArea(3, 5)] public string Description;

}
