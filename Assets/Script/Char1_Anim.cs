using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim1 : MonoBehaviour {
    public Animator anim;
    public CharMove cm;
    public CharacterData cd;
    // Use this for initialization
    void Start () {
		cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
    }
	
	// Update is called once per frame
	void Update () {
        if(cm.PresKey == true)
            anim.SetBool("touch", true);
        else
            anim.SetBool("touch", false);
        if (cm.R && cm.L)
            anim.SetBool("bothpress", true);
        else
            anim.SetBool("bothpress", false);
        if(cd.Dead)
            anim.SetBool("dead", true);
    }
}
