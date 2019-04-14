using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    [Header("UI")]
    public Text scoreText;

    public static GameManager Instance = null;
    public delegate void SpawnCallback();
    public SpawnCallback onSpawn;

    public delegate void ScoreCallback(int score);
    public ScoreCallback onScoreAdded;

    // Keep record of the score
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Access this function to spawn whatever subscribed to spawn callback
    public void Spawn()
    {
        // If there are subscribed functions
        if (onSpawn != null)
        {
            // Invoke them
            onSpawn.Invoke();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();

        // Are functions subscribed to onScoreAdded?
        if (onScoreAdded != null)
        {
            // Invoke all subscribed
            onScoreAdded.Invoke(score);
        }
    }

    public void ResetGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
