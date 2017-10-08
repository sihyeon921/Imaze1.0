using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLight : MonoBehaviour
{
    public bool on;
    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Vector4(this.gameObject.GetComponent<Renderer>().material.color.r,
            this.gameObject.GetComponent<Renderer>().material.color.g, this.gameObject.GetComponent<Renderer>().material.color.b, 0.7f); ;
        transform.localScale = new Vector3(0.001f, 0.001f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator BackLightEvent()
    {
        on = true;
        while (gameObject.transform.localScale.x < 0.76f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.05f, gameObject.transform.localScale.y + 0.05f, gameObject.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }


        yield return new WaitForSeconds(2f); //유지
        while (gameObject.transform.localScale.x > 0.001f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.05f, gameObject.transform.localScale.y - 0.05f, gameObject.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        on = false;
    }
}
