using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingBehavior : MonoBehaviour
{
    public Slider slider;
    bool IsDone = false;
    public Text Ltext;
    public CreateBlocks CB;
    float fTime = 0f;
    AsyncOperation async_operation;

    // Use this for initialization
    void Start()
    {
        CB = GameObject.Find("MazeCreator").GetComponent<CreateBlocks>();
        StartCoroutine(StartLoad("Ingame"));
    }

    // Update is called once per frame
    void Update()
    {
    //    fTime += Time.deltaTime;
    //    slider.value = fTime;

        
        if (CB.IsCompleted)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = Application.LoadLevelAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;
            while (async_operation.progress < 0.9f)
            {
                Ltext.text = "리소스 불러오는 중 ... " + (int)(async_operation.progress * 100f) + "%";
                slider.value = async_operation.progress * 0.1f;

                yield return true;
            }
            slider.value = 0.1f;
            
            while (slider.value <= 1.0f)
            {
                Ltext.text = "미로 생성 중 ... " + (int)(CB.percent * 0.0001f * 100f) + "%";
                slider.value = 0.1f + (CB.percent * 0.0001f * 100f * 0.009f);

                yield return true;
            }
           
        }
    }
}
