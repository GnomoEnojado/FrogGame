using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {
    public float timeToDestiny;
	private float time;
	private float objectT = 0;
	public float h;
	bool correctPosition;

	Vector3 startPos;
    Vector3 endPos;
    bool firstInput;
    [HideInInspector]
    public bool _preJump;
    public float minVelJump;
	private float startDestinyTime;
	private int cantJumps;
    float cdJumps=0.5f;
    float timer;
    Animator anim;

 
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
		time = timeToDestiny;
        startDestinyTime = timeToDestiny;
		startPos = transform.position;
        endPos =   transform.position;
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        
        

        if (gameObject.transform.position==endPos)
        {
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
			{
				firstInput = true;
				_preJump = true;

				if (Input.GetKeyDown(KeyCode.W))
				{
					transform.eulerAngles = new Vector3(0, 90, 0);
				}
				else if (Input.GetKeyDown(KeyCode.S))
				{
					transform.eulerAngles = new Vector3(0, -90, 0);
				}
				else if (Input.GetKeyDown(KeyCode.A))
				{
					transform.eulerAngles = new Vector3(0, 0, 0);
				}
				else if (Input.GetKeyDown(KeyCode.D))
				{
					transform.eulerAngles = new Vector3(0, 180, 0);
				}
			}
			if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
			{
				time=0;
				_preJump = false;
                correctPosition = false;
                if (timer>=cdJumps)
				{
					cantJumps = 0;
					timeToDestiny = startDestinyTime;
					anim.speed = 1;
				}
				timer = 0;
				cantJumps++;

				if (cantJumps>=3)
				{
					if (timeToDestiny/1.5f>= minVelJump)
					{
						timeToDestiny /= 1.5f;

					}

					cantJumps = 0;
				}
				if (Input.GetKeyUp(KeyCode.W))
				{
					endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

				}
				else if (Input.GetKeyUp(KeyCode.S))
				{
					endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);

				}
				else if (Input.GetKeyUp(KeyCode.A))
				{
					endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

				}
				else if (Input.GetKeyUp(KeyCode.D))
				{
					endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

				}

			}
          
         
        }

			time += Time.deltaTime;

			if (time < timeToDestiny) {
				objectT = (time / timeToDestiny) % 1;


				gameObject.transform.position = Parabola (startPos, endPos, h, objectT);
			} 
			else 
			{
				if(!correctPosition)
				{
					gameObject.transform.position = new Vector3 (Mathf.Round (transform.position.x),Mathf.Round (transform.position.y),Mathf.Round (transform.position.z));
					startPos = transform.position;
                    correctPosition = true;
				}
			}


        
    }
	private Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
	{
		float parabolicT = t * 2 - 1;

		if (true)
		{
			Vector3 travelDirection = end - start;

			Vector3 result = start + t * travelDirection;
			result.y += (-parabolicT * parabolicT + 1) * height;
			return result;
		}
	}
}
