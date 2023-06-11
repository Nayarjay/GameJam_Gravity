using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public GameObject message;

    // Start is called before the first frame update
    void Awake()
    {
        message.SetActive(true);
        StartCoroutine(DespawnAfterSeconds());
    }

    public IEnumerator DespawnAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        message.SetActive(false);
    }


}
