using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 10.0f;
    private float fallSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "HealthDrop" || tag == "UpgradeBox")
        {
            transform.Translate(Vector3.back * fallSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }
}
