using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        if(transform.GetChild(2).GetComponent<InputField>().text != "" && transform.GetChild(2).GetComponent<InputField>().text.Length < 11 && !transform.GetChild(2).GetComponent<InputField>().text.Contains("@"))
        {
            PlayerPrefs.SetString("currentPlayer", transform.GetChild(2).GetComponent<InputField>().text);
            SceneManager.LoadScene("GamePlayScene");
        } 
        else
        {
            Debug.Log("invalid name");
        }
    }
}
