using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trees : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.right * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "treesetter")
        {
            Vector3 temp= this.transform.position;
            temp.x -= Random.Range(30,45);
            this.transform.position = temp;
        }
    }
}
