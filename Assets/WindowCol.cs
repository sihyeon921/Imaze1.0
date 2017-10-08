using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCol : MonoBehaviour
{
   
    public PhysicsMaterial2D material;
    public Collider2D col;
    public Collider2D colw;
    public Rigidbody2D rig;
    public Vector3 V;
    public Vector3 startposition;
    public GameObject sb;
    public GameObject eb;
    public ColforLand cl;
    public float v;
    public bool on;
    public bool nexton;
    public bool reset;
    // Use this for initialization
    void Start()
    {
        
        col = gameObject.GetComponent<Collider2D>(); //팝업 창 콜라이더
        colw = GameObject.Find("ColForWindows").GetComponent<Collider2D>(); //팝업 창을 밑에서 받쳐주는 콜라이더
        eb = GameObject.Find("ExitWButton");
        sb = GameObject.Find("SaveButton"); //위치(스테이션) 저장하기 버튼
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        rig = gameObject.GetComponent<Rigidbody2D>(); //팝업 창 강체
        material = new PhysicsMaterial2D(); //팝업 창 콜라이더의 바뀔 메터리얼

        startposition = this.transform.position;
        rig.gravityScale = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            this.transform.position = startposition;
            rig.gravityScale = 0;
            rig.velocity = new Vector3(0, 0, 0);
            sb.GetComponent<BoxCollider2D>().enabled = true;
            eb.GetComponent<BoxCollider2D>().enabled = true;
            nexton = false;
            reset = false;
            sb.GetComponent<SaveButton>().pressed = false;
            eb.GetComponent<ExitWButton>().pressed = false;
            colw.isTrigger = false;
        }
        v = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude; //팝업 창의 실시간 속도
        if (on && v < 0.5f) //속도가 0.5 미만이고 강체가 바뀌었으면
        {
            colw.isTrigger = true; //지지대 콜라이더 isTrigger = true(창이 통과되는 상태)
            nexton = true;
            on = false;

            V = this.transform.position; //팝업 창의 현재 위치 저장
            

        }
        if(nexton && !on && !sb.GetComponent<SaveButton>().pressed && !eb.GetComponent<ExitWButton>().pressed)
        {
            rig.gravityScale = 0;
            v = 0; //팝업창의 강체 속도 0
            this.transform.position = V; //팝업창 위치 고정
        }
        if((sb.GetComponent<SaveButton>().pressed || eb.GetComponent<ExitWButton>().pressed) && !reset)
        {
            
            rig.gravityScale = 13;

            cl.wa = false;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "colforwindows") //지지대 콜라이더와 충돌 시
        {
           
            ChangeBounciness(); //메터리얼 교체함수
        }
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "ColForResetW") //지지대 콜라이더와 충돌 시
        {
            reset = true;
            
            rig.gravityScale = 0;
        }

    }
    public void ChangeBounciness()
    {
        col.sharedMaterial = material; //메터리얼 교체
        on = true;
    }
    public void Appear()
    {
       
        rig.gravityScale = 13;
    }
   

}
