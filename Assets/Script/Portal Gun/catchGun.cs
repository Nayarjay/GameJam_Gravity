using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchGun : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 relativePosition;
    bool isPortable;
    private void Start()
    {
        playerTransform = null;
        relativePosition = transform.localPosition;
    }

    private void Update()
    {
        if (isPortable)
        {
            transform.localPosition = new Vector3(0f, 0.87f, 0f);
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("I PASS");
            playerTransform = collision.transform;
            transform.SetParent(playerTransform);
            transform.localPosition = relativePosition;

            Collider2D myCollider = GetComponent<Collider2D>();
            myCollider.enabled = false;
            isPortable = true;
        }
    }
}

