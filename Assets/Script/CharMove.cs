using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CharMove : MonoBehaviour {
    public bool L;
    public bool R;
    public bool PresKey;
    public float leftboost;
    public float rightboost;
    public float upboost;
    public float gravity;
    public float rot;
    public float check;
    public CharacterData cd;
    public ColforLand cl;
    public CalDistancePlayer cdp;
    public Heallight hl;
    public float Rt = 1.25f;
    public float StartTime;
    public float second;
    public bool stop;
    public PauseCtrl pc;
    public PauseButton pb;
    public float cha;

   




    // Use this for initialization
    void Start () {
        L = false;
        R = false;
        PresKey = false;
        leftboost = 0.0f;
        rightboost = 0.0f;
        upboost = 0.0f;
        gravity = 4f * Rt; //0.07
        rot = 0.0f;
        check = 0.0f;
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        cl = GameObject.FindGameObjectWithTag("legcol").GetComponent<ColforLand>();
        cdp = GameObject.FindGameObjectWithTag("stationpoint").GetComponent<CalDistancePlayer>();
        hl = GameObject.FindGameObjectWithTag("effect").GetComponent<Heallight>();
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
        pb = GameObject.Find("PauseButton").GetComponent<PauseButton>();


        StartTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
       
        


            second = pc.second;

            cha = rightboost - leftboost;
            if (pb.pressed)
            {

            }
            if (cl.on)
            {
                if (PresKey || cdp.distance > 1.0f)
                {
                    cl.on = false;
                    gravity = 4f * Rt;
                }
                StartCoroutine(ReduceGravity(0.001f));
                StartCoroutine(ReduceBoost(0.001f));

            }


            check = transform.eulerAngles.z;


            if (!cd.Dead && !pc.stop && !pb.pressed)
            {


                if ((Input.GetKey(KeyCode.RightArrow))) //오른쪽 키를 누르면
                {

                    R = true;
                    PresKey = true;
                    if ((transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 335f) || (Math.Abs(transform.eulerAngles.z) >= 0 && transform.eulerAngles.z < 25.0f))
                        RotateRight();
                    if (rightboost < 4f * Rt)
                        rightboost = rightboost + 0.17f * Rt;
                    if (upboost < 8f * Rt)
                        upboost = upboost + 0.17f * Rt;
                    if (leftboost > 0)
                        leftboost = leftboost - 0.17f * Rt;
                }
                else
                {

                    R = false;
                    if (transform.rotation.z < 0)
                        transform.Rotate(Vector3.forward * +0.5f);

                }



                if ((Input.GetKey(KeyCode.LeftArrow)))
                {
                    L = true;
                    PresKey = true;
                    if ((transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 335f) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 25.0f))
                        RotateLeft();
                    if (leftboost < 4f * Rt)
                        leftboost = leftboost + 0.17f * Rt;
                    if (upboost < 8f * Rt)
                        upboost = upboost + 0.17f * Rt;
                    if (rightboost > 0)
                        rightboost = rightboost - 0.17f * Rt;
                }
                else
                {
                    L = false;
                    if (transform.rotation.z > 0)
                        transform.Rotate(Vector3.forward * -0.5f);


                }

                if ((Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.RightArrow))) //왼쪽 오른쪽 이동 키를 모두 눌렀을 때
                {
                    L = true;
                    R = true;
                    PresKey = true;
                    if (upboost < 10.3f * Rt)
                        upboost = upboost + 0.003f * Rt;
                }
            }
            if ((!(Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.RightArrow))) || cd.Dead) //캐릭터 이동에 대한 아무 입력이 없을 때
            {
                L = false;
                R = false;
                PresKey = false;
                if (!pb.pressed)
                {

                    if (upboost > 0)
                        upboost = upboost - 0.17f * Rt;
                }
            }
            if (rightboost * second - leftboost * second < 0.02)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);

            transform.Translate(rightboost * second - leftboost * second, upboost * second - gravity * second, 0);

        
        
    }
    void RotateRight()
    {
       
        transform.Rotate(Vector3.forward * -0.5f);
    }
    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * 0.5f);
    }

    public IEnumerator ReduceGravity(float waitTime) //에너지를 지속적으로 감소시키는 함수
    {
        if (gravity > 0)
        {
            
            gravity -= 0.114f * Rt; //에너지 감소 -0.04f
            yield return new WaitForFixedUpdate();
        }
        else
            gravity = 0f;
    }
    public IEnumerator ReduceBoost(float waitTime) //에너지를 지속적으로 감소시키는 함수
    {
        if (rightboost - leftboost > 0)
        {

            rightboost -= 0.114f * Rt; //에너지 감소 -0.04f
            yield return new WaitForFixedUpdate();
        }
        else if (rightboost - leftboost < 0)
        {

            leftboost -= 0.114f * Rt; //에너지 감소 -0.04f
            yield return new WaitForFixedUpdate();
        }
        if(rightboost < 0)
            rightboost = 0f;
        if (leftboost < 0)
            leftboost = 0f;
    }
}
