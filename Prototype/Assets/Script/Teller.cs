using UnityEngine;
using UnityEngine.UI;

//TellScene
//현재 '시간:분'을 기준으로해서
//과거에 선택됐던 키워드들을 보여준다
public class Teller : MonoBehaviour
{
    public Button tellMeButton;

    void Start()
    {
        tellMeButton.onClick.AddListener(onClicked);
    }

    void onClicked()
    {
        SequenceManager.EnterScene(SCENE_TYPE.TELL);
    }
}