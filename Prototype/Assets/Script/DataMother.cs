using UnityEngine;
using System.IO;

public class DataMother : MonoBehaviour
{
    public string fileName = "data.txt";

    public static string dateFormat = "yyyy-MM-dd-HH-mm";
    public static int hhStartIdx = 11;

    static FileStream fs;
    static StreamReader sr;
    static StreamWriter sw;
    static string fileDir;

    
    static bool initialized = false;
    //Call once after app start
    void Awake()
    {
        if (initialized)
        {
            Destroy(this);
            return;
        }

        fileDir = Application.persistentDataPath;
        fileDir += "/" + fileName;

        first_load();

        DontDestroyOnLoad(this);

        initialized = true;
    }

    void first_load()
    {
        fs = File.Open(fileDir, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        sr = new StreamReader(fs);
    }

    static public void save_pre_proc()
    {
        close();
        fs = File.Open(fileDir, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        sw = new StreamWriter(fs);
    }

    static public void save_post_proc()
    {
        flush();
        sr = new StreamReader(fs);
    }

    static void flush()
    {
        if (fs != null) fs.Flush();
        if (sw != null) sw.Flush();
    }

    static void close()
    {
        if (fs != null) fs.Close();
        if (sw != null) sw.Close();
        if (sr != null) sr.Close();
    }

    static public StreamWriter getWriter()
    {
        return sw;
    }

    static public StreamReader getReader()
    {
        return sr;
    }

    void OnApplicationQuit()
    {
        close();
    }
}