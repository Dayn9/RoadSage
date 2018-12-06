using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDial : MonoBehaviour, IDragHandler  {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateDialToCursor()
    {
        Vector2 direction = Input.mousePosition - GetComponent<RectTransform>().position;
        GetComponent<Image>().fillAmount = (Vector2.SignedAngle(Vector2.down, direction) + 180)/360f;
    }

    public void OnDrag(PointerEventData p)
    {
        Vector2 direction = Input.mousePosition - GetComponent<RectTransform>().position;
        GetComponent<Image>().fillAmount = (Vector2.SignedAngle(Vector2.down, direction) + 180) / 360f;
        Debug.Log("waddup");
    }
}
