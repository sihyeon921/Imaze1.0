using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingCoinCounterUI : MonoBehaviour {
    public int savingcoins;
    public TextMesh savingcoinTextMesh;
    public PauseCtrl pc;
    public SaveButton sb;
    public SootingCoinsToUI sctu;
    public bool showing;
    public bool keeping;
    public bool keepingdone;
    public bool shading;
    // Use this for initialization
    void Start () {
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
        sb = GameObject.Find("SaveButton").GetComponent<SaveButton>();
        sctu = GameObject.Find("CoinShooter").GetComponent<SootingCoinsToUI>();
    }
	
	// Update is called once per frame
	void Update () {
        savingcoinTextMesh.text = string.Format("{0}", savingcoins);
        if (pc.stop && savingcoins != 0 && sctu.on) //
        {
            showing = false;
            keeping = false;
            keepingdone = false;
            shading = false;
            StartCoroutine("ShowingEvent");

        }
            if (showing && !keeping)
                StartCoroutine("KeepingEvent");
        if (showing && keepingdone && !shading)
        {
            StartCoroutine("ShadingEvent");
            
        }
        
    }

    public IEnumerator ShowingEvent() //나타나는 이벤트
    {
        
        while (gameObject.transform.localScale.x < 0.3f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 69.69f * Time.deltaTime, gameObject.transform.localScale.y * 69.69f * Time.deltaTime, gameObject.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
        showing = true;
    }

    public IEnumerator KeepingEvent() //유지하는 이벤트
    {
        keeping = true;
        yield return new WaitForSeconds(3f); //유지
        keepingdone = true;
    }

    public IEnumerator ShadingEvent() //사라지는 이벤트
    {
        
        while (gameObject.transform.localScale.y > 0.001f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y - 0.006f * Time.deltaTime, gameObject.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        
        shading = true;
    }
}
