using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ItemSpawn : ScriptableObject
{

    public Item targetItem;
    [Range(-775f, 775f)] public float xSpawn;
    [Range(-212f, 212f)] public float ySpawn;

}
