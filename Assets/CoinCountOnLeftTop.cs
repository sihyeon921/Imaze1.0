using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCountOnLeftTop : MonoBehaviour {


    public TextMesh totalcoinTextMesh;
    public CoinUIOnLeftTop cuolt;

    // Use this for initialization
    void Start () {
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();

    }

    // Update is called once per frame
    void Update () {
        if (cuolt.totalcoins >= 10)
        {

            totalcoinTextMesh.text = string.Format("{0}", (int)cuolt.totalcoins);
        }
        else
        {

            totalcoinTextMesh.text = string.Format("{0}", (int)cuolt.totalcoins);
        }
    }
}
