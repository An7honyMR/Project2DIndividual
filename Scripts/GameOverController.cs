using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text scoreText;
    public AudioSource musicGameOver;
    
    void Start()
    {
        scoreText.text = "Puntuación: " + PlayerController.ScoreManager.score.ToString();
        musicGameOver.Play();
    }
}
