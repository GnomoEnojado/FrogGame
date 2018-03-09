using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    private Vector3 offSet;
	// Use this for initialization
	void Start () {
        offSet = transform.position - player.position;
	}

    // Update is called once per frame
    void LateUpdate() {
        if (player!=null)
        {
            transform.position =  Vector3.Lerp(transform.position, new Vector3(player.position.x + offSet.x, offSet.y, player.position.z + offSet.z),200) ;
        }
    }
}
