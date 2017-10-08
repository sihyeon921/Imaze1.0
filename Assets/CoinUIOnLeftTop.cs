using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUIOnLeftTop : MonoBehaviour {

    public float totalcoins;
    public Transform cointrans;
    public Renderer coinrender;
    public MeshRenderer numberrender;
    public MeshRenderer addsubnumberrender;
    public Heallight hl;
    public GiveEnergy2Player gep;
    public CalDistancePlayer cdp;
    public CharacterData cd;
    public CharMove cm;
    public SaveButton sb;
    public GameObject A;
    public AddSubCoinsText asct;
    public PauseCtrl pc;
    public ColforLand cl;
    public ExitWButton ewb;
    Vector3 v;
    public float fulltime;
    public float lefttime;
    public bool stop;
    public bool lighting;
    public bool keeping;
    public bool keepingdone;
    public bool shading;
    public bool hitted;
    public bool lighton;
    // Use this for initialization
    void Start () {
        cointrans = GameObject.FindGameObjectWithTag("coinuionlefttop").GetComponent<Transform>();
        coinrender = GameObject.FindGameObjectWithTag("coinuionlefttop").GetComponent<Renderer>();
        numberrender = GameObject.FindGameObjectWithTag("cointextuionlefttop").GetComponent<MeshRenderer>();
        addsubnumberrender = GameObject.Find("AddOrSubCoinsText").GetComponent<MeshRenderer>();
        gep = GameObject.FindGameObjectWithTag("station").GetComponent<GiveEnergy2Player>();
        cdp = GameObject.FindGameObjectWithTag("stationpoint").GetComponent<CalDistancePlayer>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        sb = GameObject.Find("SaveButton").GetComponent<SaveButton>();
        asct = GameObject.Find("AddOrSubCoinsText").GetComponent<AddSubCoinsText>();
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        A = GameObject.FindGameObjectWithTag("legpoint");
        ewb = GameObject.Find("ExitWButton").GetComponent<ExitWButton>();
        v = this.transform.position;

        coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, 0f);
        numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, 0f);
        addsubnumberrender.material.color = new Vector4(addsubnumberrender.material.color.r, addsubnumberrender.material.color.g, addsubnumberrender.material.color.b, 0f);

        totalcoins = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (numberrender.material.color.a == 1.0f)
            lighton = true;
        if(hitted)
        {
            StartCoroutine("HittedEvent");
        }
        if ( pc.stop && !cd.Dead && !stop && cdp.distance <= 1.0f && cm.gravity == 0.0f && !cm.PresKey  && v != A.transform.position) //캐릭터가 완전히 스테이션에 멈추었는지 확인
        {
            lighting = false;
            keeping = false;
            keepingdone = false;
            shading = false;
            v = A.transform.position;

            LightingEvent();//보이게 하기
          
        }
        if (!(cl.g == null))
        {
            if (cl.g.occup)
            {
                if (cd.coins == 0 && lighting && !keeping && !pc.stop)
                {

                    StartCoroutine("KeepingEvent");
                }
            }
            else
            {
                if (lighting && !keeping && !pc.stop)
                    StartCoroutine("KeepingEvent");
            }
        }
        if(lighting && keepingdone & !shading)
        {
            StartCoroutine("ShadingEvent");
        }
        if (cm.gravity > 0)
        {
            
            stop = false;
        }
    }
    public void LightingEvent() //보이게 하는 효과
    {
        stop = true;
        lighting = true;
        coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, 1.0f);
        numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, 1.0f);
       
         
        
    }
    public IEnumerator KeepingEvent() //보이는 현상 유지
    {
       
            keeping = true;
            yield return new WaitForSeconds(3f); //유지
            keepingdone = true;
        
    }
    public IEnumerator ShadingEvent() //사라지는 효과
    {
        lighton = false;
        shading = true;
        for (float a = 1; a >= 0; a -= 0.02f)
        {
            coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, a);
            numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, a);
            
            yield return new WaitForFixedUpdate();
        }
        coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, 0.0f);
        numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, 0.0f);
        ewb.forasct = false;

    }
    public IEnumerator HittedEvent()
    {

        cointrans.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);


        yield return new WaitForSeconds(0.02f); //유지
        cointrans.transform.localScale = new Vector3(1f, 1f, 1f);
        hitted = false;

    }
}
