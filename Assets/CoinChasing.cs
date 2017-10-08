using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinChasing : MonoBehaviour {

    public GameObject targetObject; //추적할 오브젝트
    Vector3 posTarget; //추적할 목표 좌표
    public float rotateVt = 360f; //z축 회전율
    public float speed = 5.0f; //물체(코인) 초기 속도
    public float speedA; //물체 가속도
    public float homingAngle; //순간 호밍 각도
    public float homingAngleV; //호밍 각도 변화량
    public float homingAngleA = 20.0f; //호밍 각도 변화 가속도
    public float homingTime;
    public float fireTime;
    public float angle = 0; //직선 이동 시 각도 변화량
    bool right; //물체 기준으로 물체 오른쪽으로 회전하며 호밍하는가
    bool left; //물체 기준으로 물체 왼쪽으로 회전하며 호밍하는가
    bool straight; //물체가 회전없이 직선 방향으로 호밍하는가
    public Quaternion homingRotate; //순간 호밍 각도
    public CoinUIOnLeftTop cuolt;

	// Use this for initialization
	void Start () {
        targetObject = GameObject.FindGameObjectWithTag("coinuionlefttop"); //추적할 오브젝트
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        posTarget = targetObject.transform.position + new Vector3(0, 0, 0); //추적할 오브젝트의 좌표를 받아옴

        fireTime = Time.fixedTime;

        float anispeed = Random.Range(0.7f, 1); //0.7~1 사이의 랜덤값을
        this.gameObject.GetComponent<Animator>().speed = anispeed; //생성될 물체(동전)의 애니메이션 재생 속도로 선언

        int random = Random.Range(0, 100); //랜덤값을 이용, 1.오른쪽 2.왼쪽 3.직선 방향으로 이동할 지 정한다 
        homingAngleV = Random.Range(300, 500); //랜덤값을 이용, 호밍 각도 변화량을 정한다
        speedA = Random.Range(40, 60); //랜덤값을 이용, 초기 이동속도를 정한다

        if (random >= 0 && random <= 33) //왼족 회전 이동시
        {
            left = true;
            right = false;
            straight= false; 
            homingAngle = 90.0f;

        }
        else if (random >= 34 && random <= 66) //오른쪽 회전 이동시
        {
            left = false;
            right = true;
            straight = false;
            homingAngle = 0.0f;
        }
        else
        {
            left = false;
            right = false;
            straight = true;
        }
        if (straight) //직선 이동시
        {
            int random1 = Random.Range(300, 350);
            speedA += random1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, Time.deltaTime * rotateVt); //시간에 따라 물체가 회전
   
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        
            if (col.CompareTag("coinuionlefttop")) //목표 오브젝트와 만나면
            {

            Destroy(gameObject); //물체(코인) 오브젝트 파괴

            }
    }
    void FixedUpdate()
    {
            if (left) //왼쪽 회전 이동시
            {
                posTarget = targetObject.transform.position + new Vector3(0, 0, 0); //목표 오브젝트 좌표 받아옴
                float targetAnlge = Mathf.Atan2(  //목표 좌표를 바탕으로 목표와의 각도 구하기
                    posTarget.y - transform.position.y,
                    posTarget.x - transform.position.x) * Mathf.Rad2Deg; 
                float deltaAngle = Mathf.DeltaAngle(targetAnlge, homingAngle); //목표와의 각도와 현재 호밍각도의 차이 구하기
                float deltaHomingAngle = homingAngleV * Time.fixedDeltaTime; //호밍 각도 변화량
                if (Mathf.Abs(deltaAngle) >= deltaHomingAngle) //호밍각도 조정
                {
                    homingAngle += (deltaAngle < 0.0f) ?
                        -deltaHomingAngle : +deltaHomingAngle;
                }
                homingAngleV += (homingAngleA * Time.fixedDeltaTime);
                homingRotate = Quaternion.Euler(0, 0, homingAngle); //조정된 호밍각도만큼 물체 회전
                this.GetComponent<Rigidbody2D>().velocity = (homingRotate * Vector3.left) * speed; //물체 움직임 구현
            }
            else if (right) //오른쪽 회전 이동시
            {
                posTarget = targetObject.transform.position + new Vector3(0, 0, 0);
                float targetAnlge = Mathf.Atan2(
                    posTarget.y - transform.position.y,
                    posTarget.x - transform.position.x) * Mathf.Rad2Deg;
                float deltaAngle = Mathf.DeltaAngle(targetAnlge, homingAngle);
                float deltaHomingAngle = homingAngleV * Time.fixedDeltaTime;
                if (Mathf.Abs(deltaAngle) >= deltaHomingAngle)
                {
                    homingAngle += (deltaAngle < 0.0f) ?
                        +deltaHomingAngle : -deltaHomingAngle;
                }
                homingAngleV += (homingAngleA * Time.fixedDeltaTime);
                homingRotate = Quaternion.Euler(0, 0, homingAngle);
            this.GetComponent<Rigidbody2D>().velocity = (homingRotate * Vector3.right) * speed;
            }
            else if (straight) //직선 이동시
            {
                homingRotate = Quaternion.LookRotation( //목표 좌표와 현재 물체 좌표를 이용해 호밍각도 구하기
                    posTarget - transform.position);
                Vector3 vecMove = (homingRotate * Vector3.forward) * speed;
            this.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, angle) * vecMove;
            }

            speed += speedA * Time.fixedDeltaTime; //시간에 따라 속도가 증가
        
    }
}
