using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkunkController : MonoBehaviour
{
    private int health;
    public int maxHealth;
    public Slider slider;
    public GameObject healthBarUI;
    public float damage;
    void Start()
    {
        health = maxHealth;
        slider.value = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if (health > 75)
        {
            try
            {


            }
            catch (System.Exception)
            {

                throw;
            }

        }
        if (health <= 75)
        {
            try
            {

            }
            catch (System.Exception)
            {


                throw;
            }

        }
        if (health <= 50)
        {
            try
            {
           
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        if (health <= 25)
        {
            try
            {
              
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        if (health <= 0)
        {
            try
            {
               
               
                Destroy(gameObject);
                

            }
            catch (System.Exception)
            {
                throw;
            }

        }
        
    }

    public void TakeDmg(GameObject player , float damage)
    {

        
        health -= (int)damage;
        Debug.Log(damage + "health : "+ health);
        slider.value = health;

        player.GetComponent<FirstPersonMovementController>().updateScore((int)damage/2);
        
    }

   

    
}
