using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    int currentScene;

    public static LevelLoader Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(currentScene + 1));
    }

    public void LoadPastLevel()
    {
        StartCoroutine(LoadLevel(currentScene - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }
}
