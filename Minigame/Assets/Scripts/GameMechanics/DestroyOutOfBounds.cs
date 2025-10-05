using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private PlayerController playerController;
    private float topBound = -10.0f;
    private float bottomBound = 10.0f;

    public int bruteEscapeDamage = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
            Debug.Log("PlayerController assigned!");
        }
        else
        {
            Debug.LogWarning("Player not found in scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy game objects
        if (transform.position.z < topBound)
        {
            Destroy(gameObject);
        }
        // Destroy game objects on the -z axis
        else if (transform.position.z > bottomBound)
        {
            if (CompareTag("EnemyBrute") && playerController != null)
            {
                playerController.TakeDamage(bruteEscapeDamage);
                Debug.Log("Brute escaped! Damage applied.");
            }
            Destroy(gameObject);
        }
    }
}
