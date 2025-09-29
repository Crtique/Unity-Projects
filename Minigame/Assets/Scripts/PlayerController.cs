using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; //Give player speed
    public int playerHealth = 100;
    public Text textbox;
    private int bruteDamage = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textbox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Accessing the inputs to use
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 0, horizontalInput);

        // Horizontal Inputs
        transform.Translate(movement * Time.deltaTime * speed);

        // Show health onscreen
        textbox.text = "Health:" + playerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has been hit by the enemy
        if (CompareTag("Player") && other.CompareTag("EnemyBullet"))
        {
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
            Destroy(other.gameObject);
            playerHealth -= bruteDamage;
        }
    }
}
