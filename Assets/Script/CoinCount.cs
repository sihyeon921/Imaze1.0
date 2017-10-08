using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCount : MonoBehaviour {

    
    
   
    public TextMesh coincountTextMesh;
    public CharacterData cd;

    

	// Use this for initialization
	void Start () {
        
        
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
       
	}
	
	// Update is called once per frame
	void Update () {


        if (cd.coins >= 10)
        {
            
            coincountTextMesh.text = string.Format("{0}", (int)cd.coins);
        }
        else
        {
            
            coincountTextMesh.text = string.Format("{0}", (int)cd.coins);
        }
    }
}
