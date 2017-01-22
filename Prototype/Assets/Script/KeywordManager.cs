using UnityEngine;
using System.Collections.Generic;

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

    List<Keyword> keywords;

    static bool initialized = false;
    void Awake()
    {
        if(initialized)
        {
            Destroy(this);
            return;
        }

        keywords = new List<Keyword>();
        DontDestroyOnLoad(this);
    }

    //주의: Data Mother의 Awake 호출 뒤에 실행한다
    void Start()
    {
        if (initialized) return;

        first_load();
        initialized = true;
    }

    void first_load()
    {
        //Data Load
        var lines = new List<string>();
        var reader = DataMother.getReader();
        while(reader.EndOfStream != true)
        {
            var line = reader.ReadLine();
            lines.Add(line);
        }

        int lineIdx = 0;
        while(lineIdx < lines.Count)
        {
            //Convert lines into Keyword 
            //Protocol:
            //<Keyword Name> \
            //Count \
            //Dates * Count \
            var keyword = new Keyword();
            keyword.setText(lines[lineIdx]);
            ++lineIdx;

            var cntStr = lines[lineIdx];
            int count = int.Parse(cntStr);
            keyword.setCount(count);
            ++lineIdx;

            for(int dataIdx = 0; dataIdx < count; ++dataIdx)
            {
                keyword.addDate(lines[lineIdx]);
                ++lineIdx;
            }

            //Set keyword manager
            keyword.setKeywordManager(this);
            //Container에 추가
            keywords.Add(keyword);
        }
    } //End first_load()
    
    //[IMPROVE]
    //Append after its last date is the most efficient
    //1. save last index of its keyword date
    //2. append new data after its line
    //3. update all keyword last index after this one
    public void save()
    {
        DataMother.save_pre_proc();

        var writer = DataMother.getWriter();
        for(int i = 0; i < keywords.Count; ++i)
        {
            //Get Keyword
            var keyword = keywords[i];
            //Get Data
            var text = keyword.getText();
            var count = keyword.getCount();
            var dates = keyword.getDates();
            //Write Data
            writer.WriteLine(text);
            writer.WriteLine(count);
            for(int j = 0; j < dates.Count; ++j)
            {
                writer.WriteLine(dates[j]);
            }
        }

        DataMother.save_post_proc();
    }

    
    //무엇을 반환할 것인가?
    //키워드:선택한 날짜들
    //키워드:선택한 횟수
    //키워드:퍼센트(선택횟수 / 24 * 설치날짜)

    //현재 => 키워드:선택한 횟수
    public List<KeyValuePair<int, string>> getHHMatchKeywords(string date)
    {
        var result = new List<KeyValuePair<int, string>>();

        for(int i = 0; i < keywords.Count; ++i)
        {
            var keyword = keywords[i];
            var matchNum = keyword.isHHMatched(date);
            if (matchNum != 0)
            {
                var mnkw = new KeyValuePair<int, string>
                    (matchNum, keyword.getText());
                result.Add(mnkw);
            }
        }
        
        return (result.Count != 0) ? result : null;
    }

    public List<Keyword> getKeywords()
    {
        return keywords;
    }
}