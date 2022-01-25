using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public float damage = 50f;
    public float range = 100f;
    public bool canShoot;
    public int ammo;
    public Camera fpsCam;
    public GameObject impactEffect;
    public GameObject player;




    void Start()
    {
        canShoot = true;
        ammo = 0;
        GameObject.Find("Canvas/ShotgunShells/FirstShell").SetActive(false);
        GameObject.Find("Canvas/ShotgunShells/SecondShell").SetActive(false);

    }
    void Update()
    {
        


            if (Input.GetKey(KeyCode.Mouse0) && canShoot && ammo > 0)
            {

                Debug.Log(canShoot);
                Shoot();

            }

            if (Input.GetKey("r"))
            {
                reload();
            }

            switch (ammo)
            {
                case 2:
                    GameObject.Find("Canvas/ShotgunShells/FirstShell").SetActive(true);
                    GameObject.Find("Canvas/ShotgunShells/SecondShell").SetActive(true);
                    GameObject.Find("Advices/Canvas/ReloadAdv").SetActive(false);

                    break;

                case 1:
                    GameObject.Find("Canvas/ShotgunShells/FirstShell").SetActive(true);
                    GameObject.Find("Canvas/ShotgunShells/SecondShell").SetActive(false);
                    GameObject.Find("Advices/Canvas/ReloadAdv").SetActive(false);

                    break;
                case 0: 
                    GameObject.Find("Canvas/ShotgunShells/FirstShell").SetActive(false);
                    GameObject.Find("Canvas/ShotgunShells/SecondShell").SetActive(false);
                    break;

                default:

                    GameObject.Find("Canvas/ShotgunShells/FirstShell").SetActive(false);
                    GameObject.Find("Canvas/ShotgunShells/SecondShell").SetActive(false);
                    GameObject.Find("Canvas/ShotgunShells/SecondShell").SetActive(false);
                    GameObject.Find("Advices/Canvas/ReloadAdv").SetActive(true);

                    break;
            }
        

    }
    void reload()
    {
            playSound("reload");
            gameObject.GetComponent<Animator>().SetBool("reloading", true);
            StartCoroutine(reloadingTimeout());
        

    }
    void Shoot()
    {
     
            playSound("shoot");
            canShoot = false;
            gameObject.GetComponent<Animator>().SetBool("shooting", true);
            RaycastHit hit;
            
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                var HT = hit.transform;
                var GO = hit.collider.gameObject;
                var tag = HT.tag;
                Debug.Log(GO);
                if(tag != "AreaDetector")
                {
                    if (tag == "Enemy")
                    {
                    Debug.Log(GO);

                    if (HT.name.Contains("eyedoom"))
                    {
                        HT.gameObject.GetComponent<EyeDoomController>().TakeDmg(player, damage);
                    }
                    if(HT.name.Contains("Skunk"))
                    {
                        HT.gameObject.GetComponent<SkunkController>().TakeDmg(player, damage);
                    }
                    }
                    GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impact, 2f);
                }
                
                
                
            };


            
            ammo -= 1;
            StartCoroutine(setShotTrue());
    }

    void playSound(string name)
    {
        switch (name)
        {
            case "shoot":
                SFXManager.sfxInstance.Audio.clip = SFXManager.sfxInstance.Shoot;
                break;
            case "reload":
                SFXManager.sfxInstance.Audio.clip = SFXManager.sfxInstance.Reload;
                break;



        }
        SFXManager.sfxInstance.Audio.Play();

    }

    IEnumerator setShotTrue()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Animator>().SetBool("shooting", false);
        canShoot = true;
    }
    IEnumerator reloadingTimeout()
    {
        yield return new WaitForSeconds(1);
        ammo = 2;
        gameObject.GetComponent<Animator>().SetBool("reloading", false);

    }

    public void addAmmo()
    {
        ammo=2;
        
    }
}
