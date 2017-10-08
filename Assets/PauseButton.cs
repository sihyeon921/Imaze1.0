using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {
    public PauseCtrl pc;
    public PlayButton pb;
    public PauseScreen ps;
    public bool pressed;
    

    private void OnMouseDown()
    {
        this.transform.Translate(0, -0.3f, 0);
       
    }
    private void OnMouseUp()
    {
        pb.gameObject.SetActive(true);
        ps.gameObject.SetActive(true);
        Time.timeScale = 0;
        pressed = true;
        this.transform.Translate(0, 0.3f, 0);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    // Use this for initialization
    void Start () {
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
        pb = GameObject.Find("PlayButton").GetComponent<PlayButton>();
        ps = GameObject.Find("PauseScreen").GetComponent<PauseScreen>();
    }
	
	// Update is called once per frame
	void Update () {
		if(!pressed)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
	}
}
