using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LegMove : MonoBehaviour {

    public CharMove cm;
    public PauseButton pb;
    Vector3 v;
	// Use this for initialization
	void Start () {
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        pb = GameObject.Find("PauseButton").GetComponent<PauseButton>();

    }
	
	// Update is called once per frame
	void Update () {
        v = GameObject.FindGameObjectWithTag("point").transform.position;
        transform.position = v;

        if(!pb.pressed)
        {
            if (cm.R)
        {
            if ((transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 315f) || (Math.Abs(transform.eulerAngles.z) >= 0 && transform.eulerAngles.z < 45.0f))
                RotateRight();
        }
        else
        {
            if (transform.rotation.z < 0)
                transform.Rotate(Vector3.forward * +1.0f);
        }
        if (cm.L)
        {
            if ((transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 315f) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 45.0f))
                RotateLeft();
        }
        else
        {
            if (transform.rotation.z > 0)
                transform.Rotate(Vector3.forward * -1.0f);
        }

        if (cm.rightboost * Time.timeScale - cm.leftboost * Time.timeScale < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void RotateRight()
    {

        transform.Rotate(Vector3.forward * -0.8f);
    }
    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * 0.8f);
    }
}
