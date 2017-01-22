using UnityEngine;
using UnityEngine.UI;

//ListenScene
//- 현재 무엇을 하는지 사용자로부터 입력받는다
//- 사용자는 키워드 목록 중 하나를 선택한다.
//- 리스너는 키워드 목록을 보여주고
//- 선택된 키워드를 저장한다
public class Listener : MonoBehaviour
{
    public Button tellHerButton;
    
    void Start()
    {
        tellHerButton.onClick.AddListener(onClicked);
    }

    void onClicked()
    {
        SequenceManager.EnterScene(SCENE_TYPE.LISTEN);
    }
}