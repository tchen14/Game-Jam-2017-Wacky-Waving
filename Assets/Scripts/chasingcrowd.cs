using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasingcrowd : MonoBehaviour {
    private GameObject background;
    public Vector3 origin;
    public GameObject player;
    public float speed = 0;
    private bool playing = false;
    private void Start()
    {
        //origin = this.gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.FindGameObjectWithTag("background");
    }

    private void FixedUpdate()
    {


        if (background.GetComponent<infinitebackground>().moveable)
        {
            //this.transform.position = Vector3.Lerp(origin, this.transform.position, Time.deltaTime);
            float step = speed/2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, origin, step);
            //transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            //this.transform.position = Vector3.Lerp(player.transform.position, this.transform.position, Time.deltaTime);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (!playing)
            {
                playing = true;
                this.GetComponent<AudioSource>().Play();
            }
            other.gameObject.transform.parent = this.gameObject.transform;
            other.tag = "crowd";
            other.GetComponent<bystander>().cur_state = bystander.State.chasing;
            other.GetComponent<bystander>().StartChase();
            speed += 1f;

        }
    }
}
