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
    private List<Collider> toolList = new List<Collider>();

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
        if (other.gameObject.tag == "Tool")
        {
            if (visitorList.Count > 0)
            {
                currentMix += Time.deltaTime / toolList.Count;
            }
        }
        else if (other.gameObject.tag != "RuinedDish")
        {
            if (currentMix > seekMix)
            {
                mix(recipe.getResult(visitorList));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tool")
        {
            toolList.Add(other);
        }
        else if (other.gameObject.tag != "RuinedDish")
        {
            visitorList.Add(other);

            currentMix = 0;

            seekMix = recipe.calcTime(visitorList);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tool")
        {
            toolList.Remove(other);
        }
        else if (other.gameObject.tag != "RuinedDish")
        {
            visitorList.Remove(other); 

            currentMix = 0;
            
            seekMix = recipe.calcTime(visitorList);
        }       
    }

    private void mix(GameObject result)
    {
        currentMix = 0;

        List<Collider> tools = new List<Collider>();

        while (visitorList.Count > 0)
        {
            Collider temp = visitorList[0];

            visitorList.Remove(temp);
            Destroy(temp.gameObject);
        }

        Instantiate(result, gameObject.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }
}
