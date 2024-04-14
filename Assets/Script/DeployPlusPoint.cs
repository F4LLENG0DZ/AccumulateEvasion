using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPlusPoint : MonoBehaviour
{
    public GameObject plusPointPrefab;
    public float initialRespawnTime = 1.5f;
    public float finalRespawnTime = 0.1f;

    public float initialYPos = 12f;
    public float finalYPos = 3.40282346638528860e+38f;

    public float decreaseIntervalOne = 5.0f;
    public float decreaseIntervalTwo = 10.0f;

    public float smallObjectLeftLimit = -8.33f;
    public float smallObjectRightLimit = 8.33f;

    private float currentYPos;
    private float currentRespawnTime;
    // Start is called before the first frame update
    void Start()
    {
        currentYPos = initialYPos;
        currentRespawnTime = initialRespawnTime;
        StartCoroutine(plusPointWave());
        StartCoroutine(DecreaseRespawnTime());
        StartCoroutine(IncreaseYPos());
    }
    private void SpawnPoint() 
    {
        GameObject p = Instantiate(plusPointPrefab) as GameObject;
        p.transform.position = new Vector3(Random.Range(smallObjectLeftLimit, smallObjectRightLimit), currentYPos, 0f);
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
    IEnumerator plusPointWave() 
    {
        while (true)
        {
            yield return new WaitForSeconds(currentRespawnTime);
            SpawnPoint();
        }
    }
}
