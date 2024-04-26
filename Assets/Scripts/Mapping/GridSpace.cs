using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class GridSpace : ScriptableObject
{

    public Vector2 pos; //Position on the map of this space
    public Sprite background; //For examination
    
    public bool requiresThing; //Doesn't do anything for now...

    public ItemSpawn spawn;
    
}
