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

    void Update() {
        UpdateScoreText();
    }

    void ResetScore() {
        score = 0;
        numBreakableBlocks = 0;
        scoreText.text = score.ToString();
    }

    void UpdateScoreText() {
        string scoreString = score.ToString() + "/" + numBreakableBlocks.ToString();
        scoreText.text = scoreString;
    }

    void CheckIfLevelWon() {
        if (score == numBreakableBlocks) {
            ResetScore();
            sceneLoader.LoadNextScene();
        }
    }


    public void AddBreakableBlock() {
        numBreakableBlocks++;
    }

    /**
     * Blocks will call this on collision
     */
    public void IncrementScore() {
        score++;
        CheckIfLevelWon();
    }
}
