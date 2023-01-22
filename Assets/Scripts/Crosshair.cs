using Project_Dungeon;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
	private Controls controls;

	#region Unity Callbacks
	private void Awake()
	{
		controls = new Controls();
	}
	private void OnEnable()
	{
		controls.CharacterControls.MousePosition.performed += ReadMouseInput;
		controls.CharacterControls.MousePosition.Enable();
	}
	private void OnDisable()
	{
		controls.CharacterControls.MousePosition.Disable();
	}
	#endregion
	public void ReadMouseInput(InputAction.CallbackContext context)
	{
		Vector2 mousePosition = context.ReadValue<Vector2>();
		Vector2 objectPosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = objectPosition;
	}
}
