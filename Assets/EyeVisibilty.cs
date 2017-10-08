using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeVisibilty : MonoBehaviour {
    public CharacterData cd;
    public Renderer eye;
    public Vector3 v;
    // Use this for initialization
    void Start () {
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();

        

    }
	
	// Update is called once per frame
	void Update () {
		if(cd.Dead)
            eye.material.color = new Vector4(eye.material.color.r, eye.material.color.g, eye.material.color.b, 0.0f);
    }
}
