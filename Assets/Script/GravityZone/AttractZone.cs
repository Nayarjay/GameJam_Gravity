using UnityEngine;

public class AttractZone : MonoBehaviour
{
    public float attractionForce = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, -attractionForce);
            }
        }
    }
}
