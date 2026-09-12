using UnityEngine;

public class ChompHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}