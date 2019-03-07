using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject shell;
    public GameObject yolk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            Instantiate(shell, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(yolk, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
