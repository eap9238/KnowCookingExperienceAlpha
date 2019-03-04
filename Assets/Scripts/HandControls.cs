using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControls : MonoBehaviour
{
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += ((Input.mousePosition - lastPosition) / 100);

        lastPosition = Input.mousePosition;
    }
}
