using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusCoinCount : MonoBehaviour {

    public CoinUIOnLeftTop cuolt;
    public SootingCoinsToUI sctu;
    public AddSubCoinsText asct;
    public AudioSource coin;
    public AudioClip coinSound;
    // Use this for initialization
    void Start () {
        cuolt = GameObject.FindGameObjectWithTag("CoinUIsOnLeftTop").GetComponent<CoinUIOnLeftTop>();
        sctu = GameObject.Find("CoinShooter").GetComponent<SootingCoinsToUI>();
        asct = GameObject.Find("AddOrSubCoinsText").GetComponent<AddSubCoinsText>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("effectcoin"))
        {
            PlayCoinSound();
            cuolt.totalcoins ++;
            asct.addsubcoins--;
            cuolt.hitted = true;
        }
    }
    public void PlayCoinSound()
    {
        //if (!coin.isPlaying)
            coin.Stop();
        coin.PlayOneShot(coinSound);
    }
}
