using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class wave : MonoBehaviour {
    public bool is_waving, currently_waving = false;
    public bool gib_points = false;
    public GameObject sprite;
    public Material idle1, idle2, idle3, wave1, wave2, wave3;
    public Text words;
    private float score = 0;
    private float anim_timer=0;
    private void Start()
    {
        words = GameObject.Find("Canvas").GetComponent<Canvas>().GetComponentInChildren<Text>();
    }

    private void FixedUpdate()
    {
        if (is_waving)
        {
            gib_points = true;
            StartCoroutine(handmove());
        }
        words.text = "Score: " + score;
        if (!currently_waving)
        {
        anim_timer++;

        }

        if (anim_timer == 5)
        {
            sprite.GetComponent<Renderer>().material = idle2;

        }
        if (anim_timer == 10)
        {
            sprite.GetComponent<Renderer>().material = idle3;

        }
        if (anim_timer == 15)
        {
            sprite.GetComponent<Renderer>().material = idle1;
            anim_timer = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (gib_points && other.tag == "NPC")
        {
            gib_points = false;
            if (other.GetComponent<bystander>().cur_state == bystander.State.punch)
            {
                score -= 25;
                }
            //Debug.Log("wave back");
            StartCoroutine(addpoints(other));

        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.tag == "crowd")
        {
            StartCoroutine(Reset());
        }
    }
    IEnumerator addpoints(Collider col)
    {
        col.gameObject.GetComponent<bystander>().WaveBack();
        score += 1+col.gameObject.GetComponent<bystander>().annoyance;//adjust so anger factor is taken into account
       
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator handmove()
    {
        is_waving = false;
        //set to wave frame 1
        //Debug.Log("wave1");
        sprite.GetComponent<Renderer>().material = wave1;
        yield return new WaitForSeconds(0.1f);
        //set to wave frame 2
        //Debug.Log("wave2");
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<Renderer>().material = wave2;
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<Renderer>().material = wave3;
        sprite.GetComponent<Renderer>().material = wave1;
        yield return new WaitForSeconds(0.1f);
        //set to wave frame 2
        //Debug.Log("wave2");
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<Renderer>().material = wave2;
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<Renderer>().material = wave3;
        sprite.GetComponent<Renderer>().material = wave1;
        yield return new WaitForSeconds(0.1f);
        //set to wave frame 2
        //Debug.Log("wave2");
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<Renderer>().material = wave2;
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<Renderer>().material = wave3;
        //set to original
        //Debug.Log("wave3");
        currently_waving = false;
    }

    IEnumerator Reset()
    {
        GameObject.FindGameObjectWithTag("background").GetComponent<infinitebackground>().moveable = false;
        yield return new WaitForSeconds(5f);
        //load splash scene;
        SceneManager.LoadScene(0);
    }
}
