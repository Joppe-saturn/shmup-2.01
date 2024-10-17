using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenwrap : MonoBehaviour
{
    [SerializeField] private GameObject square;
    private void Start()
    {
        for(int i = 0 ; i < 2; i++)
        {
            GameObject child = Instantiate(square, new Vector3(Screen.width / (Screen.height / 11) * (1 - 2 * i), transform.position.y, 0), Quaternion.identity);
            child.transform.parent = transform;
            child.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            child.transform.localScale = transform.localScale;
        }        
    }
}
