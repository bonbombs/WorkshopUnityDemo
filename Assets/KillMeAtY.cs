using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeAtY : MonoBehaviour {

    public float killMeHere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= killMeHere)
        {
            transform.position = new Vector3(5.0f, 4.3f, 1.8f);
        }
	}
}
