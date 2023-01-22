using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;

	[BoxGroup("References"), SerializeField] private Crosshair crosshair;
	[BoxGroup("References"), SerializeField] private DirectionIndicator directionIndicator;
	[Space(10)]

	private PlayerInput playerInput;

	#region Unity Callbacks
	private void Awake()
	{
		if (instance == null || instance != this)
		{
			Destroy(instance);
			instance = this;
		}
		Cursor.visible = false;

		playerInput = GetComponent<PlayerInput>();
		playerInput.onControlsChanged += OnControlschemeChange;
		OnControlschemeChange(playerInput);
	}
	#endregion

	#region Input System
	private void OnControlschemeChange(PlayerInput context)
	{
		switch (context.currentControlScheme)
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
