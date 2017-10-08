using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInCamera : MonoBehaviour {

    public CreateBlocks CB;
    // Use this for initialization
    void Start () {
        CB = GameObject.Find("Main Camera").GetComponent<CreateBlocks>();
    }
	
	// Update is called once per frame
	void Update () {

        if (CB.IsCompleted)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);


            if ((viewPos.x >= 0 && viewPos.x <= 1.0f) && (viewPos.y >= 0 && viewPos.y <= 1.0f))
            {
                gameObject.SetActive(true);
            }
            else
                gameObject.SetActive(false);
        }

    }
}
