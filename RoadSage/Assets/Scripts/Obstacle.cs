using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {

    [SerializeField] private Car car;
    [SerializeField] private Hills hillManager;
    [SerializeField] private UIElement gameOver;
    [SerializeField] private UIElement gameOverScore;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            car.TogglePause();
            hillManager.TogglePause();
            gameOver.FadeIn();
            gameOver.MoveCenter();
            gameOverScore.FadeIn();
            gameOverScore.MoveCenter();
            gameOverScore.GetComponent<Text>().text = "Score: " + (int)car.score;
        }
    }
}
