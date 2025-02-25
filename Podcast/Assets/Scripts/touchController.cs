using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class touchController : MonoBehaviour
{
    public float tapRadius = 0.5f;

    void Start()
    {
        Debug.Log(Screen.dpi);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
