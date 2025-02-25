using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.UI;
using UnityEngine;

public class pointerScript : MonoBehaviour
{
    public GameObject beat;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {
        // gets the coordinates of the mouse relative to the window's coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log(Input.mousePosition);
            beat.SetActive(false);
        }
    }
}
