using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalDistancePlayer : MonoBehaviour {

    public float distance;
    public GameObject A;
  
    // Use this for initialization
    void Start () {
        A = GameObject.FindGameObjectWithTag("legpoint");
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(A.transform.position, this.transform.position);
    }
}
