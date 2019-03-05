using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pan : MonoBehaviour
{
    public GameObject cookBook;
    
    private Recipes recipe;
    private float seekTime;
    private float cookTime;
    private TextMeshPro text;
    private List<Collider> visitorList = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshPro>();
        recipe = cookBook.GetComponent<Recipes>();

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
        if (other.gameObject.tag != "RuinedDish")
        {
            if (visitorList.Count > 0)
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

    private void OnTriggerEnter(Collider other)
    {
        visitorList.Add(other);

        cookTime = 0;
        seekTime = recipe.calcTime(visitorList);
    }

    private void OnTriggerExit(Collider other)
    {
        visitorList.Remove(other);

        cookTime = 0;
        seekTime = recipe.calcTime(visitorList);
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
