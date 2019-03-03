using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(UnityEngine.Input.GetJoystickNames());
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Boogie Woogie");

            RaycastHit hit;

            var cameraCenter = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, GetComponent<Camera>().nearClipPlane));

            if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000))
            {
                var obj = hit.transform.gameObject;
            }
        }

        
    }

    // OnClick
    private void OnMouseDown()
    {
    }
}
