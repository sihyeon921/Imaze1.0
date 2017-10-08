using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryState : MonoBehaviour {
    public Animator anim;
    public CharacterData cd;
    // Use this for initialization
    void Start () {
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
    }
	
	// Update is called once per frame
	void Update () {
        if (cd.Energy < 30)
        {
            anim.SetBool("lowenergy", true);
            if(cd.Energy == 0)
                anim.SetBool("noenergy", true);
        }
        else
            anim.SetBool("lowenergy", false);

    }
}
