using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Capsule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.GetComponent<O2Bar>().EnterO2Zone();
        collision.GetComponentInChildren<O2Bar>().EnterO2Zone();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponentInChildren<O2Bar>().ExitO2Zone();
    }
}
