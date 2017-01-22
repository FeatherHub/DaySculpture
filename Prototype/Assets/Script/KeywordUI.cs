using UnityEngine;
using UnityEngine.UI;

public class KeywordUI : MonoBehaviour
{
    public Button button;
    public Text text;
    Keyword keyword;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        button.onClick.AddListener(onClicked);
    }

    public Keyword getKeyword()
    {
        return keyword;
    }

    public void setKeyword(Keyword kw)
    {
        keyword = kw;
        setText(keyword.getText());
    }

    void setText(string s)
    {
        text.text = s;
    }

    void onClicked()
    {
        //안내 메시지
        //감사합니다

        keyword.onSelected();
    }
}