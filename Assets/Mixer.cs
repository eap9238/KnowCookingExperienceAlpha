using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mixer : MonoBehaviour
{
    public GameObject cookBook;

    private Recipes recipe;
    private float seekMix;
    private float currentMix;
    private TextMeshPro text;
    private List<Collider> visitorList = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshPro>();
        recipe = cookBook.GetComponent<Recipes>();

        currentMix = 0;
        seekMix = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMix == 0)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
            text.text = (Mathf.FloorToInt(currentMix)).ToString("D2");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "RuinedDish" && other.gameObject.tag != "Tool")
        {
            if (visitorList.Count > 0)
            {
                if (currentMix > seekMix)
                {
                    List<Collider> temp = new List<Collider>();

                    foreach (Collider coll in visitorList)
                    {
                        if (coll.gameObject.tag != "RuinedDish" && coll.gameObject.tag != "Tool")
                        {
                            temp.Add(coll);
                        }
                    }

                    mix(recipe.getResult(temp));
                }
            }
        }
        else if (other.gameObject.tag != "RuinedDish" && other.gameObject.tag == "Tool")
        {
            currentMix += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        visitorList.Add(other);

        if (other.gameObject.tag != "RuinedDish" && other.gameObject.tag != "Tool")
        {
            currentMix = 0;

            List<Collider> temp = new List<Collider>();

            foreach (Collider coll in visitorList)
            {
                if (coll.gameObject.tag != "RuinedDish" && coll.gameObject.tag != "Tool")
                {
                    temp.Add(coll);
                }
            }

            seekMix = recipe.calcTime(temp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        visitorList.Remove(other);

        if (other.gameObject.tag != "RuinedDish" && other.gameObject.tag != "Tool")
        {
            currentMix = 0;

            List<Collider> temp = new List<Collider>();

            foreach (Collider coll in visitorList)
            {
                if (coll.gameObject.tag != "RuinedDish" && coll.gameObject.tag != "Tool")
                {
                    temp.Add(coll);
                }
            }

            seekMix = recipe.calcTime(temp);
        }
    }

    private void mix(GameObject result)
    {
        currentMix = 0;

        List<Collider> tools = new List<Collider>();

        while (visitorList.Count > 0)
        {
            if (visitorList[0].gameObject.tag != "RuinedDish" && visitorList[0].gameObject.tag != "Tool")
            {
                Collider temp = visitorList[0];

                visitorList.Remove(temp);
                Destroy(temp.gameObject);
            }
            else
            {
                tools.Add(visitorList[0]);
                visitorList.Remove(visitorList[0]);
            }
        }

        visitorList.AddRange(tools);

        Instantiate(result, gameObject.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }
}
