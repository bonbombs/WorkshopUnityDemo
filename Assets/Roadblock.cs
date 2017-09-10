using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadblock : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Set the player's position back to defined position
            collision.gameObject.transform.position = new Vector3(0f, 1, 6f);
        }
    }
}
