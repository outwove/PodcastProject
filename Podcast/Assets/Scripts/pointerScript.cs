using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.UI;
using UnityEngine;

public class pointerScript : MonoBehaviour
{
    public GameObject beat;
    public beatManager beatManagerScript;


    private GameObject currentCollidedBeat;
    // Start is called before the first frame update
    void Start()
    {

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

        // gets the position of the mouse when clicked
        /*if(Input.GetMouseButtonDown(0)){
            Debug.Log(Input.mousePosition);
        }*/

        // checks if the user recently collided with a beat
        if (currentCollidedBeat != null && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Make beat invis");
            currentCollidedBeat.gameObject.SetActive(false);
            currentCollidedBeat = null;

            // updates the active beat
            beatManagerScript.beatsIndex += 1;
        }
    }

    // stores a reference to the beat the user is hovering over
    void OnTriggerEnter2D(Collider2D collidedBeat)
    {
        Debug.Log("pointer collided");
        if(collidedBeat.CompareTag("beat")){
            //Debug.Log("collided " + collidedBeat.tag);
            currentCollidedBeat = collidedBeat.gameObject;
        }
    }
}
