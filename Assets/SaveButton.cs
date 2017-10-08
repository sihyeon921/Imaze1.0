using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour {
    public ColforLand cl;
    public WindowCol wc;
    public StationData sd;
    public CharacterData cd;
    public CoinUIOnLeftTop cuolt;
    public Heallight hl;
    public SootingCoinsToUI sctu;
    public Sprite NextSprite;
    public Sprite CurrentSprite;
    public bool pressed;
    public bool goshoot;
    public bool golightkeep;


    private void OnMouseDown()
    {
        
            if (wc.nexton && cd.coins + cuolt.totalcoins >= 25) //게임 저장 비용을 낼수 있어야만
            {
                this.transform.Translate(0, -0.3f, 0);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = NextSprite;
            }
        
    }
    private void OnMouseUp()
    {
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        if (cl.g != null && cd.coins + cuolt.totalcoins >= 25 )
        {
            pressed = true;
            
            if(cd.coins > 0 )
            sctu.goshoot = true;
            hl.golightkeep = true;
            cl.g.occup = true;
            cl.g.check = true;
           // cl.wa = false;

            cuolt.totalcoins -= 25; //저장 비용 소모


            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        this.transform.Translate(0, 0.3f, 0);

    }
    // Use this for initialization
    void Start () {
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        wc = GameObject.Find("GameSaveWindow").GetComponent<WindowCol>();
        sd = GameObject.FindGameObjectWithTag("station").GetComponent<StationData>();
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        sctu = GameObject.Find("CoinShooter").GetComponent<SootingCoinsToUI>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        hl = GameObject.FindGameObjectWithTag("effect").GetComponent<Heallight>();

        CurrentSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;

       

    }
	
	// Update is called once per frame
	void Update () {
       
        this.transform.position = GameObject.Find("GameSaveWindow").transform.position + new Vector3(0, -2, -1);
    }
}
