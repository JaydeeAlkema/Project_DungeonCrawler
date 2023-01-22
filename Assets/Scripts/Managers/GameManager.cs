using NaughtyAttributes;
using Project_Dungeon;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;

	[BoxGroup("References"), SerializeField] private Crosshair crosshair;
	[BoxGroup("References"), SerializeField] private DirectionIndicator directionIndicator;
	[Space(10)]
	[BoxGroup("Inputs")] private Controls controls;


	#region Unity Callbacks
	private void Awake()
	{
		if (instance == null || instance != this)
		{
			Destroy(instance);
			instance = this;
		}
		Cursor.visible = false;

		controls = new Controls();

		controls.CharacterControls.MousePosition.performed += OnMousePositionInput;
		controls.CharacterControls.MousePosition.Enable();

		controls.CharacterControls.RightStickRotation.performed += OnRightStickInput;
		controls.CharacterControls.RightStickRotation.Enable();
	}
	private void Start()
	{
		crosshair.gameObject.SetActive(false);
		directionIndicator.gameObject.SetActive(false);
	}
	#endregion

	#region Controls Events
	private void OnMousePositionInput(InputAction.CallbackContext obj)
	{
		crosshair.gameObject.SetActive(true);
		directionIndicator.gameObject.SetActive(false);
	}
	private void OnRightStickInput(InputAction.CallbackContext obj)
	{
		crosshair.gameObject.SetActive(false);
		directionIndicator.gameObject.SetActive(true);
	}
	#endregion
}
