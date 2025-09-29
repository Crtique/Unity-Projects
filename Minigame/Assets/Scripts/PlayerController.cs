using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; //Give player speed

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
}
