using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {
   public float lerpTime;
   public float currentLerpTime;
   public float percent=1;

    Vector3 startPos;
    Vector3 endPos;
    bool firstInput;
    //[HideInInspector]
    public bool _jump;
    public float minVelJump;
    private float startLerpTime;
    int cantJumps;
    float cdJumps=0.5f;
    float timer;
    Animator anim;
    float animSpeed;
 
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        animSpeed = anim.speed;
        startLerpTime = lerpTime;
        endPos = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
      
        if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            if (timer>=cdJumps)
            {
                cantJumps = 0;
                lerpTime = startLerpTime;
                anim.speed = 1;
            }
            timer = 0;
            cantJumps++;

            if (cantJumps>=4)
            {
                if (lerpTime/1.5f>= minVelJump)
                {
                    anim.speed *= 2;
                    lerpTime /= 1.5f;
                   
                }
                
                gameObject.transform.position = endPos;
                cantJumps = 0;
            }
            if (gameObject.transform.position == endPos)
            {
                _jump = true;
                currentLerpTime = 0;
                firstInput = true;
                startPos = endPos;
            }

        }
        

        if (gameObject.transform.position==endPos)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
         
        }
        if (firstInput)
        {
            currentLerpTime += Time.deltaTime;
            percent = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, percent);
        

            if (Mathf.Round(percent) == 1)
            {
                _jump = false;

            }
        }
    }

}
