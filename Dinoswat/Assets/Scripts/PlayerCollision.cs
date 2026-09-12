using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit: " + other.gameObject.name + " tag: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }
}