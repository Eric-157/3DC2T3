using UnityEngine;
using System.Collections.Generic;

public class TrackGenerator : MonoBehaviour
{
    public List<GameObject> trackPrefabs;
    public float trackLength = 3.213f;
    public int initialTracks = 10;
    private float spawnPosition = 0f;
    public bool trackInSpawner = false;
    private List<GameObject> activeTracks = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialTracks; i++)
        {
            SpawnTrack();
        }
    }

    void Update()
    {
        // activeTracks.RemoveAll(track => track == null);
        // if (activeTracks.Count > 0 && activeTracks[0].transform.position.z < spawnPosition - trackLength)
        // {
        //     RecycleTrack();
        // }

        // If spawncollider = false, spawnTrack
    }

    void SpawnTrack()
    {
        GameObject newTrack = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Count)], new Vector3(0, 0, spawnPosition), Quaternion.identity);
        newTrack.tag = "Track";
        activeTracks.Add(newTrack);
        spawnPosition += trackLength;
    }

    // This function DOES NOT WORK! It causes a bug that launches the tracks the other direction.
    void RecycleTrack()
    {
        GameObject trackToRecycle = activeTracks[0];
        activeTracks.RemoveAt(0);
        // I believe this is the culprit here, but I can't check since removing this also removes the recycling functionality.
        trackToRecycle.transform.position = new Vector3(0, 0, spawnPosition);
        activeTracks.Add(trackToRecycle);
        spawnPosition += trackLength;
    }
    /***********************************
    * TRY: New solution.
    * Since SpawnTrack works, I'll instead try a trigger system in the engine.
    * The only thing I should need to fix after that is a spacing bug.
    * The spacing bug is related to the spawnPosition variable used in SpawnTrack.
    * It doubles every 10 set.
    ***********************************/

    void OnTriggerEnter(Collider other)
    {
        trackInSpawner = true;
    }
    void OnTriggerExit(Collider other)
    {
        trackInSpawner = true;
    }
}
