using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float xRange = 7;
    private float speed = 5.0f;
    private int dir = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * dir);


        if (transform.position.x > xRange)
        {
            dir = -1;
        }
        else if (transform.position.x < -xRange)
        {
            dir = 1;
        }
    }
}
