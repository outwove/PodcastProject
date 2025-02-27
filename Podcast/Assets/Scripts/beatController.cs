using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatController : MonoBehaviour
{
    public GameObject beatPrefab;
    public Vector2 beatPostion;

    void Start()
    {
        SpawnBeat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBeat()
    {
        if (beatPrefab != null) 
        {
            //GameObject newBeat = Instantiate(beatPrefab, beatPosition, );
        }
    }

}
