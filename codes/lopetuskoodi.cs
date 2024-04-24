using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lopetuskoodi : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            Application.Quit();
        }
    }
}
