using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBigObstacles : MonoBehaviour
{ 
public GameObject bigObstaclesPrefab;
public float initialRespawnTime = 5f;
public float finalRespawnTime = 1f;

public float initialYPos = 20f;
public float finalYPos = 3.40282346638528860e+38f;

public float decreaseIntervalOne = 5.0f;
public float decreaseIntervalTwo = 10.0f;

public float bigObjectLeftLimit = -4.5f;
public float bigObjectRightLimit= 4.5f;

private float currentYPos;
private float currentRespawnTime;
// Start is called before the first frame update
void Start()
{
    currentYPos = initialYPos;
    currentRespawnTime = initialRespawnTime;
    StartCoroutine(BigObstaclesWave());
    StartCoroutine(DecreaseRespawnTime());
    StartCoroutine(IncreaseYPos());
}
private void SpawnPoint()
{
    GameObject bO = Instantiate(bigObstaclesPrefab) as GameObject;
    bO.transform.position = new Vector3(Random.Range(bigObjectLeftLimit, bigObjectRightLimit), currentYPos, 0f);
}
// Update is called once per frame
private IEnumerator DecreaseRespawnTime()
{
    while (currentRespawnTime > finalRespawnTime)
    {
        yield return new WaitForSeconds(decreaseIntervalOne);
        currentRespawnTime -= 0.5f;
    }
}
private IEnumerator IncreaseYPos()
{
    while (currentYPos < finalYPos)
    {
        yield return new WaitForSeconds(decreaseIntervalTwo);
        currentYPos += 5.0f;
    }
}
IEnumerator BigObstaclesWave()
{
    while (true)
    {
        yield return new WaitForSeconds(currentRespawnTime);
        SpawnPoint();
    }
}
}
