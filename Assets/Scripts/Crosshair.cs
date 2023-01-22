using UnityEngine;

public class Crosshair : MonoBehaviour
{
	private void Update()
	{
		Vector2 mousePosition = Input.mousePosition;
		Vector2 objectPosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = objectPosition;
	}
}
