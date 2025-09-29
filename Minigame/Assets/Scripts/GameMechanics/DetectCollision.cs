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
    }
}
