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
        this.GetComponent<PortalGun>().enabled = false;
        playerTransform = null;
        relativePosition = transform.localPosition;
    }

    private void Update()
    {
        if (isPortable)
        {
            transform.localPosition = new Vector3(0.83f, 0f, 0f);
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
            this.GetComponent<PortalGun>().enabled = true;
        }
    }
}

