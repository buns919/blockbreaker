using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    [SerializeField] AudioClip unbreakableBlockSound;
    [SerializeField] GameObject blockParticles;
    [SerializeField] float timeTillDestroyParticles = 1f;
    Level level;


    /**
     * increment the breakable blocks number by 1 in "Level" for each block in the level
     */
    void Start() {
        level = FindObjectOfType<Level>();
        if (tag != "Unbreakable") {
            level.AddBreakableBlock();
        }
    }

    /**
     * play the audio specified in the editor and destroy the block
     */
    void OnCollisionEnter2D(Collision2D collision) {
        if (tag != "Unbreakable") {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            DestroyBlock();
        }
        else {
            AudioSource.PlayClipAtPoint(unbreakableBlockSound, Camera.main.transform.position);
        }
    }

    /**
     * Increment score, trigger particles and destroy game object
     */
    void DestroyBlock() {
        level.IncrementScore();
        TriggerBlockParticles();
        Destroy(gameObject);
    }

    void TriggerBlockParticles() {
        GameObject particleEffect = Instantiate(blockParticles, transform.position, transform.rotation);
        Destroy(particleEffect, timeTillDestroyParticles);
    }

}
