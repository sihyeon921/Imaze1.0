using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour {

    public PauseButton pb;
   

    // Use this for initialization
    void Start () {
        
        pb = GameObject.Find("PauseButton").GetComponent<PauseButton>();

        this.gameObject.GetComponent<Renderer>().material.color = 
            new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r, 
            this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 0f);
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       if(GameObject.Find("PlayButton") == null)
            gameObject.SetActive(false);
       else
            gameObject.SetActive(true);
        if (pb.pressed)
            this.gameObject.GetComponent<Renderer>().material.color =
           new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r,
           this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 0.4f);
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color =
           new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r,
           this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 0.0f);
        }
    }
}

