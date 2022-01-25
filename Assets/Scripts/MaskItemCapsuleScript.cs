using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskItemCapsuleScript : MonoBehaviour
{
    private bool canGetMask;
    public GameObject player;
    public GameObject item;

    
    void Start()
    {
        
        canGetMask = false;
    }

    void Update()
    {
        var isDone = false;
        if(Input.GetKey("f") && canGetMask && !isDone)
        {
            player.GetComponent<PlayerStats>().addItem("gasmask");
            Debug.Log("Mask added to the inventory");
            isDone = true;
            SFXManager.sfxInstance.Audio.clip = SFXManager.sfxInstance.achievementSound;
            SFXManager.sfxInstance.Audio.Play();
            Destroy(item);
    

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Near to mask");
        canGetMask = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        canGetMask = false;
        Debug.Log("leave");

    }
    
}
