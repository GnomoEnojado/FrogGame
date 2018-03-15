using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    public List<Transform>  objectsToMove;
    public int waterDirection; //0 arriba, 1 derecha, 2 abajo, 3 izquierda
    public float waterVelocity;
    public Transform endPosition;
    Vector3 startPos;

	// Update is called once per frame
	void Update () {
        if (objectsToMove.Count>0)
        {
            if (waterDirection==0)
            {
                for (int i = 0; i < objectsToMove.Count; i++)
                {
                    objectsToMove[i].transform.Translate(-waterVelocity * Time.deltaTime, 0, 0);
                }
            }
            if (waterDirection == 1)
            {
                for (int i = 0; i < objectsToMove.Count; i++)
                {
                   
                    objectsToMove[i].transform.Translate(0, 0, waterVelocity * Time.deltaTime);

                }
                
            }
            if (waterDirection == 2)
            {
                for (int i = 0; i < objectsToMove.Count; i++)
                {
                    
                    if (Mathf.Round(objectsToMove[i].transform.eulerAngles.y) == 270)
                    {
                        objectsToMove[i].transform.Translate(-waterVelocity * Time.deltaTime, 0, 0);
                    }
                    if (Mathf.Round(objectsToMove[i].transform.eulerAngles.y) == 90)
                    {
                        objectsToMove[i].transform.Translate(waterVelocity * Time.deltaTime, 0, 0);
                    }
                    if (Mathf.Round(objectsToMove[i].transform.eulerAngles.y) == 0)
                    {
                        objectsToMove[i].transform.Translate(0, 0, -waterVelocity * Time.deltaTime);
                    }
                    if (Mathf.Round(objectsToMove[i].transform.eulerAngles.y) == 180)
                    {
                        objectsToMove[i].transform.Translate(0, 0, waterVelocity * Time.deltaTime);
                    }
               
                }

            }
            if (waterDirection == 3)
            {
                for (int i = 0; i < objectsToMove.Count; i++)
                {
                    objectsToMove[i].transform.Translate(0, 0, -waterVelocity * Time.deltaTime);
                }
               

            }
        }
	}
    private bool IsInList(GameObject aObject)
    {
        for (int i = 0; i < objectsToMove.Count; i++)
        {
            if (objectsToMove[i].gameObject==aObject)
            {
                return true;
            }
        }
        return false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "ObjectToMoveInWater")
        {
            if (!IsInList(other.gameObject))
            {
                objectsToMove.Add(other.transform);
            }
            if (other.transform.tag == "Player")
            {
                other.GetComponent<CPlayer>().canSpeedJump = false;
            }
        }
    }
  

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "ObjectToMoveInWater")
        {
            objectsToMove.Remove(other.transform);
            if (other.transform.tag == "Player")
            {
                other.GetComponent<CPlayer>().canSpeedJump = true;
            }
        }
    }
   

}
