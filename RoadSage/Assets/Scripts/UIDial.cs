using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDial : MonoBehaviour, IDragHandler
{

    [SerializeField] private RectTransform knob;
    [SerializeField] private float distanceScale;

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
        float angle = (Vector2.SignedAngle(Vector2.down, direction) + 180) * Mathf.PI / 180;
        knob.position = GetComponent<RectTransform>().position + new Vector3(-Mathf.Sin(angle) * distanceScale, Mathf.Cos(angle) * distanceScale, 0);
    }

    public void OnDrag(PointerEventData p)
    {
        Vector2 direction = Input.mousePosition - GetComponent<RectTransform>().position;
        GetComponent<Image>().fillAmount = (Vector2.SignedAngle(Vector2.down, direction) + 180) / 360f;
        float angle = (Vector2.SignedAngle(Vector2.down, direction) + 180) * Mathf.PI / 180;
        knob.position = GetComponent<RectTransform>().position + new Vector3(-Mathf.Sin(angle) * distanceScale, Mathf.Cos(angle) * distanceScale, 0);
    }
}
