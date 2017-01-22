using UnityEngine;
using System.Collections;

public class DateTime : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            print_now_no_format();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            print_format();
        }
    }

    void print_now_no_format()
    {
        var now = System.DateTime.Now.ToString();
        Debug.Log(now);
    }

    void print_now_one_by_one()
    {
        var now = System.DateTime.Now;
        var yr = now.Year.ToString("yy");
        var mon = now.Month.ToString("mm");
        var hr = now.Hour.ToString("hh");
        var min = now.Minute.ToString("mm");

        Debug.Log(yr + "-" + mon + "-" + hr + "-" + min);
    }

    void print_format()
    {
        var now = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
        Debug.Log(now);
    }
}