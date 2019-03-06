using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooped : MonoBehaviour
{
    public GameObject baseScoop;
    public GameObject contents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Dot(gameObject.transform.up, Vector3.down) > 0)
        {
            upsideDown();
        }
    }

    private void upsideDown()
    {
        Instantiate(contents, gameObject.transform.position + (gameObject.transform.up * 0.5f), Quaternion.identity);
        Instantiate(baseScoop, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent);

        Destroy(gameObject);
    }
}
