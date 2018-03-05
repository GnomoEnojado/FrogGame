using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    Transform myTransform;
    public float speed;
	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        myTransform.Translate(0,0,-speed * Time.deltaTime);
	}
}
