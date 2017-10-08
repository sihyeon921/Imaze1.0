using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {
    public PauseButton pb;
    public Sprite NextSprite;
    public Sprite CurrentSprite;
    private void OnMouseDown()
    {
        this.transform.Translate(0, -0.3f, 0);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = NextSprite;
    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        Time.timeScale = 1.0f;
        pb.pressed = false;
        this.transform.Translate(0, 0.3f, 0);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<Renderer>().material.color =
            new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r,
            this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 0f);
        gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        CurrentSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        pb = GameObject.Find("PauseButton").GetComponent<PauseButton>();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<Renderer>().material.color =
             new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r,
             this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 0f);
        
    }
    
	
	// Update is called once per frame
	void Update () {
        if (pb.pressed)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<Renderer>().material.color =
                 new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r,
                 this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 1f);
        }
    }
}
