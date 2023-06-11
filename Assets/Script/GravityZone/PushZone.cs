using UnityEngine;

public class PushZone : MonoBehaviour
{
    public float pushForce = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, pushForce);
            }
        }
    }
}
