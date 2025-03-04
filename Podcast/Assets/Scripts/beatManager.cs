using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatManager : MonoBehaviour
{
    public GameObject beat;

    // array of gameobjects
    List<GameObject> beats = new List<GameObject>();

    // array that stores the positions the beats will be at
    public Vector2[,] beatPositions = new Vector2[,] {
        {new Vector2(125, 149), new Vector2(194, 300), new Vector2(377, 305), new Vector2(394, 94)}
    };

    private int beatsIndex = 0; // keeps track of which beat is active in the list

    // keeps track of which position set the beats will be spawning at
    private int positionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // sets each beat to the position at the corresponding column index in beatPositions
        for(int positionCol = 0; positionCol < 4; positionCol++){
            Vector2 screenPosition = beatPositions[0, positionCol];
            Vector3 worldPosition3D = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0)); // Adjust Z if needed
            Vector2 worldPosition = new Vector2(worldPosition3D.x, worldPosition3D.y);

            beats.Add(Instantiate(beat, worldPosition, Quaternion.identity));
            Debug.Log("added beat" + beats[positionCol].transform.position.z);
            //Debug.Log(beats[positionCol].activeSelf);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
