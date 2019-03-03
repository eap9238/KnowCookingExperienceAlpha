using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject cutPle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CHOP");
        //GameObject fudge = Instantiate(cutPle, new Vector3(gameObject.transform.positionx, gameObject.transform.position.y, gameObject.transform.position.z));
        //Instantiate(cutPle, gameObject.transform);

        Instantiate(cutPle, gameObject.transform.position, Quaternion.identity);
        Instantiate(cutPle, gameObject.transform.position, Quaternion.identity);

        //Debug.Log(fudge);
        Destroy(gameObject);
    }
}
