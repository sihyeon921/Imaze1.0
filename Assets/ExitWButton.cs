using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWButton : MonoBehaviour {
    public ColforLand cl;
    public WindowCol wc;
    public StationData sd;
    public CharacterData cd;
    public CoinUIOnLeftTop cuolt;
    public SaveButton sb;
    public Heallight hl;
    public SootingCoinsToUI sctu;
    public AddSubCoinsText asct;
    public Sprite NextSprite;
    public Sprite CurrentSprite;
    public bool pressed;
    public bool forasct;

    private void OnMouseDown()
    {
       
        if (wc.nexton)
        {
            
            this.transform.Translate(0, -0.3f, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = NextSprite;
        }

    }
    private void OnMouseUp()
    {
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        if (cl.g != null )
        {

          
            pressed = true;
            forasct = true;
            hl.golightkeep = true;

           // cl.wa = false;

           


            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        this.transform.Translate(0, 0.3f, 0);

    }
    // Use this for initialization
    void Start()
    {
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        wc = GameObject.Find("GameSaveWindow").GetComponent<WindowCol>();
        sb = GameObject.Find("SaveButton").GetComponent<SaveButton>();
        sd = GameObject.FindGameObjectWithTag("station").GetComponent<StationData>();
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        sctu = GameObject.Find("CoinShooter").GetComponent<SootingCoinsToUI>();
        hl = GameObject.FindGameObjectWithTag("effect").GetComponent<Heallight>();
        asct = GameObject.Find("AddOrSubCoinsText").GetComponent<AddSubCoinsText>();
        CurrentSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;



    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = GameObject.Find("GameSaveWindow").transform.position + new Vector3(7, 4, -1);
    }
}
