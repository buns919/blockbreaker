using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    [SerializeField] int numBreakableBlocks = 0; // serialized for debugging
    [SerializeField] Text scoreText;
    int score = 0;
    SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Update() {
        UpdateScoreText();
    }

    public void AddBreakableBlock() {
        numBreakableBlocks++;
    }

    /**
     * Blocks will call this on collision
     */
    public void IncrementScore() {
        score++;
        CheckIfWon();
    }

    private void ResetGame() {
        score = 0;
        numBreakableBlocks = 0;
        scoreText.text = score.ToString();
    }

    private void UpdateScoreText() {
        string scoreString = score.ToString() + "/" + numBreakableBlocks.ToString();
        scoreText.text = scoreString;
    }

    private void CheckIfWon() {
        if (score == numBreakableBlocks) {
            ResetGame();
            sceneLoader.LoadNextScene();
        }
    }
}
