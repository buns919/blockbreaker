using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlocks = 0; // serialized for debugging
    [SerializeField] Text scoreText;
    int score = 0;
    SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
        
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBreakableBlock() {
        breakableBlocks++;
    }

    public void IncrementScore() {
        Debug.Log("Increment score");
        score++;

        string scoreString = score.ToString() + "/" + breakableBlocks.ToString();
        Debug.Log("Score string: " + scoreString);

        scoreText.text = scoreString;
        if (score == breakableBlocks) {
            ResetGame();
            sceneLoader.LoadNextScene();
        }
    }

    private void ResetGame() {
        score = 0;
        breakableBlocks = 0;
        scoreText.text = score.ToString();
    }
}
