using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Character player;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject square;
    private List<GameObject> healthDisplay = new List<GameObject>();

    private void Awake()
    {
        player = GetComponent<Character>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        for(int i = 0; i < healthDisplay.Count; i++)
        {
            Destroy(healthDisplay[i]);
        }
        healthDisplay.Clear();
        for(int i = 0; i < player.health; i++)
        {
            healthDisplay.Add(Instantiate(square, new Vector3(Screen.width / (Screen.height / -6) + (i + 1) * 0.5f, -4.5f, 0), Quaternion.identity));
            healthDisplay[i].GetComponent<SpriteRenderer>().sprite = spriteRenderer.sprite;
        }
    }
}
