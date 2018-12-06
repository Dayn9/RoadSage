using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIColor : MonoBehaviour {

    [SerializeField] private Sprite[] sprites;
    private Image image;
    private SpriteRenderer render;

	// Use this for initialization
	void Awake() {
        image = GetComponent<Image>();
        render = FindObjectOfType<Car>().gameObject.GetComponent<SpriteRenderer>();
	}
	
    public void ColorChange(int color)
    {
        image.sprite = sprites[color];
        render.sprite = sprites[color];
    }
}
