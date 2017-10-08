using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class charanim : MonoBehaviour {
    public bool L;
    public bool R;
    public bool PresKey;
    public float leftboost;
    public float rightboost;
    public float upboost;
    public float gravity;
    public float rot;
    public float check;
    




    // Use this for initialization
    void Start () {
        L = false;
        R = false;
        PresKey = false;
        leftboost = 0.0f;
        rightboost = 0.0f;
        upboost = 0.0f;
        gravity = 0.07f;
        rot = 0.0f;
        check = 0.0f;
     


    }

    // Update is called once per frame
    void Update()
    {
        check = transform.eulerAngles.z;
        
        if ((Input.GetKey(KeyCode.RightArrow)))
        {
            PresKey = true;
            if ((transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 335f) || (Math.Abs(transform.eulerAngles.z) >= 0 && transform.eulerAngles.z < 25.0f))
                RotateRight();
            if (rightboost < 0.07f)
                rightboost = rightboost + 0.003f;
            if (upboost < 0.14f)
                upboost = upboost + 0.003f;
            if (leftboost > 0)
                leftboost = leftboost - 0.003f;
        }
        else
        {
            if (transform.rotation.z < 0)
                transform.Rotate(Vector3.forward * +0.5f);

        }



        if ((Input.GetKey(KeyCode.LeftArrow)))
        {
            PresKey = true;
            if ((transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 335f) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 25.0f))
                RotateLeft();
            if (leftboost < 0.07f)
                leftboost = leftboost + 0.003f;
            if (upboost < 0.14f)
                upboost = upboost + 0.003f;
            if (rightboost > 0)
                rightboost = rightboost - 0.003f;
        }
        else
        {
            if (transform.rotation.z > 0)
                transform.Rotate(Vector3.forward * -0.5f);
            

        }

        if ((Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.RightArrow))) //왼쪽 오른쪽 이동 키를 모두 눌렀을 때
        {
            if (upboost < 0.18f)
                upboost = upboost + 0.0005f;
        }
            if (!(Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.RightArrow))) //캐릭터 이동에 대한 아무 입력이 없을 때
        {
            PresKey = false;
            if (upboost > 0)
                upboost = upboost - 0.003f;
        }
        if (rightboost * Time.timeScale - leftboost * Time.timeScale < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        transform.Translate(rightboost * Time.timeScale - leftboost * Time.timeScale, upboost*Time.timeScale - gravity * Time.timeScale, 0);
        
        
        
    }
    void RotateRight()
    {
       
        transform.Rotate(Vector3.forward * -0.5f);
    }
    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * 0.5f);
    }
}
