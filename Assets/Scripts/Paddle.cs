using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float paddleMinX = 1f;
    [SerializeField] float paddleMaxX = 15f;
    [SerializeField] AudioClip ballBounceSound;
    [SerializeField] float screenWidthUnits = 16f;

    float startingYPos;
    bool isAutoPlayEnabled = false;

    // Use this for initialization
    void Start() {
        startingYPos = transform.position.y;
        isAutoPlayEnabled = FindObjectOfType<GameStatus>().IsAutoPlayEnabled();
    }

    // Update is called once per frame
    void Update() {

        movePaddle();

    }

    void movePaddle() {
        
        Vector2 paddlePos = new Vector2(GetXPos(), startingYPos);

        // set the position
        transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(ballBounceSound, Camera.main.transform.position);
    }

    private float GetXPos() {
        if (isAutoPlayEnabled) {
            return FindObjectOfType<Ball>().transform.position.x + Random.Range(-0.4f, 0.4f);
        }
        else {
            // translate mouse x pos to world units
            float mousePosInUnits = (Input.mousePosition.x / Screen.width * screenWidthUnits);

            // force the movement within the bounds of the playable area
            float clampedX = Mathf.Clamp(mousePosInUnits, paddleMinX, paddleMaxX);

            return clampedX;
        }
    }
}
