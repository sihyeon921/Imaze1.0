using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMove : MonoBehaviour {

    public StationData st;
    public PauseCtrl pc;
    public Rigidbody2D rig;
    public Vector3 v;
    public bool arrive;
    public bool check;
    // Use this for initialization
    void Start () {
        st = this.GetComponentInParent<StationData>();
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
        rig = gameObject.GetComponent<Rigidbody2D>();
        this.transform.localScale = new Vector3(0.001f, 0.85f, 1);
        rig.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        check = st.occup;
        if (st.occup && !arrive && !pc.stop)
        {
            StartCoroutine("RaisingEvent");
            if (this.transform.localScale.x == 1)
                rig.gravityScale = -2;
            
        }
        if (arrive)
            this.transform.position = v;
    }
    public IEnumerator RaisingEvent()
    {
        
        while(this.transform.localScale.x < 1)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * 1.007f, 0.85f, 1);
            yield return new WaitForFixedUpdate();
        }
        this.transform.localScale = new Vector3(1, 0.85f, 1);
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ColForFlag") //지지대 콜라이더와 충돌 시
        {
            arrive = true;
            v = this.transform.position;
            rig.gravityScale = 0;

           
        }

    }
}
