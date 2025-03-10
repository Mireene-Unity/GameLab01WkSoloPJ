using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    private bool isGameStop = false;
    public List<GameObject> fishList;
    public List<GameObject> Position;
    public float spawnTime = 2f;
    private Vector3 spawnPosition;

    void Start()
    {
        StartCoroutine(SpawnFish());
    }
    IEnumerator SpawnFish()
    {
        if(isGameStop)
        {
            yield break;
        }
        int randomPositionIndex = Random.Range(0, Position.Count);
        int randomFishListIndex = Random.Range(0, fishList.Count);
        spawnPosition = Position[randomPositionIndex].transform.position;
        Instantiate(fishList[randomFishListIndex], spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnFish());
    }
}
