using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    // Gotta go fast
    public float bulletSpeed = 5f;

    // Time in seconds this bullet is alive
    public float timeAlive = 5f;

	// Use this for initialization
	void Start () {
        // Everytime an instance of this gets spawned, countdown timeAlive seconds before dying
        // Recommended so that we don't have a bazillion bullets in our game
        //  A bazillion bullets = A slow af game
        Invoke("Die", timeAlive);
	}
	
	// Update is called once per frame
	void Update () {
        // Make it travel in one direction at the speed we defined
        // Multiply it by delta time or else it's going to go an insane amount of distance per frame
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
	}

    void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        // If we hit the player early on, also die
        if (collision.gameObject.tag == "Player")
        {
            Die();
        }
    }
}
