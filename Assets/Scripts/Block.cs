using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    Level level;

    /**
     * increment the breakable blocks number by 1 in "Level" for each block in the level
     */
    void Start() {
        level = FindObjectOfType<Level>();
        level.AddBreakableBlock();
    }

    /**
     * play the audio specified in the editor
     */
    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.IncrementScore();
        Destroy(gameObject);
    }

}
