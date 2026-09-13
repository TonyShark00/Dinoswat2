using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 2f;
    public float destroyX = -15f;
    public float shootingRange = 8f; // only shoot within this distance

    private Transform target;
    private float timer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timer = fireInterval; // ready to shoot as soon as in range
    }

    void Update()
    {
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
            return;
        }

        if (transform.position.x < target.position.x)
        {
            return; // already passed the dino, stop shooting
        }

        float distance = transform.position.x - target.position.x;
        if (distance > shootingRange)
        {
            return; // too far away, angle would look bad
        }

        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 dir = (target.position - firePoint.position);
        bullet.GetComponent<EnemyBullet>().SetDirection(dir);
    }
}