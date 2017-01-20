using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//- 현재 무엇을 하는지 사용자로부터 입력받는다
//- 사용자는 키워드 목록 중 하나를 선택한다.
//- 리스너는 키워드 목록을 보여주고
//- 선택된 키워드를 저장한다

public class Listener : MonoBehaviour
{
    public KeywordManager keywordManager;
    public Button tellHerButton;
    
    void Start()
    {
        //선택할 수 있는 UI Prefab들을 준비한다

        tellHerButton.onClick.AddListener(onClicked);
    }

    void onClicked()
    {
        //UI Prefab들을 보여준다

        //돌아가기 버튼을 보여준다
        //돌아가기 버튼 클릭 시 -> UI Prefab들을 숨긴다
    }
}