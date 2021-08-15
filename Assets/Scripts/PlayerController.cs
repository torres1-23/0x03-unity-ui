using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>Handles player controller class</summary>
public class PlayerController : MonoBehaviour
{
    // Player ball variables
    public float speed = 500;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Image winLoseBG;
    public Text winLoseText;

    Rigidbody body;

    // Start is called before the first frame update
    /// <summary>Gets rigidbody component from player ball</summary>
    void Start()
    {
        body = GetComponent<Rigidbody>();
        winLoseBG.enabled = false;
    }

    /// <summary>Updates velocity of player rigidbody</summary>
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        body.velocity = movement * speed * Time.deltaTime;
    }

    /// <summary>Updates variables value when player collides with objects in maze</summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            // Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            // Debug.Log($"health: {health}");
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            // Debug.Log($"You win\nScore: {score}");
            winLoseText.text = "You win!";
            winLoseText.color = Color.black;
            winLoseBG.enabled = true;
            winLoseBG.color = Color.green;
            // reload();
        }
    }

    /// <summary>If player runs out of heal, reload the scene</summary>
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            reload();
        }
    }

    /// <summary>Reloads the scene</summary>
    void reload()
    {
        SceneManager.LoadScene("maze");
        score = 0;
        health = 5;
        Debug.Log("Game Reloaded!");
    }

    /// <summary>Updates ScoreText object with current player score</summary>
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    /// <summary>Updates HealthText object with current player health</summary>
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
}
