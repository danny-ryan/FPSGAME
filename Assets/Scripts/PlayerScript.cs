using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float bulletSpeed = 50f;
    public int maxBullets = 20;
    public float shootRate = 0.25f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;
    public GameObject[] bulletPool; // <- Semicolon
    /* ^        ^     ^     ^
     * |        |     |     Variable name
     * |        |     Array specifier
     * |        Data type
     * Access specifier
     */

    private float shootTimer = 0f;

	// Use this for initialization
	void Start ()
    {
        // Create a bulletPool with max bullets
        bulletPool = new GameObject[maxBullets];
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
        HandleShooting();
	}

    void HandleMovement()
    {
        float inputHorz = Input.GetAxis("Horizontal");
        if(inputHorz != 0)
        {
            transform.position += Vector3.right * inputHorz * movementSpeed * Time.deltaTime;

            if (inputHorz > 0)
            {
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }

            if (inputHorz < 0)
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
        }
    }

    void HandleShooting()
    {
        // Count up the timer
        shootTimer += Time.deltaTime;
        // Check if the user presses the mouse button
        if (Input.GetAxis("Fire1") > 0)
        {
            // Check if the reaches the shoot rate
            if (shootTimer >= shootRate)
            {
                // Shoot a new bullet
                Shoot();
                // Set the timer back to 0
                shootTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        // Create a new bullet
        GameObject bullet = CreateBullet();
        if (bullet != null)
        {
            // Set it's position to bullet spawn pos
            bullet.transform.position = bulletSpawnPos.position;
            // Add force in direction of fire
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.AddForce(bulletSpawnPos.right * bulletSpeed, ForceMode.Impulse);
        }
    }

    GameObject CreateBullet()
    {
        // Loop through array and search for next
        // 'null' position
        for (int i = 0; i < bulletPool.Length; i++)
        {
            // Checking if the bulletPool index is null
            if (bulletPool[i] == null)
            {
                // Create a new bullet in that position
                GameObject clone = Instantiate(bulletPrefab);
                bulletPool[i] = clone;
                // Return that new bullet
                return clone;
            }
        }
        // Return null    
        return null;       
    }
}
