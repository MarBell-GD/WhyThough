using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    //Very basic camera follow, just tweaked a bit for this game

    public float offset;
    [HideInInspector] public Vector3 overhead;

    [HideInInspector] public GameObject player;
    [HideInInspector] public PlayerMovement movement;

    private void Start()
    {

        movement = FindObjectOfType<PlayerMovement>();
        player = movement.gameObject;

    }

    private void Update()
    {

        overhead = new Vector3(player.transform.position.x, offset, player.transform.position.z);

        if (!movement.isMoving)
        {

            transform.position = overhead;

        }

    }

}
