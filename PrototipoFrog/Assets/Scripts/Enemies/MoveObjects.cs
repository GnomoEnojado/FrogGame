using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour {
    public float minSpeed, maxSpeed;
  
    private Vector3 newVelocity;
	// Use this for initialization
	void Start () {
      
        newVelocity = new Vector3(0,0, -Random.Range(minSpeed, maxSpeed));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += newVelocity*Time.deltaTime;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
