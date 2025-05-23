using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text highscoreText;
    public TMP_Text scoreText;
    private int score = 0;
    private int highScore = 0;
    public static GameManager Instance;
    public bool isGameOver = false;
    public GameObject gameOverUI;
    public GameObject gameStartUI;

    void Awake()
    {
        Time.timeScale = 0f;
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "HighScore:\n" + highScore;
    }

    public void AddPoint()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        scoreText.text = "Score:\n" + score;
        highscoreText.text = "HighScore:\n" + highScore;
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void PlayGame()
    {
        if (gameStartUI.activeSelf == true)
        {
            gameStartUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    
    // DEV ONLY OPTION TO RESET THE HIGHSCORE (RIGHTCLICK THE SCRIPT IN IT'S GAMEOBJECT)
    [ContextMenu("Reset High Score")]
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}