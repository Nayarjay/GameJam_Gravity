using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    Camera cam;
    public GameObject Blueportal;
    public GameObject Orangeportal;
    public Transform pivot;

    private GameObject bluePortal;
    private GameObject orangePortal;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        //roate gun arm

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                Vector2 hitPoint = hit.point;
                CreatePortal(hitPoint, Blueportal, ref bluePortal);
            }
        }
        /*else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                Vector2 hitPoint = hit.point;
                CreatePortal(hitPoint, Orangeportal, ref orangePortal);
            }
        }*/
    }

    // Cr�er un portail et d�truire l'ancien portail de m�me couleur
    void CreatePortal(Vector2 position, GameObject portalPrefab, ref GameObject portal)
    {
        // V�rifier si le portail existe d�j�
        if (portal != null)
        {
            // D�truire l'ancien portail
            Destroy(portal);
        }

        // Cr�er le nouveau portail
        portal = Instantiate(portalPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);

        // Effectuer une rotation du bras du pistolet (ajoutez votre code de rotation ici)
    }
    // Dessiner le raycast avec une ligne de d�bogage
    void OnDrawGizmos()
    {
        /*Gizmos.color = Color.red;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        Gizmos.DrawRay(transform.position, direction);*/
    }
}
