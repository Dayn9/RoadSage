using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {

    [SerializeField] private Car car;
    [SerializeField] private Hills hillManager;
    [SerializeField] private UIElement gameOver;
    [SerializeField] private UIElement gameOverScore;
    [SerializeField] private UIElement tapToStart;

    private static int highscore = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameOver.FadeIn();
            gameOver.MoveCenter();
            gameOverScore.FadeIn();
            gameOverScore.MoveCenter();
            if(car.score != 0)
            {
                if ((int)car.score > highscore) { highscore = (int)car.score; }
                gameOverScore.GetComponent<Text>().text = "Score: " + (int)car.score + "\n Highscore: " + highscore;
                tapToStart.Activate();
                tapToStart.FadeIn();

                car.Restart();
                List<Hills> hills = new List<Hills>();

                hills.AddRange(FindObjectsOfType<Hills>());
                foreach (Hills hill in hills)
                {
                    hill.Restart();
                }
            }
            
        }
    }
}
