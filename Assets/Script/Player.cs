using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.3f;
    public float leftLimit = -7.43f;
    public float rightLimit = 7.43f;

    public Rigidbody Rigidbodyrb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + transform.right * -speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + transform.right * speed;
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
    }

    public void Froze() 
    {
        speed = 0.0f;
    }

    public void UnFroze() 
    {
        speed = 0.3f;
    }
}
