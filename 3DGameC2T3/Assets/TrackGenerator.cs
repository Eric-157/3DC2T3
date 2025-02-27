using UnityEngine;
using System.Collections.Generic;

public class TrackGenerator : MonoBehaviour
{
    public List<GameObject> trackPrefabs; // List of track prefabs assigned in the inspector
    public float trackLength = 3.213f; // Length of each track segment
    public int initialTracks = 10; // Number of tracks to pre-spawn

    private float spawnPosition = 0f; // Position where the next track will spawn
    private List<GameObject> activeTracks = new List<GameObject>();

    void Start()
    {
        // Spawn initial tracks
        for (int i = 0; i < initialTracks; i++)
        {
            SpawnTrack();
        }
    }

    void Update()
    {
        // Remove any destroyed tracks from the list
        activeTracks.RemoveAll(track => track == null);

        // If the first track has moved past the spawn position, we recycle it
        if (activeTracks.Count > 0 && activeTracks[0].transform.position.z < spawnPosition - trackLength)
        {
            RecycleTrack();
        }
    }

    void SpawnTrack()
    {
        // Instantiate a new track at the current spawn position
        GameObject newTrack = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Count)], new Vector3(0, 0, spawnPosition), Quaternion.identity);
        newTrack.tag = "Track"; // Assign the tag to the new track
        activeTracks.Add(newTrack); // Add it to the active tracks list

        // Update spawn position for the next track
        spawnPosition += trackLength;
    }

    void RecycleTrack()
    {
        // Remove the first track that has moved far enough off-screen
        GameObject trackToRecycle = activeTracks[0];
        activeTracks.RemoveAt(0); // Remove it from the active list

        // Reposition the track at the end of the sequence to maintain consistency
        trackToRecycle.transform.position = new Vector3(0, 0, spawnPosition);

        // Add the recycled track to the back of the active tracks list
        activeTracks.Add(trackToRecycle);

        // Update the spawn position for the next track
        spawnPosition += trackLength;
    }
}
