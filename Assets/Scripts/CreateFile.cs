using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateFile : MonoBehaviour
{
    string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/Log.txt";

        if (!File.Exists(path))
        {
            StreamWriter sw = File.CreateText(path);
            sw.WriteLine("0");
            sw.Close();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
