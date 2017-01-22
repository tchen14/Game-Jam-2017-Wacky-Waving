using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class startgame : MonoBehaviour {

    private void OnMouseUp()
    {
        SceneManager.LoadScene(1);
    }

    private void OnMouseDown()
    {
        //StartCoroutine(Quit());
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }

   
}
