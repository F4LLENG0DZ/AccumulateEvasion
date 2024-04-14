using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    private float wait_time = 4f;
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro() 
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene("MenuScene");
    }
}
