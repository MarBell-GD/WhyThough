using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{

    public string Name;
    public Sprite Image;
    [TextArea(3, 5)] public string Description;

}
