using UnityEngine;
using System.Collections;

public class ChangeColorOnTrigger : MonoBehaviour
{
	private SpriteRenderer sprite;
	private Color defaultColor;

	void Start()
	{
		sprite = transform.GetComponent<SpriteRenderer>();
		defaultColor = sprite.color;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("sensor"))
			sprite.color = Color.red;
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag("sensor"))
			sprite.color = defaultColor;
	}
}
