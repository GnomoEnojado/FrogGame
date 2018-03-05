using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWaterDir : MonoBehaviour {

    public Water waterToOff,waterToOn;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag=="Player")
        {
            waterToOff.enabled = false;
            waterToOn.enabled = true;
        }
    }
}
