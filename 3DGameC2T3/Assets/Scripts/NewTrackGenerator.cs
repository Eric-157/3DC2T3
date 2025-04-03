using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewTrackGenerator : MonoBehaviour
{
    public List<GameObject> trackPrefabs;
    public bool trackInSpawner = false;
    private Vector3 spawnPosition;
    private int initialTracks = 0;
    public GameObject tempTrack;
    private GameObject newTrack;
    private float scale;
    PlayerMovement playerMovement;
    void Start()
    {
        GameObject[] playerArray = GameObject.FindGameObjectsWithTag("Player");
        playerMovement = playerArray[0].GetComponent<PlayerMovement>();

        scale = transform.localScale.z;
        spawnPosition = transform.position;
        for (int i = 0; i < initialTracks; i++)
        {
            InitialSpawnTrack();
            if (i == 0)
            {
                newTrack = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Count)], spawnPosition, Quaternion.identity);
            }

        }
        spawnPosition = transform.position;
    }

    void Update()
    {
        if (playerMovement.alive && playerMovement.startGame)
        {
            if (tempTrack == null)
            {
                SpawnTrack();
            }
            if (transform.position.z - tempTrack.transform.position.z > (scale - 0.02))
            {
                SpawnTrack();
            }
        }
    }

    void SpawnTrack()
    {
        newTrack = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Count)], spawnPosition, Quaternion.identity);
        newTrack.tag = "Track";
        tempTrack = newTrack;
    }

    void InitialSpawnTrack()
    {
        newTrack = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Count)], spawnPosition -= new Vector3(0, 0, 3), Quaternion.identity);
        newTrack.tag = "Track";
    }
}
