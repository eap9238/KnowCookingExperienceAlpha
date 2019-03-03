using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private GameObject player;
    private bool parented;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parented = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (parented)
        {
            //transform.LookAt(player.transform);
            gameObject.GetComponent<Rigidbody>().velocity = Vector2.zero;
        }
    }

    public void activate()
    {
        if (!parented)
        {
            gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        parented = !parented;
    }

    public void push()
    {
        if (parented)
        {
            //gameObject.transform.Translate((gameObject.transform.position - player.transform.position) / 100);
            //gameObject.transform.Translate((gameObject.transform.right) / 10);

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1);
        }
    }

    public void pull()
    {
        if (parented && (transform.position - player.transform.position).magnitude >= 1.5f)
        {
            //gameObject.transform.Translate((player.transform.position - gameObject.transform.position) / 100);
            //gameObject.transform.Translate((-gameObject.transform.right) / 10);
            //gameObject.GetComponent<Rigidbody>().

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1);
        }
    }

    /*

    public void left()
    {
        if (parented)
        {
            //gameObject.transform.Translate((gameObject.transform.position - player.transform.position) / 100);
            gameObject.transform.Translate((gameObject.transform.forward) / 10);
        }
    }

    public void right()
    {
        if (parented)
        {
            //gameObject.transform.Translate((player.transform.position - gameObject.transform.position) / 100);
            gameObject.transform.Translate((-gameObject.transform.forward) / 10);
        }
    }

    */

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
