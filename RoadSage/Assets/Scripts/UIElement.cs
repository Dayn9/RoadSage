using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StartPos
{
    center, right, left, top, bottom
}

public class UIElement : MonoBehaviour {

    private const float speed = 5;

    private Image image;

    private Vector2 target;
    private Color color;

    private Vector2 center;

    [SerializeField] private StartPos startPos;

    private void Awake()
    {
        
        center = transform.localPosition;
        image = GetComponent<Image>();
        color = image.color;

        switch (startPos)
        {
            case StartPos.right:
                transform.localPosition += Screen.width * Vector3.right;
                break;
            case StartPos.left:
                transform.localPosition += Screen.width * Vector3.left;
                break;
            case StartPos.top:
                transform.localPosition += Screen.height * Vector3.up;
                break;
            case StartPos.bottom:
                transform.localPosition += Screen.height * Vector3.down;
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
        image.enabled = false;
    }

    public void MoveRight()
    {
        MoveTo(new Vector2(center.x + Screen.width, center.y));
    }
    public void MoveLeft()
    {
        MoveTo(new Vector2(center.x-Screen.width, center.y));
    }
    public void MoveBottom()
    {
        MoveTo(new Vector2(center.x, center.y - Screen.width));
    }
    public void MoveTop()
    {
        MoveTo(new Vector2(center.x, center.y + Screen.width));
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
        image.color = Color.Lerp(image.color, color, Time.deltaTime * speed);
    }

}
