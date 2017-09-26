using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        //Debug.Log("TELEPORT");
        if (other.gameObject.tag == "Player") {
            other.transform.position = new Vector3(Random.Range(10,50), 0, Random.Range(10, 50));
        }
    }
}
