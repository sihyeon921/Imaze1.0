using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour {

    public Animator anim;
    
    public CharacterData cd;
    public Collider2D col;
    public bool trg;
    
    // Use this for initialization
   
    void Start () {
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
            
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!cd.Dead)
        {
            if (col.CompareTag("colforattain"))
            {
                this.col.enabled = false;
                anim.SetBool("trigger", true);



                StartCoroutine(Delete(0.001f));
            }
        }

    }
    public IEnumerator Delete(float waitTime)
    {
        
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
