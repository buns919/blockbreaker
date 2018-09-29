using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float paddleMinX = 1f;
    [SerializeField] float paddleMaxX = 15f;

    [SerializeField] float screenWidthUnits = 16f;
    float startingYPos;

    // Use this for initialization
    void Start () {
        startingYPos = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        movePaddle();

    }

    void movePaddle() {
        float mousePosInUnits = (Input.mousePosition.x / Screen.width * screenWidthUnits);

        float clampedX = Mathf.Clamp(mousePosInUnits, paddleMinX, paddleMaxX);
        Vector2 paddlePos = new Vector2(clampedX, startingYPos);


        transform.position = paddlePos;
    }
}
