using UnityEngine;
using System.Collections.Generic;

//역할:
//키워드 데이터 묶음
//조건과 비교연산
//데이터 기록
public class Keyword
{
    public int includeAmount = 15;

    string text;
    List<string> dates;
    int count;
    KeywordManager keywordManager;

    public Keyword()
    {
        dates = new List<string>();
        count = 0;
    }

    public void setKeywordManager(KeywordManager km)
    {
        keywordManager = km;
    }

    public void setText(string t)
    {
        text = t;
    }

    public string getText()
    {
        return text;
    }

    public List<string> getDates()
    {
        return dates;
    }

    public int getCount()
    {
        return count;
    }

    public void setCount(int c)
    {
        count = c;
    }

    public void addDate(string date)
    {
        dates.Add(date);
    }

    public void onSelected()
    {
        var now = System.DateTime.Now.ToString(DataMother.dateFormat);
        Debug.Log("Keyword selected: " + now);

        dates.Add(now);
        ++count;

        keywordManager.save();
    }

    public int isHHMatched(string date)
    {
        string hh = date.Substring(DataMother.hhStartIdx, 2);

        int match_count = 0;
        for(int i = 0; i < dates.Count; ++i)
        {
            var pastHH = dates[i].Substring(DataMother.hhStartIdx, 2); 
            if(hh == pastHH)
            {
                ++match_count;
            }
        }
        
        return match_count;
    }
}