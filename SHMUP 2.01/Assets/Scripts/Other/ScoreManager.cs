using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    [SerializeField] private GameObject square;
    [SerializeField] private int maxScoreDigits;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    private string playerName;
    private bool updatedScore = false;
    private Player player;
    private HighScoreManager highScoreManager;

    private void Start()
    {
        playerName = PlayerPrefs.GetString("currentPlayer");
        player = FindAnyObjectByType<Player>();
        highScoreManager = FindFirstObjectByType<HighScoreManager>();
    }

    private void Update()
    {
        for(int i  = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        
        int currentMaxScore = 1;
        for (int i = 1; i < score; i *= 10)
        {
            currentMaxScore++;
        }

        for (int i = 0; i < currentMaxScore; i++)
        {
            GameObject currentNumber = Instantiate(square, new Vector3(2.75f - 0.25f * currentMaxScore + 0.25f * i, -4.5f, 0), Quaternion.identity);
            currentNumber.transform.parent = transform;
            int index = Mathf.FloorToInt(score / Mathf.Pow(10, currentMaxScore - i - 1) - Mathf.Floor(score / Mathf.Pow(10, currentMaxScore - i)) * 10);
            currentNumber.GetComponent<SpriteRenderer>().sprite = sprites[index];
        }

        if(!updatedScore && player.health < 1)
        {
            highScoreManager.ShowScores(playerName, score);
            updatedScore = true;
        }
    }
}
