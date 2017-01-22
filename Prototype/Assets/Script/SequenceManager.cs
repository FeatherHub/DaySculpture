using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public enum SCENE_TYPE
{
    MAIN, LISTEN, TELL
}

public class SequenceManager : MonoBehaviour
{
    public GameObject KeywordUIPrefab;
    public GameObject textPrefab;
    public KeywordManager km;

    //TEXT
    Vector2 textStartPos = new Vector2(-100.0f, 70.0f);
    Vector2 textPosDelta = new Vector2(200.0f, -50.0f);

    //UI
    Vector2 uiStartPos = new Vector2(-120.0f, 95.0f);
    Vector2 uiPosDelta = new Vector2(120.0f, -50.0f);

    enum SCENE_IDX
    {
        MAIN = 0, LISTEN = 1, TELL = 2
    }

    static bool init = false;
    void Awake()
    {
        if(init)
        {
            Destroy(this);
            return;
        }

        SceneManager.sceneLoaded += OnLevelLoaded;
        DontDestroyOnLoad(this);
        init = true;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode loadMode)
    {
        var sceneIdx = scene.buildIndex;
      
        switch ((SCENE_IDX)sceneIdx)
        {
        case SCENE_IDX.MAIN: onMainSceneEnter(); break;
        case SCENE_IDX.LISTEN: onListenSceneEnter(); break;
        case SCENE_IDX.TELL: onTellSceneEnter(); break;
        }
    }

    void onMainSceneEnter()
    {
    }

    void onListenSceneEnter()
    {
        //KeywordUI를 추가한다
        //1. Instantiate Prefab
        //2. Set keyword
        var kws = km.getKeywords();
        var keywordUIs = new List<KeywordUI>();
        for(int i = 0; i < kws.Count; ++i)
        {
            var obj = Instantiate(KeywordUIPrefab);
            obj.name = "KeywordUI " + kws[i].getText();

            var keywordUI = obj.GetComponent<KeywordUI>();
            keywordUI.setKeyword(kws[i]);

            keywordUIs.Add(keywordUI);
        }

        //KeywordUI를 배치한다
        var canvasObj = GameObject.FindGameObjectWithTag("Canvas");
        var canvas = canvasObj.GetComponent<Canvas>();
        for (int i = 0; i < keywordUIs.Count; ++i)
        {
            var ui = keywordUIs[i];
            ui.transform.SetParent(canvas.transform);

            var deltaX = (i % 3) * uiPosDelta.x;
            var deltaY = (i / 3) * uiPosDelta.y;
            var delta = new Vector2(deltaX, deltaY);
            var cur = uiStartPos + delta;
            ui.transform.localPosition = cur;
            ui.gameObject.SetActive(true);
        }
    }

    void onTellSceneEnter()
    {
        //Get Datas
        var date = System.DateTime.Now.ToString(DataMother.dateFormat);
        var pairs = km.getHHMatchKeywords(date);
        //Get Canvas
        var canvasObj = GameObject.FindGameObjectWithTag("Canvas");
        var canvas = canvasObj.GetComponent<Canvas>();

        if (pairs == null)
        {
            //Nothing Text
            var textObj = Instantiate(textPrefab);
            var text = textObj.GetComponent<Text>();
            text.text = "NOTHING...";
            text.transform.SetParent(canvas.transform);
            return;
        }

        //Instantiate Texts
        for(int i = 0; i < pairs.Count; ++i)
        {
            //Get Data
            var kwMatchedNum = pairs[i].Key;
            var kwName = pairs[i].Value;
            //Get Interface
            var textObj = Instantiate(textPrefab);
            var text = textObj.GetComponent<Text>();
            //Set Data to Interface
            text.text = kwName + ": " + kwMatchedNum + " 회";
            //Set Display Values
            text.transform.SetParent(canvas.transform);
            var deltaX = (i % 2) * textPosDelta.x;
            var deltaY = (i / 2) * textPosDelta.y;
            var delta = new Vector2(deltaX, deltaY);
            var cur = textStartPos + delta;
            text.transform.localPosition = cur;
        }
    }

    static public void EnterScene(SCENE_TYPE st)
    {
        string sceneName;
        switch (st)
        {
            case SCENE_TYPE.MAIN: sceneName = "MainScene"; break;
            case SCENE_TYPE.LISTEN: sceneName = "ListenScene"; break;
            case SCENE_TYPE.TELL: sceneName = "TellScene"; break;
            default: sceneName = ""; break;
        }
        SceneManager.LoadScene(sceneName);
    }
}