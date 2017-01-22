using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class FileIO : MonoBehaviour
{
    public int insertLineNumber = 3;
    string fileDir;
    List<string> lines;
    
    FileStream fs;
    StreamReader sr;
    StreamWriter sw;

	void Start()
    {
        //Set file directory
        fileDir = Application.persistentDataPath;
        fileDir += "/data.txt";
        Debug.Log(fileDir);

        load();
    }

    void Update()
    { 
        //전체 읽기
        if(Input.GetKeyDown(KeyCode.R))
        {
            show();
        }
        //뒤에 쓰기
        if(Input.GetKeyDown(KeyCode.W))
        {
            write();
        }
        //중간에 삽입
        if(Input.GetKeyDown(KeyCode.I))
        {
            append();
        }
    }

    void write()
    {
        string s = "Write this";
        lines.Add(s);

        apply();
    }

    void append()
    {
        string s = "Insert this";
        lines.Insert(insertLineNumber, s);
        
        //KEYWORD -> 숫자도 증가시켜야 한다

        apply();
    }

    void apply()
    {
        updateFile();
        flush();
        close();
        load();
    }

    void updateFile()
    {
        close();

        fs = File.Open(fileDir, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
        sw = new StreamWriter(fs);

        for(int i = 0; i < lines.Count; ++i)
        {
            sw.WriteLine(lines[i]);
        }

        sr = new StreamReader(fs);
    }

    void load()
    {
        fs = File.Open(fileDir, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
        sr = new StreamReader(fs);
        sw = new StreamWriter(fs);

        lines = new List<string>();
        while(sr.EndOfStream != true)
        {
            lines.Add(sr.ReadLine());
        }
    }

    void show()
    {
        for(int i = 0; i < lines.Count; ++i)
        {
            Debug.Log(lines[i]);
        }
    }
    
    void flush()
    {
        fs.Flush();
        sw.Flush();
    }

    void close()
    {
        if (fs != null) fs.Close();
        if (sr != null) sr.Close();
        if (sw != null) sw.Close();
    }
}