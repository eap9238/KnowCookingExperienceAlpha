using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cooker : MonoBehaviour
{
    public GameObject cookBook;
    
    private Recipes recipe;
    private float seekTime;
    private float cookTime;
    private TextMeshPro text;

    private List<Collider> visitorList = new List<Collider>();
    private GameObject[] heatingElements;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshPro>();
        recipe = cookBook.GetComponent<Recipes>();

        heatingElements = GameObject.FindGameObjectsWithTag("Heatingelement");

        cookTime = 0;
        seekTime = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (cookTime == 0)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
            text.text = Mathf.Floor(cookTime / 60) + ":" + Mathf.FloorToInt(cookTime % 60).ToString("D2");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (visitorList.Contains(other))
        {
            foreach (GameObject element in heatingElements)
            {
                if ((Vector3.Distance(gameObject.transform.position, element.transform.position)) < .2)
                {
                    if (cookTime > seekTime)
                    {
                        cook(recipe.getResult(visitorList));
                    }
                    else
                    {
                        cookTime += Time.deltaTime / visitorList.Count;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            if (other.gameObject.tag != "RuinedDish" && other.gameObject.tag != "Tool")
            {
                visitorList.Add(other);

                cookTime = 0;

                seekTime = recipe.calcTime(visitorList);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (visitorList.Contains(other))
        {
            visitorList.Remove(other);

            cookTime = 0;

            seekTime = recipe.calcTime(visitorList);
        }
    }

    private void cook(GameObject result)
    {
        cookTime = 0;

        while (visitorList.Count > 0)
        {
            Collider temp = visitorList[0];

            visitorList.Remove(temp);
            Destroy(temp.gameObject);
        }

        Instantiate(result, gameObject.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }
}
