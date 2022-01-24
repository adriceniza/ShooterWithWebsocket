using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EyeDoomController : MonoBehaviour
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
                // GameObject.Find("HealthBar/Heart1").SetActive(true);
                // GameObject.Find("HealthBar/Heart2").SetActive(true);
                // GameObject.Find("HealthBar/Heart3").SetActive(true);
                // GameObject.Find("HealthBar/Heart4").SetActive(true);

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
                // GameObject.Find("HealthBar/Heart1").SetActive(true);
                // GameObject.Find("HealthBar/Heart2").SetActive(true);
                // GameObject.Find("HealthBar/Heart3").SetActive(true);
                // GameObject.Find("HealthBar/Heart4").SetActive(false);
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
                // GameObject.Find("HealthBar/Heart1").SetActive(true);
                // GameObject.Find("HealthBar/Heart2").SetActive(true);
                // GameObject.Find("HealthBar/Heart3").SetActive(false);
                // GameObject.Find("HealthBar/Heart4").SetActive(false);
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
                // GameObject.Find("HealthBar/Heart1").SetActive(true);
                // GameObject.Find("HealthBar/Heart2").SetActive(false);
                // GameObject.Find("HealthBar/Heart3").SetActive(false);
                // GameObject.Find("HealthBar/Heart4").SetActive(false);
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
                // GameObject.Find("HealthBar/Heart1").SetActive(false);
                // GameObject.Find("HealthBar/Heart2").SetActive(false);
                // GameObject.Find("HealthBar/Heart3").SetActive(false);
                // GameObject.Find("HealthBar/Heart4").SetActive(false);
                gameObject.GetComponent<Animator>().SetBool("alive", false);
                StartCoroutine(killAndDestroy(gameObject));
                

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

   

    IEnumerator killAndDestroy(GameObject destroyThis)
    {
        yield return new WaitForSeconds(2);
        Destroy(destroyThis);
    }
}
