﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Player")
        {
            Destroy(collision.gameObject);
        }
    }
}