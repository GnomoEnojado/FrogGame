using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody rb;
    public float jumpForce=112f;
    public float groundCheckDistance=0.3f;
    public bool isGrounded=false;
    private Transform myTransform;
    BoxCollider boxCollider;

    


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Physics.Raycast(myTransform.position+(Vector3.up*0.1f),Vector3.down,groundCheckDistance))
        {
            isGrounded = true;

        }
       /* else
        {           
            isGrounded = false;
        }*/
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
               
                adjustPositionAndRotation(new Vector3(0, 0, 0));
                rb.AddForce(0, jumpForce, jumpForce);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                adjustPositionAndRotation(new Vector3(0, 180, 0));
                rb.AddForce(0, jumpForce, -jumpForce);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                adjustPositionAndRotation(new Vector3(0, -90, 0));
                rb.AddForce(-jumpForce, jumpForce, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                adjustPositionAndRotation(new Vector3(0, 90, 0));
                rb.AddForce(jumpForce, jumpForce,0 );
            }
           
        }
	}

    private void adjustPositionAndRotation(Vector3 newRotation)
    {
        rb.velocity = Vector3.zero;
        myTransform.eulerAngles = newRotation;
        myTransform.position = new Vector3(myTransform.position.x,myTransform.position.y,Mathf.Round(myTransform.position.z));

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Ground")
        {
          
            isGrounded = true;
            myTransform.position = new Vector3(Mathf.Round(myTransform.position.x),myTransform.position.y,Mathf.Round(myTransform.position.z));
       
        }
     
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag=="Ground")
        {
            isGrounded = false;
        }
  
    }
}
