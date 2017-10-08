using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour {
    Vector3 v;
    public Renderer coinrender;
    public MeshRenderer numberrender;
    public CoinTrigger cointrigger;
    public ColforCoin state;
    public bool on;
    public bool shading;
    public float t = 0f;

    // Use this for initialization
    void Start () {

        coinrender = GameObject.FindGameObjectWithTag("coinuionplayer").GetComponent<Renderer>();
        numberrender = GameObject.FindGameObjectWithTag("cointextuionplayer").GetComponent<MeshRenderer>();
        cointrigger = GameObject.FindGameObjectWithTag("coin").GetComponent<CoinTrigger>();

        coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, 0.0f);
        numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, 0.0f);

        state = GameObject.FindGameObjectWithTag("colforattain").GetComponent<ColforCoin>();
    }
	
	// Update is called once per frame
	void Update () {
        v = GameObject.FindGameObjectWithTag("Cha1").transform.position;
        if (!on) //움찔 이벤트 중이 아닐 시
        {
            transform.position = v;
            transform.Translate(-42.42f * Time.smoothDeltaTime, 90.1f * Time.smoothDeltaTime, 0);
        }
        if (state.AttainState) //코인에 닿으면
        {
            state.shoot = false;
            StartCoroutine(MovingEvent(0.001f)); //움찔 이벤트 시작
            
            coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, 1);//동전 보임
            numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, 1f); //카운터 보임
            
            


        }
    }
    public IEnumerator MovingEvent(float waitTime) 
    {

        on = true; //움찔 이벤트 시작
        transform.Translate(0, 12.12f * Time.smoothDeltaTime, 0); //살짝 위로 좌표 이동
        yield return new WaitForSeconds(0.02f); //유지
        transform.position = v;
        transform.Translate(-42.42f * Time.smoothDeltaTime, 90.1f * Time.smoothDeltaTime, 0);
        on = false; //움찔 이벤트 끝

        StartCoroutine(ShadingEvent(0.001f));//사라짐 이벤트 시작

    }

    public IEnumerator ShadingEvent(float waitTime)
    {
        
        
        coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, 1);//동전 보임
        numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, 1f); //카운터
       
            yield return new WaitForSeconds(0.8f);
       

        state.AttainState = false;
        shading = true;
      
            for (float a = 1; a >= 0; a -= 0.03f)
            {
            if (state.AttainState)
            
                break;
            
                coinrender.material.color = new Vector4(coinrender.material.color.r, coinrender.material.color.g, coinrender.material.color.b, a);
                numberrender.material.color = new Vector4(numberrender.material.color.r, numberrender.material.color.g, numberrender.material.color.b, a);
                yield return new WaitForFixedUpdate();


            }
            shading = false;
        
        
           
        



        
    }
}
