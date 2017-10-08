using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour {

    public float MaxEnergy = 100;
    public float Energy; //캐릭터 에너지 수치
    public float GainEnergy; //캐릭터 에너지 수치
    public int coins; //현재 씬(스테이지)에서 캐릭터가 얻은 코인
    public bool Dead;
    public CharMove cm;
    public BackLight bl;
    public PauseButton pb;

    // Use this for initialization
    void Start () {
        coins = 0;
        Energy = 100f;
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        bl = GameObject.Find("backlight").GetComponent<BackLight>();
        pb = GameObject.Find("PauseButton").GetComponent<PauseButton>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Energy >= MaxEnergy) //에너지가 100이 넘어갈 때는
        {
            Energy = MaxEnergy; //100으로 정의
            GainEnergy = 0;
        }
        if (Energy < 0) //에너지가 0보다 작을 때는
            Energy = 0; //0으로 정의
        if (Energy == 0)
            Dead = true;
        if (cm.PresKey && !pb.pressed)  //이동 키가 입력되었을 때
        {
            if(!bl.on)
            StartCoroutine(UsingEnergy(0.001f)); //에너지를 감소시킨다
        }
        if(!Dead && GainEnergy > 0)
            StartCoroutine(SaveEnergy(0.001f)); //에너지를 증가시킨다
        if (GainEnergy > 100)
            GainEnergy = 100;

    }
    public IEnumerator UsingEnergy(float waitTime) //에너지를 지속적으로 감소시키는 함수
    {
        Energy -= 0.04f; //에너지 감소 -0.04f
            yield return new WaitForFixedUpdate();
    }
    public IEnumerator SaveEnergy(float waitTime) //에너지를 증가 시키는 함수
    {
        GainEnergy -= 2.0f; //에너지 감소 -0.04f
        Energy += 2.0f; //에너지 감소 -0.04f
        yield return new WaitForFixedUpdate();
    }
}
