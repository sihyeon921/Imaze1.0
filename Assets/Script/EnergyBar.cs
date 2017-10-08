using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour {

    public Transform ForegroundSprite;
    public Transform EdgeSprite;
    public SpriteRenderer ForegroundRenderer;
    public SpriteRenderer UndergroundRenderer;
    public CharacterData cd;

    // Use this for initialization
    void Start () {
        cd = GameObject.FindGameObjectWithTag("Cha1").GetComponent<CharacterData>();
    }
	
	// Update is called once per frame
	void Update () {
        var EnergyPercent = cd.Energy / (float)cd.MaxEnergy;

        ForegroundSprite.localScale = new Vector3(EnergyPercent/1.0416f, 0.5f, 1);
        if(EnergyPercent != 0)
        EdgeSprite.localScale = new Vector3(0.5f/ EnergyPercent, 1, 1);
        else
            EdgeSprite.localScale = new Vector3(EnergyPercent / 1.0416f, 1, 1);
    }
}
