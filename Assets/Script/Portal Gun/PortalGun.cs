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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Créer le portail bleu
            CreatePortal(cursorPos, Blueportal, ref bluePortal);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Créer le portail orange
            CreatePortal(cursorPos, Orangeportal, ref orangePortal);
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
}
