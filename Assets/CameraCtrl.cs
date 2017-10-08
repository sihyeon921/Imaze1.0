using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	// Use this for initialization
	
    public GameObject A;
    public PauseCtrl pc;
    Transform AT;
    void Start()
    {
        AT = A.transform;
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!pc.stop)
        {
            transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime * Time.timeScale);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10); //카메라를 원래 z축으로 이동
        }
    }
}
