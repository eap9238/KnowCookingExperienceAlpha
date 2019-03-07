using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop : MonoBehaviour
{
    public List<string> tags;
    public List<GameObject> solutions;

    Dictionary<string, GameObject> scoopList = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tags.Count; i++)
        {
            scoopList.Add(tags[i], solutions[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (scoopList.ContainsKey(collision.gameObject.tag) && Vector3.Dot((gameObject.transform.up + gameObject.transform.forward) / 2.0f, Vector3.down) < 0)
        {
            collision.SendMessage("scoop");

            //Debug.Log(gameObject.transform.parent.gameObject);
            GameObject temp = Instantiate(scoopList[collision.gameObject.tag], gameObject.transform.position, gameObject.transform.rotation);
            temp.transform.parent = gameObject.transform.parent;
            temp.gameObject.GetComponent<Rigidbody>().useGravity = false;
            temp.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
            //gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
            Destroy(gameObject);
        }
    }
}
