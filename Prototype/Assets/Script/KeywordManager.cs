using UnityEngine;
using System.Collections.Generic;
using System.IO;

//추후 기능 추가할 것:
//키워드 검색 <-- 0순위
//- 정밀도를 설정하면 (HH수준 / MM수준)
//- 그에 맞게 검색되도록 확장
//키워드 삽입
//- 삽입 시 위치 지정
//- 최대 개수 지정
//키워드 삭제
//- 삭제 시 경고 메시지

//역할
//- 키워드 로드/생성/검색/삽입/삭제 
public class KeywordManager : MonoBehaviour
{
    List<KeywordUI> keywordUIs;
    StreamWriter streamWriter;

    KeywordManager()
    {
        keywordUIs = new List<KeywordUI>();
    }

    StreamWriter getStreamWriter()
    {
        return streamWriter;
    }

    public void load(string dir)
    {
        //데이터 로드

        //키워드 로드
        //Protocol::
        //<Keyword Name> \
        //Count \
        //Dates \
        //::End Protocol
        
        //[[Append after its last date is the most efficient]]
        //1. save last index of its keyword date
        //2. append new data after its line
        //3. update all keyword last index after this one
        
        //[[Usage]]
        //keyword call keywordManager's save

        //키워드 UI 추가
        //1. Load Prefab
        //2. Instantiate 
        //3. Attach it to Canvas
        //4. Set position
        //5. Set its name
        //6. Set its keyword
        //7. Set its streamWriter

        //Container에 추가

        //StreamWriter 캐싱해놓는다
    }

    public void save()
    {

    }

    public List<Keyword> getHHMatchKeywords(string date)
    {
        var result = new List<Keyword>();

        for(int i = 0; i < keywordUIs.Count; ++i)
        {
            var ui = keywordUIs[i];
            var keyword = ui.getKeyword();
            if(keyword.isHHMatched(date)) {
                result.Add(keyword);
            }
        }

        return (result.Count != 0) ? result : null;
    }
}