using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button backButton;

    void Awake()
    {
        backButton.onClick.AddListener(onClicked);
    }

    void onClicked()
    {
        SequenceManager.EnterScene(SCENE_TYPE.MAIN);
    }
}