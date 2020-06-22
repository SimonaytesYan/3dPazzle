using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/Log.txt";
        StreamReader sr = File.OpenText(path);
        string s = sr.ReadLine();
        int i = int.Parse(s);
        sr.Close();
        int name = int.Parse(gameObject.name);
        if (name > i+1)
            GetComponent<Text>().text = "";
        else
            GetComponent<Text>().text = " " + gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
