using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement horizontal
    public float verticalSpeed = 5f; // Vitesse de déplacement vertical
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
    
        // Mouvement vertical contrôlé par le joueur
        float moveVertical = Input.GetAxis("Vertical") * verticalSpeed * Time.fixedDeltaTime;
        Vector2 verticalMovement = new Vector2(0f, moveVertical);
        rb.MovePosition(rb.position + verticalMovement);

        float moveDistance = speed * Time.fixedDeltaTime;
        Vector2 movement = new Vector2(moveDistance, 0f);
        rb.MovePosition(rb.position + movement);
    }
}
