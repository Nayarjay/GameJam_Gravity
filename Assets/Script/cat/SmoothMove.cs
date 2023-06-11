using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement horizontal
    public float verticalSpeed = 5f; // Vitesse de déplacement vertical

    private void FixedUpdate()
    {
        // Mouvement horizontal automatique
        float moveDistance = speed * Time.fixedDeltaTime;
        Vector2 horizontalMovement = new Vector2(moveDistance, 0f);
        transform.Translate(horizontalMovement);

        // Mouvement vertical contrôlé par le joueur
        float moveVertical = Input.GetAxis("Vertical") * verticalSpeed * Time.fixedDeltaTime;
        Vector2 verticalMovement = new Vector2(0f, moveVertical);
        transform.Translate(verticalMovement);
    }
}
