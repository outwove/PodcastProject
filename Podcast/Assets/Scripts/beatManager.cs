using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class beatManager : MonoBehaviour
{
    public GameObject beatPrefab;
    public AudioSource musicSource;


    private List<GameObject> beats = new List<GameObject>();


    // Array of predefined positions (hardcoded list dont matta go to the component)
    public Vector2[] beatPositions = {
        new Vector2(125, 149), new Vector2(194, 300), new Vector2(377, 305), new Vector2(394, 94)
    };

    //tracks the beat location index in the beatPositions array
    public int beatsIndex = 0;
    // tracks which beat is active
    public int activeBeatIndex = 0;

    //time between each beat spawn (TEMPORARY)
    public float spawnInterval = 1;

    void Start()
    {
        StartCoroutine(SpawnBeatsDynamically());
    }

    void Update()
    {
        beats[activeBeatIndex].SetActive(true);
        beats[activeBeatIndex+1].SetActive(true);
    }
    //temporary for spawning beats before we have a list of beat times from scotts project to work w
    //flaw: it spawns beats at a set interval when we need to customize the timing

    IEnumerator SpawnBeatsDynamically()
    {
        while (beatsIndex < beatPositions.Length)
        {
            Vector2 screenPos = beatPositions[beatsIndex];
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane + 5f));

            GameObject newBeat = Instantiate(beatPrefab, worldPos, Quaternion.identity);

            // makes the beats initially invisible
            newBeat.SetActive(false);

            // Start with half opacity
            SpriteRenderer sprite = newBeat.GetComponentInChildren<SpriteRenderer>();

            beats.Add(newBeat);

            // Start fade-in effect
            StartCoroutine(FadeInBeat(sprite));

            // makes the beat at activeBeatIndex have full opacity
            SpriteRenderer activeBeatSprite = beats[activeBeatIndex].GetComponentInChildren<SpriteRenderer>();
            Color activeColor = activeBeatSprite.color;
            activeColor.a = 1f;
            activeBeatSprite.color = activeColor;

            beatsIndex++;

            // Wait before creating the next beat
            yield return new WaitForSeconds(spawnInterval);
            }
        }

    // The IEnumerator that checks AudioSource.time and spawns beats at the right moments. This is to replace SpawnBeatsDynamically(), bcuz we dont need it no more!!!
    //IEnumerator SpawnBeatsAtTimes()
    //{
    //    while (currentBeatIndex < beatTimes.Length)
    //    {
    //        //check if the music time is greater than or equal to the next spawn time
    //        if (musicSource.time >= beatTimes[currentBeatIndex])
    //        {
    //            //spawn the beat at the correct position
    //            SpawnBeat();
    //
    //            //move to the next beat time
    //            currentBeatIndex++;
    //        }
    //
    //        //wait for a short period before checking again (e.g., 0.1 seconds)
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    //not referenced until we have SpawnBeatsAtTimes() implemented
    void SpawnBeats()
    {
        for (int i = 0; i < beatPositions.Length; i++)
        {
            Vector2 screenPos = beatPositions[i];
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane + 5f));

            GameObject newBeat = Instantiate(beatPrefab, worldPos, Quaternion.identity);
            newBeat.SetActive(true); // Ensure it's visible

            //start with half opacity
            SpriteRenderer sprite = newBeat.GetComponentInChildren<SpriteRenderer>();
            Color color = sprite.color;
            color.a = 0.1f;
            sprite.color = color;

            beats.Add(newBeat);

            //start fade-in effect
            StartCoroutine(FadeInBeat(sprite));
        }
    }



    IEnumerator FadeInBeat(SpriteRenderer sprite)
    {
        //fade-in duration
        float duration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0.0f, 0.3f, elapsedTime / duration);
            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
