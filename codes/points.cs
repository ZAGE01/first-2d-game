using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class points : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0f;
    public int collectibles = 0;

    private GameObject t1 = null;
    private GameObject t2 = null;

    void Start()
    {
        this.t1 = GameObject.Find("teksti1");
        this.t2 = GameObject.Find("teksti2");
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        this.t2.GetComponent<Text>().text = "Timer: " + this.timer.ToString("0.00");
        this.t1.GetComponent<Text>().text = "Collectibles: " + this.collectibles;
        PlayerPrefs.SetFloat("aika", this.timer);
        PlayerPrefs.SetInt("collected", this.collectibles);
    }
}
