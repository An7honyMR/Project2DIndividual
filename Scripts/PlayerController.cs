using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 5f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;
    //public int score = 0;
    public Text scoreText;
    public int jumpCount = 0;
    public int maxJumpCount = 2;
    public AudioSource musicSource;
    public GameObject Bullets;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }*/

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
            jumpCount++;
        }

        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 bulletSpawnPosition = transform.position + transform.right * 1.0f;
            Instantiate(Bullets, bulletSpawnPosition, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }

    public static class ScoreManager
    {
        public static int score = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Safe"))
        {
            jumpCount = 0;
        }
        if (collision.collider.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            ScoreManager.score++;
            //score++;
            UpdateScoreDisplay();
            //myGameManager.AddScore();
        }
        if (collision.collider.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.collider.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }*/

    void PlayerDeath()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void UpdateScoreDisplay()
    {
        scoreText.text = "Puntuación: " + ScoreManager.score.ToString();
    }
}
