using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColforCoin : MonoBehaviour {

    public CoinCount count;
    public CharacterData cd;
    public BackLight bl;
    public AudioSource coin;
    public AudioClip coinSound;
    public AudioSource bill;
    public AudioClip billSound;
    public bool AttainState;
    public bool shoot;
    // Use this for initialization
    void Start () {
        count = GameObject.FindGameObjectWithTag("cointextuionplayer").GetComponent<CoinCount>();
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
        bl = GameObject.Find("backlight").GetComponent<BackLight>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!cd.Dead)
        {
            if (col.CompareTag("coin"))
            {
                PlayCoinSound();
                shoot = true;
                AttainState = true;
                cd.coins += 1;
                cd.GainEnergy += 5;



            }
            if (col.CompareTag("bill"))
            {
                PlayBillSound();
                StartCoroutine(bl.BackLightEvent());
                shoot = true;
                AttainState = true;
                cd.coins += 100;
                if (cd.GainEnergy <= 0)
                    cd.GainEnergy += 100;
                else
                    cd.GainEnergy += (cd.MaxEnergy - cd.GainEnergy);



            }
        }


    }
    public void PlayCoinSound()
    {
        coin.Stop();
        coin.PlayOneShot(coinSound);
    }
    public void PlayBillSound()
    {
        bill.Stop();
        bill.PlayOneShot(billSound);
    }
}
