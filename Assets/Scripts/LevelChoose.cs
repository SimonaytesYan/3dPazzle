using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.IO;
public class LevelChoose : MonoBehaviour
{
    // Start is called before the first frame update
    string path;
    int i;

    void Start()
    {
        path = Application.persistentDataPath + "/Log.txt";
        StreamReader sr = File.OpenText(path);
        string s = sr.ReadLine();
        i = int.Parse(s);
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToDonation()
    {
        SceneManager.LoadScene("Donation", LoadSceneMode.Single);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("LvlMenu", LoadSceneMode.Single);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


    public void To1lvl()
    {
        
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
    }

    public void To2lvl()
    {
        if (i >= 1)
        SceneManager.LoadScene("level2", LoadSceneMode.Single);
    }

    public void To3lvl()
    {
        if (i >= 2)
            SceneManager.LoadScene("level3", LoadSceneMode.Single);
    }

    public void To4lvl()
    {
        if (i >= 3)
            SceneManager.LoadScene("level4", LoadSceneMode.Single);
    }

    public void To5lvl()
    {
        if (i >= 4)
            SceneManager.LoadScene("level5", LoadSceneMode.Single);
    }

    public void To6lvl()
    {
        if (i >= 5)
            SceneManager.LoadScene("level6", LoadSceneMode.Single);
    }

    public void To7lvl()
    {
        if (i >= 6)
            SceneManager.LoadScene("level7", LoadSceneMode.Single);
    }

    public void To8lvl()
    {
        if (i >= 7)
            SceneManager.LoadScene("level8", LoadSceneMode.Single);
    }

    public void To9lvl()
    {
        if (i >= 8)
            SceneManager.LoadScene("level9", LoadSceneMode.Single);
    }

    public void To10lvl()
    {
        if (i >= 9)
            SceneManager.LoadScene("level10", LoadSceneMode.Single);
    }

    public void To11lvl()
    {
        if (i >= 10)
            SceneManager.LoadScene("level11", LoadSceneMode.Single);
    }

    public void To12lvl()
    {
        if (i >= 11)
            SceneManager.LoadScene("level12", LoadSceneMode.Single);
    }

    public void To13lvl()
    {
        if (i >= 12)
            SceneManager.LoadScene("level13", LoadSceneMode.Single);
    }

    public void To14lvl()
    {
        if (i >= 13)
            SceneManager.LoadScene("level14", LoadSceneMode.Single);
    }

    public void To15lvl()
    {
        if (i >= 14)
            SceneManager.LoadScene("level15", LoadSceneMode.Single);
    }

    public void ToSettings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
}
