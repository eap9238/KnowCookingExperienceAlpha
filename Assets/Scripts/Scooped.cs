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

        if (Vector3.Dot((gameObject.transform.up + gameObject.transform.forward) / 2.0f, Vector3.down) > 0)
        {
            upsideDown();
        }
    }

    private void upsideDown()
    {
        //Debug.Log(gameObject.transform.parent.gameObject);
        Instantiate(contents, gameObject.transform.position + (gameObject.transform.up * 0.5f) + (gameObject.transform.forward * 0.75f), Quaternion.identity);
        GameObject temp = Instantiate(baseScoop, gameObject.transform.position, gameObject.transform.rotation);
        temp.transform.parent = gameObject.transform.parent;
        temp.gameObject.GetComponent<Rigidbody>().useGravity = false;
        temp.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
        Destroy(gameObject);
    }
}
