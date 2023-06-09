using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject transitionObject;

    public void PlayGame()
    {
        StartCoroutine(DoPlay());
    }

    IEnumerator DoPlay()
    {
        yield return StartCoroutine(Transition());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public IEnumerator Transition()
    {
        transitionObject.SetActive(true);
        for (int i = 0; i < 800; i++)
        {
            transitionObject.transform.localPosition = new Vector3(transitionObject.transform.localPosition.x, i);
            yield return new WaitForSeconds(1f/800f);
        }
    }
}
