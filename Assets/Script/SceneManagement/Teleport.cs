using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public bool isNext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isNext)
        {
            LevelLoader.Instance.LoadNextLevel();
        }
        else
        {
            LevelLoader.Instance.LoadPastLevel();
        }
    }
}
