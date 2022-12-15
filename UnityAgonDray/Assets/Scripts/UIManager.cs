using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI dialogueText;
    public GameObject GameOverPanel;
    public GameObject GameOverText;

    private void Start()
    {
        SetDialogueUI("In the dungeon again, they got me good. Gotta get outta here!");
        GameOverPanel.SetActive(false);
        GameOverText.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetHealthUI(string str)
    {
        healthText.text = "Health: " + str;
    }

    public void SetDialogueUI(string str)
    {
        dialogueText.text = str;
    }

    public void GameOver()
    {
        SetDialogueUI("Gah! Not like this....");
        GameOverPanel.SetActive(true);
        GameOverText.SetActive(true);

        Time.timeScale = 0;
    }
}
