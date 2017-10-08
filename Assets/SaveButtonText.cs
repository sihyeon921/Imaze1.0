using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = GameObject.Find("SaveButton").transform.position + new Vector3(0, 0, -0.1f);
    }
}
