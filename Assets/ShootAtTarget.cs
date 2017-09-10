using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour {

    public BulletBehavior bullet;
    public float shootRate = 1.5f;

    private GameObject target;

    void Shoot()
    {
        transform.LookAt(target.transform);
        BulletBehavior bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.transform.forward = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            InvokeRepeating("Shoot", 0f, shootRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CancelInvoke("Shoot");
        }
    }
}
