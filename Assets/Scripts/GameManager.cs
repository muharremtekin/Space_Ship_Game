using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public Button restartButton;
    public float score = 0f;

    public void textUpdate(string name, float point, TextMeshProUGUI txt)
    {
        score += point;
        txt.text = $"{name}: {score}";
    }
    public void updateScore(float a)
    {
        score += a;
        scoreText.text = $"SCORE:{score}";
    }
    public void UpdatePlayerHealth(float health)
    {
        healthText.text = $"HEALTH:{health}";
    }
    public void GameOver()
    {
        SpawnManager.isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
