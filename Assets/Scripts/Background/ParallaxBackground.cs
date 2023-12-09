using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    [SerializeField] private bool endless = true;
    private float xPosition;
    private float length = 0;

    private void Start() {
        cam = GameObject.Find("Main Camera");
        xPosition = transform.position.x;
        if (endless) length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate() {
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if (!endless) return;

        if (distanceMoved > xPosition + length) {
            xPosition += length;
        } else if (distanceMoved < xPosition - length) {
            xPosition -= length;
        }
    }
}
