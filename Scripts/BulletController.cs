using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    //public GameManager myGameManager;

    // Start se llama antes del primer frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        //myGameManager = FindObjectOfType<GameManager>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(bulletSpeed, myrigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ItemBad"))
        {
            PlayerController.ScoreManager.score++;
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.UpdateScoreDisplay();
            }
            Destroy(collision.gameObject);
        }
    }
}