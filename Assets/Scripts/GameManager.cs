using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject game;
    public GameObject over;
    public Player player;

    public GameObject walletButton;

    public void GameOver()
    {
        game.SetActive(true);
        over.SetActive(true);
        playButton.SetActive(true);
        walletButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void Awake()
    {

        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        walletButton.SetActive(false);
        game.SetActive(false);
        over.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Logs[] logs = FindObjectsByType<Logs>(FindObjectsSortMode.None);
        for (int i = 0; i < logs.Length; i++)
        {
            Destroy(logs[i].gameObject);
        }
    }

    public void Pause()
    {
        
        Time.timeScale = 0f;
        player.enabled = false;
    }

}
