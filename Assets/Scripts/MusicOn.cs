using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MusicOn : MonoBehaviour
{
    static bool play = true;
    static Material clear;
    bool isplay = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Main Camera" && play)
        {
            GetComponent<AudioSource>().Play();
            isplay = true;
        }
        if (gameObject.name == "Clear")
            clear = gameObject.GetComponent<Image>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "MusicPlay?" )
        {
            if (!play)
                gameObject.GetComponent<Image>().material = clear;
            else
                gameObject.GetComponent<Image>().material = null;

        }
        if (gameObject.name == "Main Camera" && !play)
        {
            GetComponent<AudioSource>().Stop();
            isplay = false;
        }
        if (gameObject.name == "Main Camera" && play && !isplay)
        {
            GetComponent<AudioSource>().Play();
            isplay = true;
        }
    }
    public void Click()
    {

        Debug.Log("LOL");
        play = !play;
    }
}
