using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    [SerializeField] AudioClip bounceSound;

    /**
     * play the audio specified in the editor
     */
    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(bounceSound, Camera.main.transform.position);
    }
}
