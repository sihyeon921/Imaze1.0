using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heallight : MonoBehaviour {

    public Renderer heallight;
    public GiveEnergy2Player gep;
    public CalDistancePlayer cdp;
    public SavingCoinCounterUI sccu;
    public WindowCol wc;
    public ColforLand cl;
    public CharacterData cd;
    public CharMove cm;
    public SaveButton sb;
    public SootingCoinsToUI sctu;
    public GameObject asct;
    public GameObject A;
    Vector3 v;
    public float fulltime;
    public float lefttime;
    public bool stop;
    public bool lighting;
    public bool keeping;
    public bool keepingdone;
    public bool shading;
    public bool golightkeep;
    public bool callwa;


    // Use this for initialization
    void Awake()
    {
        heallight.material.color = new Vector4(heallight.material.color.r, heallight.material.color.g, heallight.material.color.b, 0.0f);
    }
    void Start () {
        heallight = GameObject.FindGameObjectWithTag("effect").GetComponent<Renderer>();
        gep = GameObject.FindGameObjectWithTag("station").GetComponent<GiveEnergy2Player>();
        cdp = GameObject.FindGameObjectWithTag("stationpoint").GetComponent<CalDistancePlayer>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        sccu = GameObject.Find("SavingCoinCounter").GetComponent<SavingCoinCounterUI>();
        wc = GameObject.Find("GameSaveWindow").GetComponent<WindowCol>();
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        sb = GameObject.Find("SaveButton").GetComponent<SaveButton>();
        sctu = GameObject.Find("CoinShooter").GetComponent<SootingCoinsToUI>();
        asct = GameObject.Find("AddOrSubCoinsText");
        A = GameObject.FindGameObjectWithTag("legpoint");

        v = this.transform.position;
        callwa = true;
    }
	
	// Update is called once per frame
	void Update () {

        
        if (!lighting && !cd.Dead && !stop && cdp.distance <= 1.0f && cm.gravity == 0.0f && !cm.PresKey  && v != A.transform.position) //캐릭터가 완전히 스테이션에 멈추었는지 확인
        {
            
            //cl.wa = true;
            v = A.transform.position;
            if (cd.coins != 0)
            {
                sccu.savingcoins = cd.coins;
                asct.GetComponent<AddSubCoinsText>().addsubcoins = cd.coins;
            }
            StartCoroutine("LightingEvent");//사라짐 이벤트 시작
           
        }
        if(cl.wa)
        {
            if (golightkeep && lighting && !keeping)
                StartCoroutine("KeepingEvent");
            
        }
        else
        {
            if(lighting && !keeping)
                StartCoroutine("KeepingEvent");
        }
        
        if(lighting && keepingdone && !shading  && !sctu.on)
            StartCoroutine("ShadingEvent");
        if (cm.gravity > 0)
        {
            if(!keeping)
            {
                
            }

         
            stop = false;
            
        }
       
          
       
            
       
     




    }
    public IEnumerator LightingEvent()
    {

        stop = true;
        lighting = true;
        for (float a = 0; a <= 1; a += 0.06f)
        {
            heallight.material.color = new Vector4(heallight.material.color.r, heallight.material.color.g, heallight.material.color.b, a);
            yield return new WaitForFixedUpdate();
        }
        
        heallight.material.color = new Vector4(heallight.material.color.r, heallight.material.color.g, heallight.material.color.b, 1);
        if (cl.wa)
        {
            
            wc.Appear(); //팝업 창 내리기
           
        }
        
       
    }
    public IEnumerator KeepingEvent()
    {
        keeping = true;
        if (cd.coins > 0 && cl.g.occup)
        {
            for (int a = 0; a < cd.coins; a++)
                yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(0.6f); //유지
        keepingdone = true;
        golightkeep = false;
    }
    public IEnumerator ShadingEvent()
    {
        shading = true;
        for (float a = 1; a >= 0; a -= 0.06f)
        {
            heallight.material.color = new Vector4(heallight.material.color.r, heallight.material.color.g, heallight.material.color.b, a);
            yield return new WaitForFixedUpdate();
        }
        heallight.material.color = new Vector4(heallight.material.color.r, heallight.material.color.g, heallight.material.color.b, 0);

         lighting =false;
    keeping = false;
        keepingdone = false;
        shading = false;
    }
}
