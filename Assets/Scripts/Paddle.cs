using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float paddleMinX = 1f;
    [SerializeField] float paddleMaxX = 15f;
    [SerializeField] AudioClip ballBounceSound;

    [SerializeField] float screenWidthUnits = 16f;
    float startingYPos;

    // Use this for initialization
    void Start() {
        startingYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update() {

        movePaddle();

    }

    void movePaddle() {
        // translate mouse x pos to world units
        float mousePosInUnits = (Input.mousePosition.x / Screen.width * screenWidthUnits);

        // force the movement within the bounds of the playable area
        float clampedX = Mathf.Clamp(mousePosInUnits, paddleMinX, paddleMaxX);
        Vector2 paddlePos = new Vector2(clampedX, startingYPos);

        // set the position
        transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(ballBounceSound, Camera.main.transform.position);
    }
}
