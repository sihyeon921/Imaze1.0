using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCtrl : MonoBehaviour { //정지 시 일부만 정지하게 만드는 스크립트
    public Heallight hl;
    public bool stop;
    public float StartTime;
    public float StartTime2;
    public float second; //deltatime을 대체(=Time.deltatime). Time.deltatime == 0이면 모든 오브젝트가 정지되기 때문
    public SootingCoinsToUI sctu;
    public PauseButton pb;
    public ColforLand cl;
    public SaveButton sb;
    public ExitWButton ewb;
    public CreateBlocks cb;
    public float stoptime;
    public float tmp;
    public Vector3 stopv;
    public bool Do;
    public bool why;
    public int sctuon = 0;
    // Use this for initialization
    void Start () {
        hl = GameObject.FindGameObjectWithTag("effect").GetComponent<Heallight>();
        sctu = GameObject.Find("CoinShooter").GetComponent<SootingCoinsToUI>();
        pb = GameObject.Find("PauseButton").GetComponent<PauseButton>();
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        sb = GameObject.Find("SaveButton").GetComponent<SaveButton>();
        ewb = GameObject.Find("ExitWButton").GetComponent<ExitWButton>();
        cb = GameObject.Find("MazeCreator").GetComponent<CreateBlocks>();

    } 
	
	// Update is called once per frame
	void Update () { 
        if(cl.wa)
            sctuon++;
        else
            sctuon = 0;
        if (!sctu.on && !cl.wa) //save 버튼이 눌리고 동전 보내기가 끝나면
        {
            stop = false;

            if (gameObject.GetComponent<Animator>() != null)
            {
                gameObject.GetComponent<Animator>().speed = 1; //애니메이션 평소 속도
            }
            // sb.pressed = false;
        }
        if (pb.pressed ) //일시정지 버튼이 눌리면
        {
            stoptime = StartTime;
            tmp = Time.realtimeSinceStartup - stoptime;
            stopv = gameObject.transform.position;
            Do = true;
            second = 0; //deltatime = 0
            
            
            
        }
        
        if ((sctu.on && hl.heallight.material.color.a >= 0.99f) || (cl.wa && hl.heallight.material.color.a >= 0.99f)) //캐릭터가 정거장에 도착하여 이벤트들이 시작되면
        {
          
            why = true;
            
            stoptime = StartTime;
            tmp = Time.realtimeSinceStartup - stoptime;
            stop = true;
            stopv = gameObject.transform.position;
            Do = true;
            second = 0; //Time.deltatime = 0;

            if (gameObject.GetComponent<Animator>() != null)
            {
                gameObject.GetComponent<Animator>().speed = 0; //애니메이션 정지

            }
        }
        else if(cl.wa && !(hl.heallight.material.color.a >= 0.99f))
        {
            stop = false;
            why = false;
            if (gameObject.GetComponent<Animator>() != null)
            {
                gameObject.GetComponent<Animator>().speed = 1; //애니메이션 평소 속도
            }
        }
       
        if (!stop && !pb.pressed ) //일시 정지가 아닐시
        {

            if (Do)
            {
                gameObject.transform.position = stopv;
                StartTime = tmp;
                
                Do = false;
            }
            second = Time.realtimeSinceStartup - StartTime - stoptime; //deltatime값 계산
            StartTime = Time.realtimeSinceStartup - stoptime;
           


        }
    }
}
