using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 2f;

    private Transform target;
    private float timer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Shoot(); // fire immediately on spawn
        timer = 0f;
    }

    void Update()
    {
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