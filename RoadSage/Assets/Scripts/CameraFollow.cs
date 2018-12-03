using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform follow;
    [SerializeField] private Vector3 offset;

	// Update is called once per frame
	void Update () {
        Vector3 pos = follow.position + offset;
        pos.z = -10;
        transform.position = pos;
	}
}
