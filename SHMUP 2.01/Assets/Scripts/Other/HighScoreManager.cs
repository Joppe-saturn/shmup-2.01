using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [System.Serializable]
    public class HighScores
    {
        public string player;
        public int score;

        public HighScores(string player, int score)
        {
            this.player = player;
            this.score = score;
        }
    }
    
    [SerializeField] public List<HighScores> scores;

    static int SortByScore(HighScores h1, HighScores h2) //Got this from https://discussions.unity.com/t/sorting-a-list-by-variable/100957/2
    {
        return h2.score.CompareTo(h1.score);
    }

    private void Start()
    {
        scores.Clear();
        Reset();
        UpdateScoreList();
        HideScores();
    }

    public void ShowScores(string playerName = "", int playerScore = 0)
    {
        UpdateScoreList();
        bool isNewPlayer = true;
        int currentPlayer = 0;

        for (int i = 0; i < scores.Count; i++)
        {
            if(scores[i].player == playerName)
            {
                if (scores[i].score < playerScore)
                {
                    scores[i].score = playerScore;
                }
                isNewPlayer = false;
                break;
            }
        }

        if(isNewPlayer)
        {
            PlayerPrefs.SetInt(playerName, playerScore);

            string newPlayerName = playerName;
            for (int i = 0; i < 10 - playerName.Length; i++)
            {
                newPlayerName += "@";
            }
            PlayerPrefs.SetString("playerInfo", PlayerPrefs.GetString("playerInfo") + newPlayerName);
            UpdateScoreList();
        }

        scores.Sort(SortByScore);
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i].player == playerName)
            {
                currentPlayer = i;
                break;
            }
        }

        string displayedMessage = "High Scores: \n";

        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i].score < 0)
            {
                break;
            }
            string addInfo = i + 1 + ". " + scores[i].player + " - " + scores[i].score;
            if(i == currentPlayer)
            {
                addInfo = @"<b>" + addInfo + "</b>";
            }
            displayedMessage += addInfo + "\n";
            if(i > 8)
            {
                break;
            }
        }
        displayedMessage += "----------\n" + @"<b>" + (currentPlayer + 1) + ". " + scores[currentPlayer].player + " - " + scores[currentPlayer].score + "</b>";

        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = displayedMessage;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        scores.Clear();
    }

    public void HideScores()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void UpdateScoreList()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt(scores[i].player, scores[i].score);
        }
        scores.Clear();
        char[] playerInfo = PlayerPrefs.GetString("playerInfo").ToCharArray();
        for(int i = 0; i < playerInfo.Length / 10; i++)
        {
            string currentPlayer = "";
            for (int j = 0; j < 10; j++)
            {
                if(playerInfo[i * 10 + j].ToString() != "@")
                {
                    currentPlayer += playerInfo[i];
                }
            }
            if(currentPlayer.Length > 0)
            {
                scores.Add(new HighScores(currentPlayer, PlayerPrefs.GetInt(currentPlayer, 0)));
            }
        }
        PlayerPrefs.Save();
    }
}
