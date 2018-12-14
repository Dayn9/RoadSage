using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Annotationn : MonoBehaviour {

    private Image image;
    private Text text;

    private Text myText;

    private void Awake()
    {
        image = GetComponentInParent<Image>();
        text = GetComponentInParent<Text>();
        if(text.GetComponent<Annotationn>() != null)
        {
            text = null;
        }
        myText = GetComponent<Text>();
    }

    private void Update()
    {
        Color parentA = myText.color;
        if(image != null)
        {
            parentA.a = image.color.a;
        }
        
        if (text != null)
        {
            parentA.a = text.color.a;
        }
        myText.color = parentA;
    }
}
