using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 2f;
    public float destroyX = -15f;

    private Transform target;
    private float timer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Shoot();
        timer = 0f;
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
            return;
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

        float minVertical = 1.5f;
        if (Mathf.Abs(dir.y) < minVertical)
        {
            dir.y = dir.y >= 0 ? minVertical : -minVertical;
        }

        bullet.GetComponent<EnemyBullet>().SetDirection(dir);
    }
}