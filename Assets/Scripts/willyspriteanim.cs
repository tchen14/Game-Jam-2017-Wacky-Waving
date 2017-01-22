using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class willyspriteanim : MonoBehaviour {
    private float anim_timer = 0;
    public Material[] lib = new Material[6];

	void FixedUpdate () {
        anim_timer++;

        if (anim_timer == 5)
        {
            this.GetComponent<Renderer>().material = lib[1];

        }
        if (anim_timer == 10)
        {
            this.GetComponent<Renderer>().material = lib[2];

        }
        if (anim_timer == 15)
        {
            this.GetComponent<Renderer>().material = lib[3];
          
        }
        if (anim_timer == 20)
        {
            this.GetComponent<Renderer>().material = lib[4];

        }
        if (anim_timer == 25)
        {
            this.GetComponent<Renderer>().material = lib[5];

        }
        if (anim_timer == 30)
        {
            this.GetComponent<Renderer>().material = lib[4];

        }
        if (anim_timer == 35)
        {
            this.GetComponent<Renderer>().material = lib[3];

        }
        if (anim_timer == 40)
        {
            this.GetComponent<Renderer>().material = lib[0];
            
        }
        if (anim_timer == 45)
        {
            this.GetComponent<Renderer>().material = lib[1];

        }
        if (anim_timer == 50)
        {
            this.GetComponent<Renderer>().material = lib[2];

        }
        if (anim_timer == 55)
        {
            this.GetComponent<Renderer>().material = lib[0];
           
        }
        if (anim_timer == 60)
        {
            this.GetComponent<Renderer>().material = lib[1];

        }
        if (anim_timer == 65)
        {
            this.GetComponent<Renderer>().material = lib[2];

        }
        if (anim_timer == 70)
        {
            this.GetComponent<Renderer>().material = lib[0];
            
        }
        if (anim_timer == 75)
        {
            this.GetComponent<Renderer>().material = lib[1];

        }
        if (anim_timer == 80)
        {
            this.GetComponent<Renderer>().material = lib[2];

        }
        if (anim_timer == 85)
        {
            this.GetComponent<Renderer>().material = lib[0];
            anim_timer = 0;
      
        }
    }
}
