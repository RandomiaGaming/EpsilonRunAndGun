using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float scaleX = 1;
    public int gunstate = 1;
	void Update () {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse = new Vector3(mouse.x, mouse.y, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.right = (mouse - transform.position) * -1;

        Generate();
    }
    void Generate()
    {
        print(gameObject.transform.right);
        float rot = transform.rotation.z;
        if(between(rot, 0, 22.5f))
        {
            gunstate = 4;
        }else if (between(rot, 22.5f, 67.5f))
        {
            gunstate = 3;
            scaleX = 1;
        }
        else if(between(rot, 67.5f, 112.5f))
        {
            gunstate = 2;
            scaleX = 1;
        }
        else if (between(rot, 112.5f, 157.5f))
        {
            gunstate = 1;
            scaleX = 1;
        }
        else if(between(rot, 157.5f, 180))

        {
            gunstate = 0;

        }else if (between(rot, 180, 202.5f))
        {

        }
        else if(between(rot, 202.5f, 247.5f))
        {
            scaleX = -1;
        }
        else if (between(rot, 247.5f, 292.5f))
        {
            scaleX = -1;
        }
        else if(between(rot, 292.5f, 337.5f))
        {
            scaleX = -1;
        }
        else if (between(rot, 337.5f, 360))
        {

        }

        
    }
    bool between(float value, float min, float max)
    {
        bool output = false;
        if(value >= min && value <= max)
        {
            output = true;
        }
        return output;
    }
}
