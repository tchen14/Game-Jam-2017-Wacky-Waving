using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinitebackground : MonoBehaviour {
    public bool moveable;
    public float speed;
	// Use this for initialization
	void Start () {
        moveable = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveable)
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime* speed, Space.World);

        }
    }

    //hello tim. this is you, from the future. i love you and it will get better.
    //tim again, i am back. i lied.

    //kys... but also asl?
    //18/f/cali
    //you sound hawt
    //mmmm yeah
    //whatchu wearin'?
    //nothin'
    //why are you answering yourself?
    //im so lonely help me pls
    //this is going right to me_irl
    //they'll upvote anything

}
