using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickManager : MonoBehaviour
{
    public GameObject[] locations;

    int currentLoc = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(UnityEngine.Input.GetJoystickNames());

        gameObject.transform.position = locations[currentLoc].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        /*
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            //Debug.Log("Boogie Woogie");

            RaycastHit hit;

            var cameraCenter = gameObject.GetComponentInParent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, GetComponent<Camera>().nearClipPlane));

            if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000))
            {
                var obj = hit.transform.gameObject;

                Debug.Log(obj + " activate");

                obj.SendMessage("activate");
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.DpadDown))
        {
            //Debug.Log("Boogie Woogie");

            RaycastHit hit;

            var cameraCenter = gameObject.GetComponentInParent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, GetComponent<Camera>().nearClipPlane));

            if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000))
            {
                var obj = hit.transform.gameObject;

                Debug.Log(obj + " pull");

                obj.SendMessage("pull");
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.DpadUp))
        {
            //Debug.Log("Boogie Woogie");

            RaycastHit hit;

            var cameraCenter = gameObject.GetComponentInParent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, GetComponent<Camera>().nearClipPlane));

            if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000))
            {
                var obj = hit.transform.gameObject;

                Debug.Log(obj + " push");

                obj.SendMessage("push");
            }
        }
        */

        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            currentLoc--;

            if (currentLoc < 0)
            {
                currentLoc = locations.Length - 1;
            }

            gameObject.transform.position = locations[currentLoc].transform.position;
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            currentLoc++;

            if (currentLoc >= locations.Length)
            {
                currentLoc = 0;
            }

            gameObject.transform.position = locations[currentLoc].transform.position;
        }

    }
}
