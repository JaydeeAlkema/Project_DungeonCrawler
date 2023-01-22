using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;

	[BoxGroup("References"), SerializeField] private Crosshair crosshair;
	[BoxGroup("References"), SerializeField] private DirectionIndicator directionIndicator;
	[Space(10)]
	[BoxGroup("Inputs"), SerializeField] private PlayerInput playerInput;
	[BoxGroup("Inputs"), ReadOnly] private Controls controls;


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

		playerInput.onControlsChanged += OnControlschemeChange;
		OnControlschemeChange(playerInput);
	}
	#endregion

	#region Input System
	private void OnControlschemeChange(PlayerInput obj)
	{
		switch (obj.currentControlScheme)
		{
			case "Keyboard & Mouse":
				crosshair.gameObject.SetActive(true);
				directionIndicator.gameObject.SetActive(false);
				break;
			case "Gamepad":
				crosshair.gameObject.SetActive(false);
				directionIndicator.gameObject.SetActive(true);
				break;
			default:
				break;
		}
	}
	#endregion
}
