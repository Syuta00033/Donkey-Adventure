using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script realizes a infinate background scrolling.
// When the sprite goes beyond the camera left edge, it creates a clone to the right of the sprite.
public class ParallaxLooping : MonoBehaviour
{
    // Step 1: Define member variables
    // Reference to the component sprite renderer attached to the game object
    private SpriteRenderer spriteRenderer;
    // It is true if a clone to the right of the sprite is already created
    private bool recycled = false;

    // Start is called before the first frame update
    void Start()
    {
        // Step 2: Get Reference to the attached sprite render
        // Note: If you want to realize the scrolling for more than one sprite
        // you should watch the child which is at the left
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Step 3: Calculate half size in the x-direction of the sprite (right edge of the sprite)
        float halfSize = spriteRenderer.bounds.size.x / 2f;
        float rightBoundSprite = spriteRenderer.bounds.center.x + halfSize;

        // Step 4: Calculate the boundaries of the camera in x-direction
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float halfWidth = height * cam.aspect / 2f;
        float rightBoundCam = cam.transform.position.x + halfWidth;

        // Step 5: Check if the right edge of the sprite is alredy inside the camera boundaries
        if (rightBoundCam >= rightBoundSprite)
        {
            // Step 6: Check if it is alredy recycled. Otherwise each frame a new clone is created
            if (!recycled)
            {
                //Step 7: Instantiate a clone of the sprite and set its new position (right to the to the exting one)
                // Note: Instantiate can be used to create new objects at runtime.
                SpriteRenderer sr = Instantiate(spriteRenderer);
                sr.transform.position = new Vector3(rightBoundSprite + halfSize - 0.01f, sr.transform.position.y, sr.transform.position.z);
                recycled = true;
            }
        }
        // Step 8: Check if the right edge of the sprite is alredy outside the camera boundaries, and delete the object
        float leftBoundCam = cam.transform.position.x - halfWidth;
        if (leftBoundCam > rightBoundSprite)
        {
            Destroy(gameObject);
        }
    }
}
