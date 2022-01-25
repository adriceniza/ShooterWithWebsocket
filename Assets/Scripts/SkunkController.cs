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

    public GameObject bullet;
    public Transform firePoint;

    void Start()
    {
        health = maxHealth;
        slider.value = maxHealth;
        StartCoroutine(AutoShoot());
        
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

   

    void Shoot()
    {
        RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
        if(Physics.Raycast(transform.position, fireRotation * Vector3.forward , out hit , Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(bullet,firePoint.transform.position, fireRotation);
            SFXManager.sfxInstance.Audio.clip = SFXManager.sfxInstance.skunkShoot;
            SFXManager.sfxInstance.Audio.Play();
            tempBullet.GetComponent<MoveSkunkBullet>().hitPoint = hit.point;
        }
    }
    IEnumerator AutoShoot()
    {
        float pause = Random.Range(1,4);
        yield return new WaitForSeconds(pause);
        Shoot();
        StartCoroutine(AutoShoot());
    }
}
