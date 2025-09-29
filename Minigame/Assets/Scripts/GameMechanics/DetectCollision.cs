using UnityEngine;

public class DetectCollision : MonoBehaviour
{
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

            //Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the bullet
        }
    }
}
