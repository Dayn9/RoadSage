using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hills : MonoBehaviour {

    [SerializeField] private float width;
    [SerializeField] private float speed;

    private bool created = false;

    private static bool pause = true;
	
    public void TogglePause()
    {
        pause = !pause;
    }
    public void Begin()
    {
        pause = false;
    }

    public void Restart()
    {
        transform.position = new Vector3(11.59f, -10.36f, -2);
        pause = true;
    }

    // Update is called once per frame
    void Update () {
        if (!pause)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (!created && transform.position.x < 0)
            {
                Instantiate(this.gameObject, transform.position + Vector3.right * (width / 2), Quaternion.identity);
                created = true;
            }
            else if (transform.position.x < -(width / 2))
            {
                Destroy(gameObject);
            }
        }
	}
}
