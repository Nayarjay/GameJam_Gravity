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
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                Vector2 hitPoint = hit.point;
                CreatePortal(hitPoint, Orangeportal, ref orangePortal);
            }
        }
    }

    // Créer un portail et détruire l'ancien portail de même couleur
    void CreatePortal(Vector2 position, GameObject portalPrefab, ref GameObject portal)
    {
        // Vérifier si le portail existe déjà
        if (portal != null)
        {
            // Détruire l'ancien portail
            Destroy(portal);
        }

        // Créer le nouveau portail
        portal = Instantiate(portalPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);

        // Effectuer une rotation du bras du pistolet (ajoutez votre code de rotation ici)
    }
    // Dessiner le raycast avec une ligne de débogage
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        Gizmos.DrawRay(transform.position, direction);
    }
}
