using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerAnimation : MonoBehaviour {
    Animator anim;
    public CPlayer _player;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
     
        if (_player._preJump)
        {
            anim.SetBool("Prejump", true);
        }
        else
        {
            anim.SetBool("Prejump", false);
        }
	}
   
}
