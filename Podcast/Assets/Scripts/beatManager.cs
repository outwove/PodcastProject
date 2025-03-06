using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class beatManager : MonoBehaviour
{
    public GameObject beatPrefab;

    private List<GameObject> beats = new List<GameObject>();

    // Array of predefined positions
    public Vector2[] beatPositions = {
        new Vector2(125, 149), new Vector2(194, 300), new Vector2(377, 305), new Vector2(394, 94)
    };

    public int beatsIndex = 0; // Tracks the active beat
    public float spawnInterval = 1.5f; // Time between each beat spawn

    void Start()
    {
        StartCoroutine(SpawnBeatsDynamically());
    }

    IEnumerator SpawnBeatsDynamically()
    {
        while (beatsIndex < beatPositions.Length)
        {
            Vector2 screenPos = beatPositions[beatsIndex];
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane + 5f));

            GameObject newBeat = Instantiate(beatPrefab, worldPos, Quaternion.identity);
            newBeat.SetActive(true); // Ensure it's visible

            // Start with half opacity
            SpriteRenderer sprite = newBeat.GetComponentInChildren<SpriteRenderer>();
            Color color = sprite.color;
            color.a = 0.5f;
            sprite.color = color;

            beats.Add(newBeat);

            // Start fade-in effect
            StartCoroutine(FadeInBeat(sprite));

            beatsIndex++;

            // Wait before spawning the next beat
            yield return new WaitForSeconds(spawnInterval);
            }
        }

    void SpawnBeats()
    {
        for (int i = 0; i < beatPositions.Length; i++)
        {
            Vector2 screenPos = beatPositions[i];
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane + 5f));

            GameObject newBeat = Instantiate(beatPrefab, worldPos, Quaternion.identity);
            newBeat.SetActive(true); // Ensure it's visible

            // Start with half opacity
            SpriteRenderer sprite = newBeat.GetComponentInChildren<SpriteRenderer>();
            Color color = sprite.color;
            color.a = 0.5f;
            sprite.color = color;

            beats.Add(newBeat);

            // Start fade-in effect
            StartCoroutine(FadeInBeat(sprite));
        }
    }



    IEnumerator FadeInBeat(SpriteRenderer sprite)
    {
        float duration = 1.0f; // Fade-in duration
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0.5f, 1f, elapsedTime / duration);
            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure full opacity
        Color finalColor = sprite.color;
        finalColor.a = 1f;
        sprite.color = finalColor;
    }
}
