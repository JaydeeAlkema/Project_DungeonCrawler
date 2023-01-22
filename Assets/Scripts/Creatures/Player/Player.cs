using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Creature
{
	private Controls controls;
	private DirectionIndicator directionIndicator;

	#region Unity Callbacks
	private void Awake()
	{
		controls = new Controls();
	}
	private void Start()
	{
		directionIndicator = GameManager.Instance.DirectionIndicator;
	}
	private void OnEnable()
	{
		controls.CharacterControls.Move.performed += Move;
		controls.CharacterControls.Move.Enable();

		controls.CharacterControls.Attack.performed += Attack;
		controls.CharacterControls.Attack.Enable();
	}
	private void OnDisable()
	{
		controls.CharacterControls.Move.Disable();
		controls.CharacterControls.Attack.Disable();
	}
	#endregion

	private void Move(InputAction.CallbackContext context)
	{
		rb2d.velocity = context.ReadValue<Vector2>() * moveSpeed;
	}

	private void Attack(InputAction.CallbackContext context)
	{
		Instantiate(attacks[currentAttackIndex], transform.position, directionIndicator.transform.rotation, transform);
	}
}
