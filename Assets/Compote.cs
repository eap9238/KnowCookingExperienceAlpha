using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compote : MonoBehaviour
{
    public GameObject compote;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Instantiate(compote, gameObject.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
