using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using GoogleMobileAds.Api;

public class MyMouse : MonoBehaviour
 {    
    Vector3 StartPos;
    Vector3 PosR = new Vector3();
    Vector3 pos = new Vector3();
    Vector3 poslast = new Vector3();
    Material notClear;
    int index = -1;
    bool ison = false;
    bool isNotClear = false;
    float r;
    string pathads;

    public int lvlnumber;
    public Material Clear;
    public int lastlvl1;

    static bool first = true;
    static bool lup = false;
    static string path;
    static int isall = 0;
    static string path1;
    static int lastlvl;
    static int zalupy;
    static List<GameObject> allfront = new List<GameObject>();
    static List<GameObject> g = new List<GameObject>();
    static List<bool> flags = new List<bool>();
    static float rot, roty; 
    static int appr = 0;
    static int notComplited = 0;
    static bool ungridVis;
    static Material translucent;
    static Vector3 CameraPosition;
    static int lol = 0;


    private const string addblock = "ca-app-pub-5277008341220850/9525140926";
    private InterstitialAd ad;

    public static int ConvertDateTimeToInt32(DateTime dt)
    {
        return (int)(dt - new DateTime(2017, 1, 1)).TotalSeconds;
    }


    void Start()
    {

        if (gameObject.name == "next")
            lastlvl1 = lastlvl;
        if (first)
        {
            PurchaseManager.OnPurchaseNonConsumable += NoAdd;
            PurchaseManager.OnPurchaseConsumable += add;
            notComplited = 0;
            rot = 0;
            roty = 0;
            flags.Clear();
            allfront.Clear();
            g.Clear();
            first = false;
            path = Application.persistentDataPath + "/Log.txt";
            isNotClear = false;
            appr = 0;
            path1 = Application.persistentDataPath + "/Tyt_donat_nahuy.txt";
            if (!File.Exists(path1))
            {
                StreamWriter sw = File.CreateText(path1);
                sw.WriteLine("1");
                sw.Close();
            }
            StreamReader sr = File.OpenText(path1);
            string s = sr.ReadLine();
            zalupy = int.Parse(s);
            sr.Close();
            pathads = Application.persistentDataPath + "/For_ads.txt";
            if (!File.Exists(pathads))
            {
                StreamWriter sw = File.CreateText(pathads);
                sw.WriteLine("1");
                sw.Close();
            }
        }
        if (name == "Main Camera")
            CameraPosition = transform.position;
        if (gameObject.tag == "translucent")
            translucent = GetComponent<MeshRenderer>().material;
        if (name != "Main Camera")
        {
            if (gameObject.name == "Planc")
            {
                if (ungridVis)
                {

                    Destroy(gameObject);
                }
            }
            if (gameObject.name != "Exit")
                transform.rotation = Quaternion.Euler(0, 0, 0);
            if (gameObject.tag == "NotCut")
            {
                index = -1;
                gameObject.GetComponent<MeshRenderer>().material = Clear;
            }
            if (gameObject.tag == "moving")
            {
                
                g.Add(gameObject);
                index = notComplited;
                notComplited++;
                flags.Add(false);
            }
        }



    }
    void Update()
    {
        
        if (name == "Main Camera")
        {
            transform.position = new Vector3((float)0.17, (float)1.16, -appr * 2 + 15);
        }
        if (gameObject.tag == "NotCut")
        {
            if (index == -1)
            {
                if (gameObject.tag == "NotCut")
                {

                    for (int i = 0; i < g.Count; i++)
                    {
                        string str = g[i].name + "(1)";

                        if (str == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    notClear = g[index].GetComponent<MeshRenderer>().material;
                }
                
                
            }

            if (lup)
            {
                if (!isNotClear)
                {
                    isall++;
                    gameObject.GetComponent<MeshRenderer>().material = notClear;
                    if (isall == g.Count)
                    {
                        lup = false;
                        isall = 0;
                        lol = 0;
                    }
                }
            }
            else
            {
                lol++;
                if (lol > 100000)
                    lol = 1001;
                if (!isNotClear && lol > 600)
                {
                    gameObject.GetComponent<MeshRenderer>().material = Clear;
                }
            }
            if (flags.Count > index && flags[index] && !isNotClear)
            {
                isNotClear = true;
                gameObject.GetComponent<MeshRenderer>().material = notClear;
            }
        }

        if (gameObject.name == "Planc")
            transform.rotation = Quaternion.Euler(90, rot, 0);
        if (gameObject.tag == "ForRoll")
            transform.rotation = Quaternion.Euler(roty, rot, 0);
    }

    void OnTriggerEnter(Collider  myCollision)
    {
       
        if (gameObject.tag == "moving")
        {
            string name = (string)gameObject.name + "(1)";
            if (myCollision.gameObject.name == name)
            {
                PosR = myCollision.gameObject.transform.position;
                ison = true;
            }
        }
    }
        void OnTriggerExit(Collider myCollision)
        {
            string name = (string)gameObject.name + "(1)";
            if (gameObject.tag == "moving" && myCollision.gameObject.name == name)
            {
                ison = false;
            }
        }
    void OnMouseEnter()
    {
            pos = Input.mousePosition;
            poslast = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        pos = Input.mousePosition;
        if (gameObject.tag == "rot")    //Вращение
        {
            float lol = pos.x - poslast.x;
            float kx = (float)-0.09;
            float ky = (float)-0.09;
            lol *= kx;
            rot += lol;
            lol = pos.y - poslast.y;
            lol *= ky;
            roty += lol;
            if (rot > 359.9)
                rot = rot%360;
            if (roty > 359.9)
                roty = roty % 360;
        }
        else
        {
            if (gameObject.tag == "rot2")   //Движение по хотбару
            {
                float lol = pos.x - poslast.x;
                float kx = (float)0.009;
                lol *= kx;
                for (int i = 0; i < g.Count; i++)
                    g[i].transform.localPosition += new Vector3((float)lol, 0, 0);
            }
            if (pos != poslast && gameObject.tag == "moving")   //перетаскивание
            {        
                RaycastHit hit;
                Vector3 direction = CameraPosition - transform.position;

                if (Physics.Raycast(transform.position, direction, out hit))
                {
                    if (hit.collider.gameObject.tag == "NotCut")
                    {
                        GameObject victim = hit.collider.gameObject;
                        if (victim.tag == "NotCut" && victim.GetComponent<MyMouse>().isNotClear)
                        {
                            victim.GetComponent<MeshRenderer>().material = translucent;
                            allfront.Add(victim);
                        }
                    }
                }

                Vector3 i = pos - poslast;
                i.z = poslast.z;
                float kx = (float)0.01;
                float ky = (float)0.02;
                i.x *= kx;
                i.y *= ky;
                transform.localPosition += i;
            }
        }
        poslast = pos;
    }
    public void Loaded(object sender, System.EventArgs args)
    {
        ad.Show();
    }
        void OnMouseDown()
        {
        if (gameObject.name == "next")
        {
            //Debug.Log(lastlvl);
            if (lastlvl < 15)
            {
                int k = lastlvl + 1;
                string str = "level" + k.ToString();
                SceneManager.LoadScene(str, LoadSceneMode.Single);
            }
        }
            if (gameObject.name == "Exit")
            {
                StreamReader sr = File.OpenText(pathads);
                string s = sr.ReadLine();
                int i = int.Parse(s);
                sr.Close();
            if (i == 1)
            {
                ad = new InterstitialAd(addblock);
                AdRequest request = new AdRequest.Builder().Build();
                ad.LoadAd(request);
                ad.OnAdLoaded += Loaded;
            }
                    SceneManager.LoadScene("LvlMenu", LoadSceneMode.Single);

                    rot = 0;
                    roty = 0;
                    flags.Clear();
                    allfront.Clear();
                    g.Clear();
                    first = true;
            }
            pos = Input.mousePosition;
            StartPos = transform.position;
            poslast = pos;

            if (gameObject.tag == "plus")
            {
                if (appr <= 2)
                    appr++;
            }
            if (gameObject.tag == "minus")
            {
                if (appr > 0)
                    appr--;
            }
            if (gameObject.tag == "standart")
            {
                appr = 0;
            }
        if (gameObject.tag == "moving")
        {
            transform.rotation = Quaternion.Euler(roty, rot, 0);
            transform.position += new Vector3(0, 0, appr*2);
        }
    }

        void OnMouseUp()
        {
        if (gameObject.tag == "moving")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            for (int k = 0; k < allfront.Count; k++)
                allfront[k].GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        }
        if (gameObject.name == "lupa")
        {

            
            
            if (zalupy > 0)
            {
                
                lup = true;

                zalupy--;
                path1 = Application.persistentDataPath + "/Tyt_donat_nahuy.txt";
                StreamWriter sw = File.CreateText(path1);
                sw.WriteLine(zalupy.ToString());
                sw.Close();
            }
        }

        
            if (ison && gameObject.tag == "moving")
            {
                StartPos = PosR;
                notComplited--;
                ison = false;
                
                flags[index] = true;

                g.Remove(gameObject);
                Destroy(gameObject);
            }
            
            if (gameObject.tag == "moving")
                transform.position = StartPos;
            bool lol = true;
            for (int i = 0; i < flags.Count;i++)
            {
                if (!flags[i])
                { 
                    lol = false;
                }
            }
           

            if (lol)
            {
                notComplited = 0;
                g = new List<GameObject>();
                int i = 0;
                if (File.Exists(path))
                {
                    StreamReader sr = File.OpenText(path);
                    string s = sr.ReadLine();
                    i = int.Parse(s);
                    sr.Close();
                    
                }
                if (i < lvlnumber)
                    i++;
                
                StreamWriter sw = File.CreateText(path);
                sw.WriteLine(i.ToString());
                sw.Close();
            //System.Threading.Thread.Sleep(1000);

            rot = 0;
            roty = 0;
            flags.Clear();
            allfront.Clear();
            g.Clear();
            lastlvl = lvlnumber;
            SceneManager.LoadScene("EndLevel");
            first = true;
        }
    }

    public void PlancVisible()
    {
        if (GetComponent<Text>().text == "Выключена")
        {
            GetComponent<Text>().text = "Включена";
        }
        else
        {
            GetComponent<Text>().text = "Выключена";
        }
        ungridVis = !ungridVis;
    }


    private void add(PurchaseEventArgs args)
    {
        if (args.purchasedProduct.definition.id == "add1_money")
        {
             zalupy++;

            //Debug.Log(zalupy);
            StreamWriter sw = File.CreateText(path1);
             sw.WriteLine(zalupy.ToString());
             sw.Close();
        }
        if (args.purchasedProduct.definition.id == "add5_money")
        {
                zalupy+=5;
                //Debug.Log(zalupy);
                StreamWriter sw = File.CreateText(path1);
                sw.WriteLine(zalupy.ToString());
                sw.Close();
        }
        if (args.purchasedProduct.definition.id == "add10_money")
        {
                zalupy+=10;
                //Debug.Log(zalupy);
                StreamWriter sw = File.CreateText(path1);
                sw.WriteLine(zalupy.ToString());
                sw.Close();
        }
    }

    private void NoAdd(PurchaseEventArgs args)
    {
        

        StreamWriter sw = File.CreateText(pathads);
        sw.WriteLine("0");
        sw.Close();
    }
}


