using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cakeCount // your custom enumeration
{
    None,
    One,
    Two,
    Three
};

public class Stack : MonoBehaviour
{
    public cakeCount count;  // this public var should appear as a drop down
    public GameObject baseCake;
    public GameObject basePlate;
    public GameObject aheadCake;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cookedcake")
        {
            if (count != cakeCount.Three)
            {
                Instantiate(aheadCake, gameObject.transform.position, Quaternion.identity);

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Compote")
        {
            if (count == cakeCount.Three)
            {
                Instantiate(aheadCake, gameObject.transform.position, Quaternion.identity);

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void upsideDown()
    {
        if (count == cakeCount.One)
        {
            Instantiate(basePlate, gameObject.transform.position - gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 2, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position + gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 2, Quaternion.identity);
        }
        else if (count == cakeCount.Two)
        {
            Instantiate(basePlate, gameObject.transform.position - gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 2, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position + gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 2, Quaternion.identity);
        }
        else
        {
            Instantiate(basePlate, gameObject.transform.position - gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 2, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position + gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 2, Quaternion.identity);
            Instantiate(baseCake, gameObject.transform.position + gameObject.transform.up * baseCake.GetComponent<CapsuleCollider>().radius * 4, Quaternion.identity);
        }
    }
}
