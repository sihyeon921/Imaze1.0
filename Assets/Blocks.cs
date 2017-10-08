using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

    public CreateBlocks CB;
    public bool collision;
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start () {
        CB = GameObject.Find("Main Camera").GetComponent<CreateBlocks>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.CompareTag("block"))
        {
            
               
                collision = true;
              
            
       
    
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.CompareTag("block"))
        {


            collision = false;




        }
    }

}
