using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Car : MonoBehaviour {

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityForce;
    [SerializeField] private Text scoreOutput;
    [SerializeField] private float scoreMultiplier;

    private Rigidbody2D rb2D;

    private RaycastHit2D[] hits;
    private bool grounded;
    private bool jump = false;

    private float velocity = 0;

    private bool pause = true;

    private Vector3 targetUp;

    public float score = 0; 

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        hits = new RaycastHit2D[2];
        targetUp = transform.up;
    }

    private void Update()
    {
        if (!pause)
        {
            if (grounded && Input.GetMouseButton(0))
            {
                jump = true;
            }

            score += scoreMultiplier * Time.deltaTime;
            scoreOutput.text = ((int)score).ToString();
        }
       
    }

    public void Begin()
    {
        pause = false;
    }

    public void Restart()
    {
        transform.position = new Vector3(-3.16f, 0, 0);
        pause = true;
        score = 0;
        transform.right = Vector2.right;
    }


    public void TogglePause()
    {
        pause = !pause;
    }

    public void GameOver()
    {
        pause = true;
    }


    // Update is called once per frame
    void FixedUpdate () {

        if (!pause)
        {
            velocity -= gravityForce * Time.deltaTime;

            int numCollisions = rb2D.Cast(Vector3.down, hits, velocity);
            float distance = Mathf.Abs(velocity);
            for (int i = 0; i < numCollisions; i++)
            {
                //collide with the closest
                if (hits[i].distance < distance)
                {
                    distance = hits[i].distance;
                    grounded = true;
                    velocity = 0;
                    targetUp = hits[i].normal;
                }
            }

            if (jump && grounded)
            {
                velocity += jumpForce * Time.deltaTime;
                score += 10;
                jump = false;
                grounded = false;
            }

            transform.position += Vector3.up * velocity;
            transform.up = Vector3.Slerp(transform.up, targetUp, Time.deltaTime * 10);
        }
	}

}
