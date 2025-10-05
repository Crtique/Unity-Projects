using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [Header("Item Drops")]
    public GameObject[] upgradeDrops;

    private float dropChance = 0.25f;
    public int pointsWorth = 5;
    public int brutePointsWorth = 10;

    public int basicEnemyHealth = 100;
    public int bruteHealth = 200;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy has been hit by the player
        if (gameObject.CompareTag("Enemy") && other.CompareTag("PlayerBullet") )
        {
            EnemyDie();
            Destroy(other.gameObject); // Destroy the bullet
        }
        else if (gameObject.CompareTag("EnemyBrute") && other.CompareTag("PlayerBullet"))
        {
            BruteDie();
            Destroy(other.gameObject);
        }
    }

    // Kills and Adds points to the "Brute" type enemy
    void BruteDie()
    {
        // Check when the Brutes health drops to zero or less when it does destroy/kill Brute
        if (bruteHealth <= 0)
        {
            Destroy(gameObject);
            if (PointsManager.instance != null) //Check if the PointsManger object does exisit if it doesn't send an error
            {
                PointsManager.instance.AddPoints(brutePointsWorth);
            }
            else
            {
                Debug.LogError("PointsManager instance not found!");
            }
        }

        DropItem();
        PlayerBulletDamage(5);
    }

    // Kills and Adds points to the "Basic Enemy" type
    void EnemyDie()
    {
        // Check when the BasicEnemy health drops to zero or less when it does destroy/kill BasicEnemy
        if (basicEnemyHealth <= 0)
        {
            Destroy(gameObject);
            if (PointsManager.instance != null) //Check if the PointsManger object does exisit if it doesn't send an error
            {
                PointsManager.instance.AddPoints(pointsWorth);
            }
            else
            {
                Debug.LogError("PointsManager instance not found!");
            }
        }

        DropItem();
        PlayerBulletDamage(5);
    }

    void DropItem()
    {
        if (upgradeDrops.Length == 0) return;

        float roll = Random.value; // Roll a dice of a random value
        // When the roll is Lessthan or Equal to the Drop rate drop the item
        if (roll <= dropChance)
        {
            // Pick random item from the lise
            int dropIndex = Random.Range(0, upgradeDrops.Length);
            GameObject upgradeDrop = upgradeDrops[dropIndex];

            Instantiate(upgradeDrop, transform.position, Quaternion.identity);
        }
    }

    void PlayerBulletDamage(int damage)
    {
        bruteHealth -= damage;
        basicEnemyHealth -= damage;
    }
}