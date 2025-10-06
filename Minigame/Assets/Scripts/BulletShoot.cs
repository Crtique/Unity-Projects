using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float bulletDelay = 1.0f;

    private float timeOfLastShot;

    public GameObject bulletPrefab;

    private bool isDoubleShot = false;
    public float doubleShotDurration = 5f;
    public float doubleShotOffset = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - timeOfLastShot >= bulletDelay)
        {
            Shoot(); // Call the shoot function
            timeOfLastShot = Time.time;
        }
    }
    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab not assigned!");
            return;
        }

        if (isDoubleShot)
        {
            float offset = doubleShotOffset;

            // Offsets for both bullets
            Vector3 leftOffset = transform.position + transform.right * -offset;
            Vector3 rightOffset = transform.position + transform.right * offset;

            // Slight angles for spread (adjust to taste)
            Quaternion leftRotation = Quaternion.Euler(0, -10f, 0);
            Quaternion rightRotation = Quaternion.Euler(0, 10f, 0);

            // Create the two bullets
            GameObject bullet1 = Instantiate(bulletPrefab, leftOffset, leftRotation);
            GameObject bullet2 = Instantiate(bulletPrefab, rightOffset, rightRotation);
        }
        else
        {
            // Launch a projectile from the player
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        } 
    }

    // Call the method to activate the double shooting for a short period of time
    public void ActivateDoubleShot()
    {
        if (!isDoubleShot)
        {
            isDoubleShot = true;
            StartCoroutine(DisableDoubleShotAfterTime(doubleShotDurration));
        }
    }
    private System.Collections.IEnumerator DisableDoubleShotAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDoubleShot = false;
    }
}
