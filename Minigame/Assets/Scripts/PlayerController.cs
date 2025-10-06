using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private BulletShoot bulletShoot;
    public HealthBar healthBar;

    public float speed = 10.0f; //Give player speed
    public int maxHealth = 100;
    public static int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        bulletShoot = GetComponent<BulletShoot>();
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
            Destroy(other.gameObject); // Destroy the bullet

            TakeDamage(5);


            // Check when the players health drops to zero or less when it does destroy/kill player
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (CompareTag("Player") && other.CompareTag("EnemyBrute"))
        {
            Destroy(other.gameObject);
            TakeDamage(20);
        }

        if (other.CompareTag("HealthDrop"))
        {
            Health(10);
            Destroy(other.gameObject);
            
        }

        // Double shot upgrade
        if (other.CompareTag("UpgradeBox"))
        {
            bulletShoot.ActivateDoubleShot();
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        // Take damage when hit
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Health(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}