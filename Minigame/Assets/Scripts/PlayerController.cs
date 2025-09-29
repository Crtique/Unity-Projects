using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; //Give player speed
    public int playerHealth = 100;

    private int bruteDamage = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Accessing the inputs to use
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 0, horizontalInput);

        // Horizontal Inputs
        transform.Translate(movement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has been hit by the enemy
        if (CompareTag("Player") && other.CompareTag("EnemyBullet"))
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
        else if (CompareTag("Player") && other.CompareTag("EnemyBrute"))
        {
            Debug.Log("Brute Hit!");
            Destroy(other.gameObject);
            playerHealth -= bruteDamage;
        }
    }
}
