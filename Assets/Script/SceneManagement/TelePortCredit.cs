using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelePortCredit : MonoBehaviour
{
     
    public Animator transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){

            //LoadLevel();
            SceneManager.LoadScene("Credits");
        }
       
    }

     IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

       SceneManager.LoadScene("Credits");
    }
}
