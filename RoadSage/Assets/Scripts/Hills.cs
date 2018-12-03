using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hills : MonoBehaviour {

    [SerializeField] private float width;
    [SerializeField] private float speed;

    private bool created = false;


	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(!created && transform.position.x < 0)
        {
            Instantiate(this.gameObject, transform.position + Vector3.right * (width / 2), Quaternion.identity);
            created = true;
        }
        else if(transform.position.x < -(width / 2))
        {
            Destroy(gameObject);
        }
	}
}
