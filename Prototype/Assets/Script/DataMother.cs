using UnityEngine;

public class DataMother : MonoBehaviour
{
    public KeywordManager keywordManager;
    public string directory;

	void Start()
    {
        load();
    }

    void load()
    {
        keywordManager.load(directory);
    }

    //현재는 삽입/삭제 즉시 저장하는 구조..
    /*
    void Update()
    {
        //일정 주기 마다
        save();
    }

    void OnApplicationQuit()
    {
        save();
    }

    void save()
    {
        keywordManager.save(ref streamWriter);
    }
    */
}