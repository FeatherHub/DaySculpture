using UnityEngine;
using System.Collections.Generic;

public class DefaultData : MonoBehaviour
{
    static List<string> dd;

    public static List<string> getDefaultData()
    {
        dd = new List<string>();

        dd.Add("공부");
        dd.Add("0");
        dd.Add("운동");
        dd.Add("0");
        dd.Add("스마트폰");
        dd.Add("0");
        dd.Add("산책");
        dd.Add("0");
        dd.Add("인강시청");
        dd.Add("0");
        dd.Add("독서");
        dd.Add("0");
        dd.Add("잠");
        dd.Add("0");
        dd.Add("게임");
        dd.Add("0");
        dd.Add("카카오톡");
        dd.Add("0");
        dd.Add("일");
        dd.Add("0");
        dd.Add("출근");
        dd.Add("0");
        dd.Add("밥");
        dd.Add("0");
        dd.Add("씻기");
        dd.Add("0");
        dd.Add("음악감상");
        dd.Add("0");
        dd.Add("누워있기");
        dd.Add("0");

        return dd;
    }
}