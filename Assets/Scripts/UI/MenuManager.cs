using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [HideInInspector] public bool fullscreen;

    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        fullscreen = true;

    }

    public void changeFullscreen()
    {

        if (!fullscreen)
            fullscreen = true;
        else
            fullscreen = false;

    }

    void Update()
    {

        Screen.fullScreen = fullscreen;

        if(!fullscreen)
        {

            Screen.SetResolution(1280, 720, false);

        }

    }

}
