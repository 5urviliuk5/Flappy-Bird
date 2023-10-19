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
    public GameObject endScreen;
    public TMP_Text BirdScoreText;
    public int birdScore = 0;
    public float speed;
    public GameObject yellow, red, blue;
    float rng;
    public GameObject flashEffect;

    public AudioSource death;
    public AudioSource flap;
    public AudioSource score;

    void Start()
    {
        rng = UnityEngine.Random.value;
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;

        if (rng <= 0.3) { yellow.SetActive(true); }

        else if (rng >= 0.3 && rng < 0.6) { red.SetActive(true); }

        else { blue.SetActive(true); }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            rb.velocity = Vector2.up * jumpSpeed;
            flap.Play();
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
        score.Play();
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;

        Invoke("ShowMenu", 1f);
        PlayerPrefs.SetInt("Score", birdScore);
        flashEffect.SetActive(true);

        death.Play();
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);
        BirdScoreText.gameObject.SetActive(false);
    }
}
