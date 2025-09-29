using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = -10.0f;
    private float bottomBound = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }
}
