using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project_Dungeon
{
	public class PlayerController : MonoBehaviour
	{
		[BoxGroup("Movement"), SerializeField] private float movementSpeed;

		private Rigidbody2D rb2d;
		private Controls controls;

		#region Unity Callbacks
		private void Awake()
		{
			rb2d = GetComponent<Rigidbody2D>();
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
			rb2d.velocity = context.ReadValue<Vector2>() * movementSpeed;
		}
	}
}