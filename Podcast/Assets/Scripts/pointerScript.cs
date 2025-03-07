using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.UI;
using UnityEngine;

public class pointerScript : MonoBehaviour
{
    public AudioSource clickSound;
    public beatManager beatManagerScript;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("pointer start");
    }

    // Update is called once per frame
    void Update()
    {
        // gets the coordinates of the mouse relative to the window's coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -3;
        transform.position = mousePosition;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A))
        {

            Collider2D[] hitColliders = Physics2D.OverlapPointAll(mousePosition);

            foreach (Collider2D hit in hitColliders)
            {
                if (hit.CompareTag("beat"))
                {
                    hit.gameObject.SetActive(false);
                    Debug.Log(Input.mousePosition);
                    // updates the active beat index to the next beat
                    beatManagerScript.activeBeatIndex++;

                    // Play sound effect
                    if (clickSound != null)
                    {
                        clickSound.PlayOneShot(clickSound.clip);
                    }
                    else
                    {
                        Debug.LogWarning("No AudioSource assigned to PointerScript!");
                    }
                }
            }
        }
    }
}
