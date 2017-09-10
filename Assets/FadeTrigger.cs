using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour {

    // Color to fade to
    public Color fadeColor;
    // Time it takes in seconds to fade from one color to another
    public float fadeTime = 2.0f;

    // Original assigned color
    private Color originalColor;
    // Current color
    private Color currentColor;
    private Material targetMaterial;

    void Start()
    {
        // Store reference to our material
        targetMaterial = GetComponent<Renderer>().material;
        // Init color values and get the original color from our material
        originalColor = targetMaterial.color;
        currentColor = originalColor;
    }

    void OnTriggerEnter(Collider other)
    {
        // Start fading to fadeColor if we bump into the Player
        if (other.tag == "Player")
        {
            StartCoroutine(FadeTo(fadeColor));
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Start fading to originalColor if the Player is out of our range
        if (other.tag == "Player")
        {
            StartCoroutine(FadeTo(originalColor));
        }
    }

    IEnumerator FadeTo(Color fadeColor)
    {
        float time = 0f;
        // Start fading for fadeTime seconds
        while (time <= fadeTime) {
            // Increment time
            // NOTE: Time.deltaTime is how much time (in seconds) took place between this frame and the last frame
            time += Time.deltaTime;
            // Interpolate between one color to another at x time
            // NOTE: we're dividing time by fadeTime because Color.Lerp expects a t value between 0 and 1
            currentColor = Color.Lerp(currentColor, fadeColor, time / fadeTime);
            // Assign the lerped color to our target material
            targetMaterial.color = currentColor;
            // Ask to engine to come back to this loop on the next frame update
            yield return null;
        }
        // Sometimes our lerp won't give us the exact color values so we're going to set it again to make sure
        currentColor = fadeColor;
        targetMaterial.color = currentColor;
    }
}
