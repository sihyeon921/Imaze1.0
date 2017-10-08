using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSubCoinsText : MonoBehaviour {

    public bool Add;
    public bool Sub;
    public TextMesh addorsubcointext;
    public CoinUIOnLeftTop cuolt;
    public PauseCtrl pc;
    public ExitWButton ewb;
    public int addsubcoins;
    // Use this for initialization
    void Start () {
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        ewb = GameObject.Find("ExitWButton").GetComponent<ExitWButton>();
        addorsubcointext = gameObject.GetComponent<TextMesh>();
	}

    // Update is called once per frame
    void Update() {
       
        if (addsubcoins > 0 && cuolt.lighton && !ewb.forasct) //얻은 코인이 있고 옆에 토탈코인 숫자가 뜨면
        {
            Add = true;

        }
        else //얻은 코인이 없다면
            Add = false;
        if (!Add ) //얻은 코인이 없다면
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(gameObject.GetComponent<MeshRenderer>().material.color.r,
                gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, 0f); //투명화
            
        }
        
		if(Add)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(gameObject.GetComponent<MeshRenderer>().material.color.r,
                    gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, 1f); //투명화

            addorsubcointext.text = string.Format("+{0}", addsubcoins);
        }
       
	}
}
