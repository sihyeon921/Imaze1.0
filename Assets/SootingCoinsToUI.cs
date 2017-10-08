using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SootingCoinsToUI : MonoBehaviour {


    public CoinUIOnLeftTop cuolt;
    public CharacterData cd;
    public CharMove cm;
    public Heallight hl;
    public SavingCoinCounterUI sccu;
    public WindowCol wc;
    public ColforLand cl;
    public SaveButton sb;
    public float coinvalue;
    public bool on;
    public bool cal;
    public bool goshoot;
    public float timegap;

    [SerializeField]
    private GameObject ShootingCoinPrefab;

    // Use this for initialization
    void Start () {
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        cm = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharMove>();
        hl = GameObject.FindGameObjectWithTag("effect").GetComponent<Heallight>();
        sccu = GameObject.Find("SavingCoinCounter").GetComponent<SavingCoinCounterUI>();
        wc = GameObject.Find("GameSaveWindow").GetComponent<WindowCol>();
        cl = GameObject.Find("ColForStation").GetComponent<ColforLand>();
        sb = GameObject.Find("SaveButton").GetComponent<SaveButton>();

    }

    // Update is called once per frame
    void Update()
    {
       
            if (cl.wa)
            {
                if (hl.heallight.material.color.a >= 0.95f && cm.gravity == 0 && goshoot )
                {

                    on = true;
                    if (!cal)
                        CalCoinValue();
                    StartCoroutine("ShootingEvent");
                }
            }
            else
            {
                if (hl.heallight.material.color.a >= 0.95f && cm.gravity == 0 && cd.coins > 0)
                {

                    on = true;
                    if (!cal)
                        CalCoinValue();
                    StartCoroutine("ShootingEvent");
                }
            }
        
    }
    public void ShootingCoins(int value)
    {
        GameObject coin = (GameObject)Instantiate(ShootingCoinPrefab, transform.position + new Vector3(0,0,10), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    public IEnumerator ShootingEvent()
    {
        if (cl.g.occup)
        {
            while (cd.coins > 0 && cm.gravity == 0)
            {
                
                ShootingCoins(0);
                cd.coins--;

                if (cd.coins == 0)
                    timegap = 1.0f;
                else
                    timegap = Random.Range(13f, 15f);

                yield return new WaitForSeconds(timegap);
            }


            yield return new WaitForSeconds(0.5f);
        }
        on = false;
        goshoot = false;
        //sb.pressed = false;

    }
    public void CalCoinValue()
    {
        if (cd.coins > 30)
            coinvalue = (float)cd.coins / 30.0f;
        else
            coinvalue = 1f;
        cal = true;
    }
}
