using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private int volume;

    private void Awake()
    {
        for (int i = 0; i < volume; i++)
        {
            GameObject star = Instantiate(particle, new Vector3(Random.Range(-Screen.width / (Screen.height / 4.5f), Screen.width / (Screen.height / 4.5f)), Random.Range(Screen.height / (-Screen.width / 3.0f), Screen.height / (Screen.width / 3.0f)), 0), Quaternion.identity);
            star.GetComponent<StarMove>().speed = Random.Range(1.0f, 1.5f);
        }
    }
}
