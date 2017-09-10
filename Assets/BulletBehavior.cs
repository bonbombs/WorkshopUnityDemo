using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public float bulletSpeed = 5f;
    public float timeAlive = 5f;

	// Use this for initialization
	void Start () {
        Invoke("Die", timeAlive);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
	}

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Die();
    }
}
