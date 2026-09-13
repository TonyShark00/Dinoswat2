using UnityEngine;

public class DashHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Enemy"))
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}