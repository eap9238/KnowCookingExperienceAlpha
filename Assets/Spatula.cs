using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public Dictionary<string, GameObject> flippableObjects = new Dictionary<string, GameObject>();
    public string[] tags;
    public GameObject[] objects;

    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        coolDown = 0;

        for (int i = 0; i < tags.Length; i++)
        {
            flippableObjects.Add(tags[i], objects[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (flippableObjects.ContainsKey(other.gameObject.tag) && coolDown <= 0)
        {
            //Debug.Log("CHOP");
            //GameObject fudge = Instantiate(cutPle, new Vector3(gameObject.transform.positionx, gameObject.transform.position.y, gameObject.transform.position.z));
            //Instantiate(cutPle, gameObject.transform);

            Instantiate(flippableObjects[other.gameObject.tag], other.gameObject.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
            coolDown = 3;

            //Debug.Log(fudge);
            Destroy(other.gameObject);
        }
    }
}
