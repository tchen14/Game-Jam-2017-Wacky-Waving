using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onscreenbutton : MonoBehaviour
{
    public GameObject player;
    public Material up, down;
    private float counter = 100;
    void OnMouseDown()
    {
        if (counter >= 50)
        {
            counter = 0;
            this.GetComponent<Renderer>().material = down;
            this.GetComponent<AudioSource>().Play();
            StartCoroutine(Wave());
        }
        

    }
 
    void OnMouseUp()
    {
        //change texture to normal
        this.GetComponent<Renderer>().material = up;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter >= 50)
            {
                counter = 0;
                StartCoroutine(Wave());
                this.GetComponent<AudioSource>().Play();
            }
        }
        counter++;
    }
    IEnumerator Wave()
    {
        //change texture to pressed
        player.GetComponent<wave>().is_waving = true;
        player.GetComponent<wave>().currently_waving = true;
        GameObject background = GameObject.FindGameObjectWithTag("background");
        background.GetComponent<infinitebackground>().moveable = false;
        yield return new WaitForSeconds(.75f);
        background.GetComponent<infinitebackground>().moveable = true;
    }
}
