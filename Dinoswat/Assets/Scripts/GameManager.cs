using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int killCount = 0;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI highScoreText; // drag a UI text for high score here
    public GameObject gameOverPanel;
    public float scrollSpeed = 5f;

    private int highScore;

    public float speedIncreaseRate = 0.1f; // how much speed increases per second
    public float maxScrollSpeed = 15f;     // cap so it doesn't go insane

    void Update()
    {
        if (scrollSpeed < maxScrollSpeed)
        {
            scrollSpeed += speedIncreaseRate * Time.deltaTime;
        }
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // displays prev highscore, 0 if none
        UpdateHighScoreUI();
    }

    public void AddKill()   //counts kills
    {
        killCount++;
        UpdateUI();
    }

    void UpdateUI() //displays kill count
    {
        killCountText.text = " " + killCount;
    }

    void UpdateHighScoreUI()    //displays highscore
    {
        highScoreText.text = " " + highScore;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);  //displays reload sign

        if (killCount > highScore)  //checks if current score beats high score
        {
            highScore = killCount;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void RestartGame()   //restarts game
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}