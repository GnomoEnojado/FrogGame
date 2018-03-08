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

    public bool _jump;

    private void Start()
    {
        endPos = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (percent==1 && gameObject.transform.position == endPos)
            {                
                _jump = true;
                lerpTime = 0.5f;
                currentLerpTime = 0;
                firstInput = true;
                startPos = gameObject.transform.position;
            }

        }
        

        if (gameObject.transform.position==endPos)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
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
        
            if (percent>0.8f)
            {
                percent = 1;
            }
            if (Mathf.Round(percent) == 1)
            {
                _jump = false;

            }
        }
    }

}
