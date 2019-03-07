using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool dHand;
    private bool holding;


    // Start is called before the first frame update
    void Start()
    {
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (dHand)
        {
            //Debug.Log("Find " + other.gameObject);
            if (!holding)
            {
                if (other.gameObject.tag == "Tool" || other.gameObject.GetComponent<Ingredient>() != null)
                {
                    //Debug.Log("Meet " + other.gameObject);

                    if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= .5)
                    {
                        //Debug.Log(other.gameObject + " activate");
                        //other.gameObject.SendMessage("activate");
                        //Debug.Log("Grab " + other.gameObject);

                        if (other.gameObject.GetComponent<Rigidbody>() == null)
                        {
                            GameObject oth = other.gameObject.transform.parent.gameObject;

                            oth.transform.SetParent(gameObject.transform);
                            //oth.GetComponent<Rigidbody>().useGravity = false;
                            //oth.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                            oth.GetComponent<Rigidbody>().isKinematic = true;
                            holding = true;
                        }
                        else
                        {
                            other.gameObject.transform.SetParent(gameObject.transform);
                            //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            holding = true;
                        }
                    }
                }
            }
            else if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < .5)
            {
                //Debug.Log(other.gameObject + " activate");
                //other.gameObject.SendMessage("activate");

                holding = false;

                if (other.gameObject.GetComponent<Rigidbody>() != null)
                {
                    if (other.gameObject.transform.parent.gameObject == gameObject)
                    {
                        other.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        
                        other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
                else
                {
                    GameObject oth = other.gameObject.transform.parent.gameObject;

                    if (oth.transform.parent.gameObject == gameObject)
                    {
                        oth.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
                        //oth.GetComponent<Rigidbody>().useGravity = true;
                        //oth.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                        oth.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            }
        }
        else
        {
            //Debug.Log("Find " + other.gameObject);
            if (!holding)
            {
                if (other.gameObject.tag == "Tool" || other.gameObject.GetComponent<Ingredient>() != null)
                {
                    //Debug.Log("Meet " + other.gameObject);

                    if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= .5)
                    {
                        //Debug.Log(other.gameObject + " activate");
                        //other.gameObject.SendMessage("activate");
                        //Debug.Log("Grab " + other.gameObject);

                        if (other.gameObject.GetComponent<Rigidbody>() == null)
                        {
                            GameObject oth = other.gameObject.transform.parent.gameObject;

                            oth.transform.SetParent(gameObject.transform);
                            //oth.GetComponent<Rigidbody>().useGravity = false;
                            //oth.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                            oth.GetComponent<Rigidbody>().isKinematic = true;
                            holding = true;
                        }
                        else
                        {
                            other.gameObject.transform.SetParent(gameObject.transform);
                            //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            holding = true;
                        }
                    }
                }
            }
            else if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < .5)
            {
                //Debug.Log(other.gameObject + " activate");
                //other.gameObject.SendMessage("activate");

                holding = false;

                if (other.gameObject.GetComponent<Rigidbody>() != null)
                {
                    if (other.gameObject.transform.parent.gameObject == gameObject)
                    {
                        other.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                        other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
                else
                {
                    GameObject oth = other.gameObject.transform.parent.gameObject;

                    if (oth.transform.parent.gameObject == gameObject)
                    {
                        oth.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
                        //oth.GetComponent<Rigidbody>().useGravity = true;
                        //oth.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                        oth.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject);

        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.gameObject == gameObject)
            {
                Debug.Log(other.gameObject);

                other.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
                //other.gameObject.GetComponent<Rigidbody>().useGravity = true;

                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                holding = false;
            }
        }
        else
        {
            GameObject oth = other.gameObject.transform.parent.gameObject;

            if (oth.transform.parent != null && oth.transform.parent.gameObject == gameObject)
            {
                Debug.Log(oth);

                oth.transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
                //oth.GetComponent<Rigidbody>().useGravity = true;

                oth.GetComponent<Rigidbody>().isKinematic = false;

                holding = false;
            }
        }
    }
}
