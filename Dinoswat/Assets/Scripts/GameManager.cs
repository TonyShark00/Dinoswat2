using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int killCount = 0; // counts kills
    public TextMeshProUGUI killCountText; //displays kills
    public GameObject gameOverPanel; // reload button

    void Awake()
    {
        Instance = this;
    }

    public void AddKill()
    {
        killCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        killCountText.text = " " + killCount;
    }

    public void GameOver()
    {
        Debug.Log("GameOver() called!");
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // freezes everything driven by Time.deltaTime
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // unfreeze before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //refreshes scene
    }
}