using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    Rigidbody2D rb;

    public TMP_Text BirdScoreText;
    public int birdScore = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        birdScore++;
        BirdScoreText.text = birdScore.ToString();
    }

    void Die()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
