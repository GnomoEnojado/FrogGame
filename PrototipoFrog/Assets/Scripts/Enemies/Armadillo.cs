using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadillo : MonoBehaviour {
   
    public float speed;
    public Transform pointA,pointB;
    public bool goToA;
    float timer;
    public float cdToMove;

    // Update is called once per frame
    void Update()
    {
        if (goToA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }


        if (transform.position == pointA.position || transform.position==pointB.position)
        {
            timer += Time.deltaTime;
            if (timer>=cdToMove)
            {
                timer = 0;
                goToA = !goToA;
            }
        }

    }
}
