using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    public float speed = 3f; // slower than bg scroll, moves right
    public float destroyX = 20f; // off-screen right threshold

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Rock hit: " + other.gameObject.name + " tag: " + other.tag);

        if (other.CompareTag("Obstacle") || other.CompareTag("Enemy"))
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}