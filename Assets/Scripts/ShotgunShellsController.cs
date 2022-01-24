using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShellsController : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Weapon>().addAmmo();
        SFXManager.sfxInstance.Audio.clip = SFXManager.sfxInstance.achievementSound;
        SFXManager.sfxInstance.Audio.Play();   
    }

}
