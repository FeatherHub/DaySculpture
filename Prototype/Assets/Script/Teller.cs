using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//현재 '시간:분'을 기준으로해서
//과거날짜 중 근처 시간 대에 
//선택된 키워드들을 보여준다

public class Teller : MonoBehaviour
{
    public KeywordManager keywordManager;
    public Button tellMeButton;
    public int includeAmount = 1;

    void Start()
    {
        tellMeButton.onClick.AddListener(onClicked);
    }

    void onClicked()
    {
        var date = System.DateTime.Now.ToString("");
        var keywords = keywordManager.getHHMatchKeywords(date);

        //키워드들을 보여준다.
        //돌아가기 버튼을 보여준다
    }
}