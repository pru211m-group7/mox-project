using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    private static MusicMenu backgroundMusic;
    void Awake()
    {
        /*if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);

        }
        else
        {
            Destroy(gameObject);
        }*/
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            return;
        }

        Destroy(gameObject);

    }
}
