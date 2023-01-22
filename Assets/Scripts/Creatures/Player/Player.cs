using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Creature
{
	private Controls controls;

	#region Unity Callbacks
	private void Awake()
	{
		controls = new Controls();
	}
	private void OnEnable()
	{
		controls.CharacterControls.Move.performed += Move;
		controls.CharacterControls.Move.Enable();
	}
	private void OnDisable()
	{
		controls.CharacterControls.Move.Disable();
	}
	#endregion

	private void Move(InputAction.CallbackContext context)
	{
		rb2d.velocity = context.ReadValue<Vector2>() * moveSpeed;
	}
}
