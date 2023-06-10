using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _Distancejoint;
    public Rigidbody2D rb;
    public float force;
    private Vector3 MouseDir;
    public Transform LinePosition;
    public bool isGrappling;
    public Transform lookToHook;
    public LayerMask hookableLayer;


    // Start is called before the first frame update
    void Start()
    {
        isGrappling = true;
        _Distancejoint.autoConfigureDistance = true;
        _Distancejoint.enabled = false;
        _lineRenderer.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {
        MouseDir = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (isGrappling == true)
        {
            Vector2 direction = LinePosition.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, hookableLayer);

            if (Input.GetKeyDown(KeyCode.Mouse0) )
            {

                Vector2 mousepos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);



                _lineRenderer.SetPosition(0, mousepos);

                _lineRenderer.SetPosition(1, transform.position);
                _Distancejoint.connectedAnchor = mousepos;
                _Distancejoint.enabled = true;

                LinePosition.position = mousepos;


            }
            if (Input.GetKey(KeyCode.Mouse0) )
            {
               // Vector2 direction = LinePosition.position - transform.position;


                //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, hookableLayer);
                if (hit.collider != null)
                {


                    _lineRenderer.enabled = true;
                    _lineRenderer.SetPosition(1, transform.position);
                }
              




                //_lineRenderer.SetPosition(1, transform.position);


                //_lineRenderer.enabled = true;

            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _Distancejoint.enabled = false;

                _lineRenderer.enabled = false;
            }
            if (_Distancejoint.enabled)
            {
                _lineRenderer.SetPosition(1, transform.position);
            }
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Mouse0))
            {
                //Vector2 direction = LinePosition.position - transform.position;
                

                //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, hookableLayer);
                if (hit.collider != null)
                {

                   
                    rb.velocity = direction.normalized * force * 4 * Time.deltaTime;
                    _Distancejoint.enabled = false;
                }
                else
                {
                    _lineRenderer.enabled = false;
                }
            
            }

            if (Input.GetKeyUp(KeyCode.E) && Input.GetKey(KeyCode.Mouse0))
            {
                _Distancejoint.enabled = true;

            }
        }

    }
}
