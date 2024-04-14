using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Start()
    {
        transform.position = new Vector3(0, 4.1125f, -10);
    }
    public IEnumerator Shake(float duration, float magnitude) 
    {
        Vector3 originalPos = new Vector3(0, 4.1125f, -10);
        float elapsed = 0;

        while (elapsed < duration) 
        {
            float x = Random.Range(-3f,3f) * magnitude;
            
            transform.position = new Vector3(x, originalPos.y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }
}
