using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newfriends : MonoBehaviour {
    public GameObject background;
    public GameObject spawn_point;
    public GameObject[] friends = new GameObject[4];
    private GameObject new_friend, this_one;
	// Use this for initialization
	void Start () {
        this_one = friends[ Random.Range(0, 3)];
        new_friend = Instantiate(this_one, spawn_point.transform.position, spawn_point.transform.rotation, background.transform) as GameObject;
        StartCoroutine(morefriends());
    }
	

    IEnumerator morefriends()
    {
        if (background.GetComponent<infinitebackground>().moveable)
        {
            yield return new WaitForSeconds(Random.Range(10,20));
            this_one = friends[Random.Range(0, 3)];
            new_friend = Instantiate(this_one, spawn_point.transform.position, spawn_point.transform.rotation, background.transform) as GameObject;
            //new_friend.transform.parent = background.transform;
            //Debug.Log(new_friend.transform.position);
        }
        else
        {
            yield return new WaitForSeconds(8);
        }

        StartCoroutine(morefriends());
       
    }
}
