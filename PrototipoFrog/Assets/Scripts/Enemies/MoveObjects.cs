using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour {
    public float minSpeed, maxSpeed;
    private Rigidbody rb;
    private Vector3 newVelocity;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        newVelocity = new Vector3(0,0, -Random.Range(minSpeed, maxSpeed));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = newVelocity;
	}
}
