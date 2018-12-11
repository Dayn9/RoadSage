using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StartPos
{
    center, right, left, top, bottom
}

public class UIElement : MonoBehaviour {

    [SerializeField] private float speed = 5;
    [SerializeField] private bool screenSizeOffset;
    [SerializeField] private Vector2 offset;
    [SerializeField] private StartPos startPos;
    [SerializeField] private Color startColor = Color.white;

    private Image image;
    private Text text; 

    private Vector2 target;
    private Color color;

    private Vector2 center;

    private void Awake()
    {
        center = transform.localPosition;
        image = GetComponent<Image>();
        text = GetComponent<Text>();
        if(image != null)
        {
            image.color = startColor;
            color = image.color;
        }
        else if (text != null)
        {
            text.color = startColor;
            color = text.color;
        }

        switch (startPos)
        {
            case StartPos.right:
                transform.localPosition += (screenSizeOffset ? Screen.width : offset.x) * Vector3.right;
                break;
            case StartPos.left:
                transform.localPosition += (screenSizeOffset ? Screen.width : offset.x) * Vector3.left;
                break;
            case StartPos.top:
                transform.localPosition += (screenSizeOffset ? Screen.height: offset.y) * Vector3.up;
                break;
            case StartPos.bottom:
                transform.localPosition += (screenSizeOffset ? Screen.height : offset.y) * Vector3.down;
                break;
            case StartPos.center:
            default:
                break;
        }
        target = transform.localPosition;
    }

    #region button calls
    public void Deactivate()
    {
        GetComponent<Button>().targetGraphic.raycastTarget = false;
    }
    public void Activate()
    {
        GetComponent<Button>().targetGraphic.raycastTarget = false;
    }

    public void MoveRight()
    {
        MoveTo(new Vector2(center.x + (screenSizeOffset ? Screen.width : offset.x), center.y));
    }
    public void MoveLeft()
    {
        MoveTo(new Vector2(center.x- (screenSizeOffset ? Screen.width : offset.x), center.y));
    }
    public void MoveBottom()
    {
        MoveTo(new Vector2(center.x, center.y - (screenSizeOffset ? Screen.height : offset.y)));
    }
    public void MoveTop()
    {
        MoveTo(new Vector2(center.x, center.y + (screenSizeOffset ? Screen.height : offset.y)));
    }
    public void MoveCenter()
    {
        MoveTo(center);
    }

    public void FadeIn()
    {
        Color newColor = color;
        newColor.a = 1;
        ColorChange(newColor);
    }

    public void FadeOut()
    {
        Color newColor = color;
        newColor.a = 0;
        ColorChange(newColor);
    }
    #endregion

    public void ColorChange(Color color)
    {
        this.color = color;
    }

    public void MoveTo(Vector2 target)
    {
        this.target = target; 
    }

    private void Update()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, target, Time.deltaTime * speed);
        if (image != null)
        {
            image.color = Color.Lerp(image.color, color, Time.deltaTime * speed);
        }
        else if (text != null)
        {
            text.color = Color.Lerp(text.color, color, Time.deltaTime * speed);
        }
    }

}
