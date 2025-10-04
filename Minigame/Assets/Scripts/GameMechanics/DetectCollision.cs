using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [Header("Item Drops")]
    public GameObject[] upgradeDrops;

    public float dropChance = 0.2f;
    public int pointsWorth = 5;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy has been hit by the player
        if (gameObject.CompareTag("Enemy") && other.CompareTag("PlayerBullet"))
        {
            Die();
            Destroy(other.gameObject); // Destroy the bullet
        }
    }

    void Die()
    {
        if (PointsManager.instance != null)
        {
            PointsManager.instance.AddPoints(pointsWorth);
        }
        else
        {
            Debug.LogError("PointsManager instance not found!");
        }

        DropItem();

        Destroy(gameObject); // Destroy the Enemy object
    }

    void DropItem()
    {
        if (upgradeDrops.Length == 0) return;

        float roll = Random.value;
        if (roll <= dropChance)
        {
            // Pick random item
            int index = Random.Range(0, upgradeDrops.Length);
            GameObject upgradeDrop = upgradeDrops[index];

            Instantiate(upgradeDrop, transform.position, Quaternion.identity);
        }
    }
}
