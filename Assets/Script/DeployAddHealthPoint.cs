using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAddHealthPoint : MonoBehaviour
{
    public GameObject addHealthPointPrefab;
    public float initialRespawnTime = 20f;
    public float finalRespawnTime = 15f;

    public float initialYPos = 20f;
    public float finalYPos = 30f;

    public float decreaseIntervalOne = 8.0f;
    public float decreaseIntervalTwo = 10.0f;

    public float smallObjectLeftLimit = -8.33f;
    public float smallObjectRightLimit= 8.33f;

    private float currentYPos;
    private float currentRespawnTime;
    // Start is called before the first frame update
    void Start()
    {
        currentYPos = initialYPos;
        currentRespawnTime = initialRespawnTime;
        StartCoroutine(addHealthPointWave());
        StartCoroutine(DecreaseRespawnTime());
        StartCoroutine(IncreaseYPos());
    }
    private void SpawnPoint()
    {
        GameObject ahp = Instantiate(addHealthPointPrefab) as GameObject;
        ahp.transform.position = new Vector3(Random.Range(smallObjectLeftLimit, smallObjectRightLimit), currentYPos, 0f);
    }
    // Update is called once per frame
    private IEnumerator DecreaseRespawnTime()
    {
        while (currentRespawnTime > finalRespawnTime)
        {
            yield return new WaitForSeconds(decreaseIntervalOne);
            currentRespawnTime -= 0.1f;
        }
    }
    private IEnumerator IncreaseYPos()
    {
        while (currentYPos < finalYPos)
        {
            yield return new WaitForSeconds(decreaseIntervalTwo);
            currentYPos += 1.0f;
        }
    }
    IEnumerator addHealthPointWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentRespawnTime);
            SpawnPoint();
        }
    }
}
