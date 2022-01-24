using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    private bool haveShotgun;
    private bool haveGasMask;


    public GameObject player;

    void Start()
    {
        health = 100;
        haveShotgun = false;
        haveGasMask = false;

    }
    void Update()
    {
              

    }
    public void addItem(string item)
    {
        switch (item)
        {
            case "gasmask":
                haveGasMask = true;
                GameObject.Find("Canvas/Items/GasMask").SetActive(true);
                break;
            case "shotgun":
                haveShotgun = true;
                GameObject.Find("Canvas/Items/Shotgun").SetActive(true);
                break;
        }
    }


}
