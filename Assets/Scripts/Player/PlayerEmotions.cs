using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmotions : MonoBehaviour
{

    //The code here is so extremely simple...if you don't get it I can't help you

    [HideInInspector] [Range(1, 100)] [Tooltip("Only edit here for testing purposes")] public float rageEmo;
    [HideInInspector] [Range(1, 100)] [Tooltip("Only edit here for testing purposes")] public float lazyEmo;
    [HideInInspector] [Range(1, 100)] [Tooltip("Only edit here for testing purposes")] public float fearEmo;

    [HideInInspector] public float highestEmo;

    public enum Emotion
    {

        Rage,
        Laziness,
        Fear,
        Neutral

    }

    public Emotion playerEmotion;

    // Start is called before the first frame update
    void Start()
    {

        playerEmotion = Emotion.Neutral;

        rageEmo = 0;
        lazyEmo = 0;
        fearEmo = 0;

        highestEmo = 0;

    }

    // Update is called once per frame
    void Update()
    {

        EmotionCap();
        EmotionCheck();

    }

    #region Emotion Checking

    void EmotionCap()
    {

        if(rageEmo > 100)
            rageEmo = 100;

        if (lazyEmo > 100)
            lazyEmo = 100;

        if (fearEmo > 100)
            fearEmo = 100;

    }

    void EmotionCheck()
    {

        if (rageEmo > lazyEmo && rageEmo > fearEmo)
        {

            playerEmotion = Emotion.Rage;
            highestEmo = rageEmo;

        }
        else if (lazyEmo > rageEmo && lazyEmo > fearEmo)
        {

            playerEmotion = Emotion.Laziness;
            highestEmo = lazyEmo;

        }
        else if (fearEmo > rageEmo && fearEmo > lazyEmo)
        {

            playerEmotion = Emotion.Fear;
            highestEmo = fearEmo;

        }
        else
        {

            playerEmotion = Emotion.Neutral;
            highestEmo = 0;

        }

    }

    #endregion

    //Public thing so other scripts can call and affect emotions
    public void EmotionAdjust(Emotion emotion, float value, bool subtract)
    {

        if(emotion == Emotion.Rage) 
        {

            if (subtract)
                rageEmo -= value;
            else
                rageEmo += value;
            
        }
        else if(emotion == Emotion.Laziness)
        {

            if (subtract)
                lazyEmo -= value;
            else
                lazyEmo += value;

        }
        else if(emotion == Emotion.Fear)
        {

            if (subtract)
                fearEmo -= value;
            else
                fearEmo += value;

        }

    }

}
