using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roadblock : MonoBehaviour {
    
    public Text scoreText;
    public int scoreIncrease = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Set the player's position back to defined position
            collision.gameObject.transform.position = new Vector3(0f, 1, 6f);

            // Let's update enemy score everytime they block the player
            int score = int.Parse(scoreText.text);  // Get current score from UI
            score += scoreIncrease;                 // increment score
            scoreText.text = score.ToString();      // Update new score onto the UI
        }
    }
}
