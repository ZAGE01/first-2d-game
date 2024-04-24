using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class statistics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Getting time and collectibles and printing them
        float time = PlayerPrefs.GetFloat("aika");
        int collected = PlayerPrefs.GetInt("collected");
        GameObject.Find("time").GetComponent<TextMeshPro>().text = "Time: " + time.ToString("0.00") + " seconds";
        GameObject.Find("collectibleText").GetComponent<TextMeshPro>().text = "Collectibles: " + collected + "/5";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
