using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveQuestionText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.name == "SaveQuestionText")
            this.transform.position = GameObject.Find("GameSaveWindow").transform.position + new Vector3(0, 0, 0);
        else if (this.gameObject.name == "OkayText")
            this.transform.position = GameObject.Find("SaveButton").transform.position + new Vector3(0.7f, 0, 0);
        else if (this.gameObject.name == "SaveButtonCoin")
            this.transform.position = GameObject.Find("SaveButton").transform.position + new Vector3(-0.7f, 0, 0);
    }
}
