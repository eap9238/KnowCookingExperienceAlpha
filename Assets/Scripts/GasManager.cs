using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasManager : MonoBehaviour
{
    private bool fireOn = false;
    public GameObject gas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        if (fireOn)
        {
            gas.transform.position -= new Vector3(0, 0.125f, 0);
            Debug.Log("Off");
        }
        else
        {
            gas.transform.position += new Vector3(0, 0.125f, 0);
            Debug.Log("On");
        }

        fireOn = !fireOn;
    }
}
