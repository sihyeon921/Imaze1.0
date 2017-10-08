using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColforLand : MonoBehaviour
{
    public bool on;
    public bool wa;
    public CharMove cm;
    public StationData g;
    public GameObject asct;
    public Heallight hl;
    // Use this for initialization
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        asct = GameObject.Find("AddOrSubCoinsText");
        hl = GameObject.FindGameObjectWithTag("effect").GetComponent<Heallight>();



    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("station") )
        {
            if (!col.gameObject.GetComponent<StationData>().occup )
            {
              
                asct.GetComponent<MeshRenderer>().material.color = new Vector4(asct.GetComponent<MeshRenderer>().material.color.r, asct.GetComponent<MeshRenderer>().material.color.g, asct.GetComponent<MeshRenderer>().material.color.b, 1.0f);
                wa = true;
            }
            on = true;
        }

        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.CompareTag("station") )
        {
            g = col.gameObject.GetComponent<StationData>();
            if (!col.gameObject.GetComponent<StationData>().occup )
            {
              
                asct.GetComponent<MeshRenderer>().material.color = new Vector4(asct.GetComponent<MeshRenderer>().material.color.r, asct.GetComponent<MeshRenderer>().material.color.g, asct.GetComponent<MeshRenderer>().material.color.b, 1.0f);
                wa = true;
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        
    }
}




