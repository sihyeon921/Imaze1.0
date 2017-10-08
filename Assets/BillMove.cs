using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillMove : MonoBehaviour {

    public float a;
    public float b;
    public float maxHeight;
    public float minHeight;
    public bool on = true;
    public bool up;
    public bool down;
    public Vector3 maxHeightPosition;
    public Vector3 minHeightPosition;
    public PauseCtrl pc;
    public float second;
    // Use this for initialization
    void Start () {
        pc = GameObject.FindGameObjectWithTag("Cha1").GetComponent<PauseCtrl>();
        up = true;
        maxHeight = 0.5f;
        minHeight = 0.5f;
        a = 0.03f;

        maxHeightPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + maxHeight, gameObject.transform.position.z);
        minHeightPosition = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        second = pc.second;

        
            if (up)
                StartCoroutine("UpMovingEvent");
            else if (down)
                StartCoroutine("DownMovingEvent");
        
    }
    public IEnumerator UpMovingEvent()
    {
        minHeight = 0.5f;

        
        while (maxHeight > 0)
            {
            if (second != 0)
            {
                if (maxHeight <= 0.25f)
                    a = a * 0.999f;
                else
                    a = 0.03f;
            }
           
            this.transform.Translate(0, a* second, 0);
                maxHeight = maxHeight - a * second;
             
                yield return new WaitForFixedUpdate();
            }
        gameObject.transform.position = maxHeightPosition;
        yield return new WaitForFixedUpdate();
        up = false;
        down = true;
       

    }
    public IEnumerator DownMovingEvent()
    {
        maxHeight = 0.5f;
        while (minHeight > 0)
        {
            if (second != 0)
            {
                if (minHeight <= 0.25f)
                    a = a * 0.999f;
                else
                    a = 0.03f;
            }
           
            this.transform.Translate(0, -a * second, 0);
            minHeight = minHeight - a * second;

            yield return new WaitForFixedUpdate();
        }
        gameObject.transform.position = minHeightPosition;
        yield return new WaitForFixedUpdate();

        down = false;
        up = true;
        
    }
    }
