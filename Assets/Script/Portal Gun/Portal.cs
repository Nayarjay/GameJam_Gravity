using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;
    public bool isOrange;
    public float distance = 0.2f;
    private bool isTeleporting = false;
    private bool hasExitedPortal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTeleporting)
        {
            return; // Exit the function if already teleporting to prevent teleporting again
        }

        if (collision.CompareTag("Player"))
        {
            if (hasExitedPortal)
            {
                hasExitedPortal = false;
            }
            else
            {
                isTeleporting = true;

                if (isOrange)
                {
                    destination = GameObject.FindGameObjectWithTag("blue portal").transform;
                }
                else
                {
                    destination = GameObject.FindGameObjectWithTag("orange portal").transform;
                }

                StartCoroutine(TeleportPlayer(collision.transform));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasExitedPortal = true;
            // StartCoroutine(ResetExitedPortal());
        }
    }

    private IEnumerator ResetExitedPortal()
    {
        yield return new WaitForSeconds(0.5f); // Delay before resetting hasExitedPortal
        hasExitedPortal = false;
    }

    private IEnumerator TeleportPlayer(Transform player)
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay if needed
        player.position = destination.position;
        isTeleporting = false;
    }
}
