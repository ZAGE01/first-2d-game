using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class introTextBlink : MonoBehaviour
{
    private GameObject text = null;
    private float blinkTimer = 0f;
    private float blinkInterval = 0.7f;
    private bool visible = true;
    // Start is called before the first frame update
    void Start()
    {
        this.text = GameObject.Find("introText");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the scene is the intro scene
        if (SceneManager.GetActiveScene().name == "intro")
        {
            // Toggle text visibility based on the blink interval
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= blinkInterval)
            {
                visible = !visible;
                this.text.SetActive(visible);
                blinkTimer = 0f; // Reset the timer
            }
        }

    }
}
