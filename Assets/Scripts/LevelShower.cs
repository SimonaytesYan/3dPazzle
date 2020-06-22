using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelShower : MonoBehaviour
{
    // Start is called before the first frame update
    string path;
    bool lol = false;
    int i;
    static GameObject locked;
    static GameObject unlocked;
    void Start()
    {
        lol = false;
        path = Application.persistentDataPath + "/Log.txt";
        StreamReader sr = File.OpenText(path);
        string s = sr.ReadLine();
        i = int.Parse(s);
        sr.Close();
        if (gameObject.tag == "lock")
            locked = gameObject;
        else
        {
            if (gameObject.tag == "unlock")
                unlocked = gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "unlock" && gameObject.tag != "lock" && !lol)
        {
            int name = int.Parse(gameObject.name);
            if (name > i + 1)
            {
                GetComponent<Image>().sprite = locked.GetComponent<Image>().sprite;
            }
            else
                GetComponent<Image>().sprite = unlocked.GetComponent<Image>().sprite;
            lol = true;
        }
    }
}
