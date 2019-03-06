using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoopable : MonoBehaviour
{
    public float count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void scoop()
    {
        count -= 1;

        if (count == 0)
        {
            Destroy(gameObject);
        }
    }
}
