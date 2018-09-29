using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float startingSpeed = 40f;
    float startingXDirection;

    bool isBallLaunched = false;
    Vector2 paddleToBallVector;

    // Use this for initialization
    void Start () {
        // get offset from paddle to ball so we can lock the ball on top of the paddle before launch
        paddleToBallVector = transform.position - paddle.transform.position;

        // create random starting x direction
        startingXDirection = Random.Range(-10f, 10f);
    }
	
	// Update is called once per frame
	void Update () {

        // Lock the ball to the paddle to start
        if (!isBallLaunched) {
            LockBallToPaddle();
        }


	}

    void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        if (Input.GetMouseButtonDown(0)) {
            LaunchBall();
        }
    }

    void LaunchBall() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 startingForce = new Vector2(startingXDirection, startingSpeed);
        rb.velocity = startingForce;
        isBallLaunched = true;
    }
}
