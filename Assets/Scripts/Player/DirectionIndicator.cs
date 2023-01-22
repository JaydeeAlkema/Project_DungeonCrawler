using Project_Dungeon;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionIndicator : MonoBehaviour
{
	[SerializeField] private Transform followTransform;

	private Controls controls;

	#region Unity Callbacks
	private void Awake()
	{
		controls = new Controls();
	}
	private void OnEnable()
	{
		controls.CharacterControls.RightStickRotation.performed += ReadStick;
		controls.CharacterControls.RightStickRotation.Enable();
	}
	private void OnDisable()
	{
		controls.CharacterControls.RightStickRotation.Disable();
	}
	private void Update()
	{
		if (followTransform == null) return;
		transform.position = followTransform.position;
	}
	#endregion
	public void ReadStick(InputAction.CallbackContext context)
	{
		Vector2 stickDirection = context.ReadValue<Vector2>().normalized;

		if (stickDirection == Vector2.zero) return;

		RotateAim(stickDirection);
	}
	public void RotateAim(Vector2 direction)
	{
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
