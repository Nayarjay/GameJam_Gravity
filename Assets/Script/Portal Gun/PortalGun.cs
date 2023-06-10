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

            // Cr�er le portail bleu
            CreatePortal(cursorPos, Blueportal, ref bluePortal);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Cr�er le portail orange
            CreatePortal(cursorPos, Orangeportal, ref orangePortal);
        }
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
}
