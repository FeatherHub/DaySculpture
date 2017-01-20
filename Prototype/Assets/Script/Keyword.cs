using UnityEngine;
using System.Collections.Generic;

//테스트할 것:
//System.DateTime.Now("FORMAT") 결과값

// date format: yyyy-mm-dd-hh-mm

//역할:
//키워드 데이터 묶음
//조건과 비교연산
//데이터 기록
public class Keyword
{
    //근처 시간 대까지 포함하기 위함 <-- 추후 추가 1순위 
    //public int includeAmount;

    string text;
    List<string> dates;
    int count;
    KeywordManager keywordManager;

    Keyword()
    {
        dates = new List<string>();
        count = 0;
    }

    public void setKeywordManager(KeywordManager km)
    {
        keywordManager = km;
    }

    public void setText(ref string t)
    {
        text = t;
    }

    public string getText()
    {
        return text;
    }

    public void addDate(string date)
    {
        dates.Add(date);
    }

    public void onSelected()
    {
        var now = System.DateTime.Now.ToString("yyyy-mm-dd-hh-mm");
        Debug.Log("Keyword selected: " + now);

        dates.Add(now);
        ++count;

        keywordManager.save();
    }

    public bool isHHMatched(string date)
    {
        //If matched not found
        //return null;

        //If matched found
        return true;
    }
}