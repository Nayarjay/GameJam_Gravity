using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private float originalGravity;
    private float moonGravity = 1.62f;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
        rb.gravityScale = moonGravity;
    }

    private void OnDisable()
    {
        rb.gravityScale = originalGravity;
    }

    // Reste du code...
}
