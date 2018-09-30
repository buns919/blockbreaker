using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] AudioClip unbreakableBlockSound;
    [SerializeField] GameObject blockParticles;
    [SerializeField] float timeTillDestroyParticles = 1f;
    [SerializeField] Sprite[] hitSprites;

    Level level;

    int maxHits;
    int numHits = 0;


    /**
     * increment the breakable blocks number by 1 in "Level" for each block in the level
     */
    void Start() {
        CountBreakableBlocks();
        maxHits = hitSprites.Length + 1;
    }

    /**
     * Check if a block is tagged as unbreakable, increment the number of blocks in the level
     */
    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag != "Unbreakable") {
            level.AddBreakableBlock();
        }
    }

    /**
     * play the audio specified in the editor and destroy the block
     */
    void OnCollisionEnter2D(Collision2D collision) {
        OnBallCollision();
    }

    void OnBallCollision() {
        // check if it is breakable
        if (tag != "Unbreakable") {
            numHits++;
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            if (numHits >= maxHits) {
                DestroyBlock();
            }
            else {
                // Change the sprite to the next broken block sprite
                ChangeSprite();
            }
        }
        else {
            AudioSource.PlayClipAtPoint(unbreakableBlockSound, Camera.main.transform.position);
        }
    }

    void ChangeSprite() {
        int spriteIndex = numHits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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
