using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{
    public GameObject water;

    private bool flow = false;

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
        if (flow)
        {
            water.SetActive(false);
        }
        else
        {
            water.SetActive(true);
        }

        flow = !flow;
    }
}
