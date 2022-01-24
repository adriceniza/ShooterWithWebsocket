using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
   public void PlayGame()
   {
       SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Ajam);
       StartCoroutine(startGame());
   }
   public void QuitGame()
   {
       SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Ajam);
       Application.Quit();
   }
   
   IEnumerator startGame()
   {
      yield return new WaitForSeconds(1);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
}
