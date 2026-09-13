using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }

        // also destroy if it hits the ground/obstacles so it doesn't fly forever
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
