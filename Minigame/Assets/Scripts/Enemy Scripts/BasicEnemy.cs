using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;

    public float bulletDelay = 0.5f;
    private float timeOfLastShot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed
        if (Time.time - timeOfLastShot >= bulletDelay)
        {
            Shoot();
            timeOfLastShot = Time.time;
        }
    }

    void Shoot()
    {
        // Launch a projectile from the player
        Instantiate(enemyBulletPrefab, transform.position, enemyBulletPrefab.transform.rotation);
    }
}
