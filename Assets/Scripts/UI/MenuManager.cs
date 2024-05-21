using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public bool webBuild; //If true, can't be fullscreened // for web version
    [HideInInspector] public bool fullscreen;

    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        fullscreen = false;

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

        if(!fullscreen && !webBuild)
        {

            Screen.SetResolution(1280, 720, false);

        }

    }

}
