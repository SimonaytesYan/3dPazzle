using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float rot = 0;
    static  int lvlnmb;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "next")
            lvlnmb = GetComponent<MyMouse>().lastlvl1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == lvlnmb.ToString())
        {
            transform.position = new Vector3(0, 0, -29);
            rot += (float)3;
            if (rot > 359.9)
                rot = rot % 360;
            transform.rotation = Quaternion.Euler(0, rot, 0);
        }
    }
}
