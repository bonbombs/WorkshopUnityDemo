using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour {

    // The bullet object we're going to be shooting
    public BulletBehavior bullet;
    // Shoot every x second
    public float shootRate = 1.5f;
    
    // Reference to our target
    private GameObject target;

    void Shoot()
    {
        // Look at our target
        transform.LookAt(target.transform);

        // Spawn a bullet at our center position
        BulletBehavior bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        // Point the bullet towards the target also
        bulletInstance.transform.forward = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Start shooting repeatedly!!!
            target = other.gameObject;
            InvokeRepeating("Shoot", 0f, shootRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // Stop shooting
            CancelInvoke("Shoot");
        }
    }
}
