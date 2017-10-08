using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveEnergy2Player : MonoBehaviour {
    public bool on;
    public bool dist;
    public bool grav;
    public bool key;
    public CalDistancePlayer cdp;
    public CharacterData cd;
    public CharMove cm;
    public GameObject position;
    public CoinUIOnLeftTop cuolt;
    Vector3 v;
    // Use this for initialization
    void Start()
    {
        cdp = GameObject.FindGameObjectWithTag("stationpoint").GetComponent<CalDistancePlayer>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        position = GameObject.FindGameObjectWithTag("legpoint");

        v = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdp.distance <= 1.0f && cm.gravity == 0.0f && !cm.PresKey && v != position.transform.position) //캐릭터가 완전히 스테이션에 멈추었는지 확인
        {
            
            
            v = position.transform.position; //현재 캐릭터의 좌표를 v에 저장(캐릭터의 현재 위치가 이전 위치와 달라야 에너지가 충전되게 하기 위함)

            cd.GainEnergy = cd.MaxEnergy - cd.Energy; //없는 에너지 양만큼 GainEnergy에 충전
            
            
         
            }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("legcol"))
        {
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {

       
    
            
       
    }
}
