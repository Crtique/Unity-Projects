using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float bulletDelay = 1.0f;

    private float timeOfLastShot;

    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - timeOfLastShot >= bulletDelay)
        {
            Shoot();
            timeOfLastShot = Time.time;
        }
    }
    void Shoot()
    {
        // Launch a projectile from the player
        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
    }
}
