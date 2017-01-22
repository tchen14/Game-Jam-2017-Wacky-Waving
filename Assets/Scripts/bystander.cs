using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bystander : MonoBehaviour {
    public State cur_state;
    public GameObject sprite;
    public Material wave, idle_d, idle_a, idle_i, punch, run1, wave_a, wave_i;
    public bool is_waving = false;
    public float annoyance = 0;
    public enum State
    {
        idle,
        waving,
        chasing,
        punch
    }

    private void Start()
    {
      // cur_state = State.walking;
    }

    /*
    private void FixedUpdate()
    {
        if (cur_state == State.chasing)
        {
            StartCoroutine(Chase());
        }
        else if(cur_state == State.waving)
        {
            Debug.Log("wave");
            if (!is_waving)
            {
                StartCoroutine(Waving());
            }
            
        }

    }
    */
    public void WaveBack()
    {
        if (!is_waving)
        {
            StartCoroutine(Waving());
        }
    }
    public void StartChase()
    {
        StartCoroutine(Chase());
    }

    IEnumerator Chase()
    {
        //switch run1
        sprite.GetComponent<Renderer>().material = run1;
        yield return new WaitForSeconds(0.1f);
        //switch run2
        sprite.GetComponent<Renderer>().material = punch;
        yield return new WaitForSeconds(0.1f);
        //back to default
        StartCoroutine(Chase());
    }

    IEnumerator Waving()
    {
        Debug.Log(annoyance);
        //cur_state = State.idle;
        is_waving = true;
        if (annoyance > 5)
        {
            //set to punch
            cur_state = State.punch;
            this.GetComponent<AudioSource>().Play();
            sprite.GetComponent<Renderer>().material = punch;
            yield break;
        }
        if (annoyance < 2)
        {
            //set to h_wave1
            sprite.GetComponent<Renderer>().material = wave;
            yield return new WaitForSeconds(0.5f);
            annoyance++;
            if(annoyance >= 3)
            {
                //set to annoyed default
                sprite.GetComponent<Renderer>().material = idle_a;
                is_waving = false;
                yield break;
            }
            else
            {
                //set to def
                sprite.GetComponent<Renderer>().material = idle_d;
            }
        }
        else if(annoyance >= 2 && annoyance < 4)
        {
            //set to a_wave1
            sprite.GetComponent<Renderer>().material = wave_a;
            yield return new WaitForSeconds(0.5f);
            annoyance++;
            if (annoyance >= 4)
            {
                //set to irritated default
                sprite.GetComponent<Renderer>().material = idle_i;
                is_waving = false;
                yield break;
            }
            else
            {
                //set to def
                sprite.GetComponent<Renderer>().material = idle_a;
                is_waving = false;
                yield break;
            }
        }
        else if (annoyance >= 4)
        {
            //set to a_wave1
            sprite.GetComponent<Renderer>().material = wave_i;
            yield return new WaitForSeconds(0.5f);
            annoyance++;
            //set to irritated default
            sprite.GetComponent<Renderer>().material = idle_i;
            is_waving = false;
            yield break;
        }
        is_waving = false;
        yield break;
    }
}
