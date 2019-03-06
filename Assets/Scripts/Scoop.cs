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
        if (scoopList.ContainsKey(collision.gameObject.tag))
        {
            collision.SendMessage("scoop");

            Instantiate(scoopList[collision.gameObject.tag], gameObject.transform.position, Quaternion.identity, gameObject.transform.parent);

            Destroy(gameObject);
        }
    }
}
