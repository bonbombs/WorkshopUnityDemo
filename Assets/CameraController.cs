using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPosition = player.transform.position;

        // Add mouse rotation
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 10, player.transform.up) * offset;
        transform.position = playerPosition + offset;
        transform.LookAt(playerPosition);
    }
}
