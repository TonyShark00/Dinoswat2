using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    public float speed = 3f; // slower than bg scroll, moves right
    public float destroyX = 20f; // off-screen destroying condition

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;   //moves 

        if (transform.position.x > destroyX)
        {
            Destroy(gameObject);    //destroys if offscreen
        }
    }

    private void OnTriggerEnter2D(Collider2D other)     //destroys other obstacles and enemies
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Enemy"))
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}