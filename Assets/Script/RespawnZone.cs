using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform respawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           //player.transform.position = respawn.position;
            collision.transform.position = respawn.position;
        }
    }
}
