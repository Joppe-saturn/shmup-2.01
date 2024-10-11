using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public float speed = 1;

    private void Update()
    {
        transform.position += -transform.up * speed / 100 * Time.timeScale;
        if (transform.position.y < Screen.height / (Screen.width / -3.0f))
        {
            transform.position = new Vector3(transform.position.x, Screen.height / (Screen.width / 3.0f), 0);
        }
    }
}
