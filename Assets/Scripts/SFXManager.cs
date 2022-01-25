using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioSource Audio;
    public AudioClip Shoot , Reload , Ajam , FootStep , achievementSound , skunkShoot;

    public static SFXManager sfxInstance;

    public void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;

        }
        sfxInstance = this;
        DontDestroyOnLoad(this);

    }
}
