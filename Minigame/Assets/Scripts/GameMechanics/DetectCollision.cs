using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int playerHealth = 100;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy has been hit by the player
        if (gameObject.CompareTag("Enemy") && other.CompareTag("PlayerBullet"))
        {
            Debug.Log("Enemy Hit!");

            Destroy(gameObject); // Destroy the Enemy object
            Destroy(other.gameObject); // Destroy the bullet
        }

        // Check if the player has been hit by the enemy
        else if (CompareTag("Player") && other.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit!");

            Destroy(other.gameObject); // Destroy the bullet

            // Decrease health
            playerHealth--;

            // Check when the players health drops to zero or less when it does destroy/kill player
            if (playerHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        
    }
}
