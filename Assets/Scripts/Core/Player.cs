using MoonlanderCode.Core;
using UnityEngine;

[RequireComponent(typeof(Survivor))]
public class Player : MonoBehaviour
{
	[SerializeField]private Survivor _survivor;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _sprinteSpeed;
	[SerializeField] private float _walkSpeed;

	private bool isSprinting;

	private Vector2 _movementDir;
	private Vector2 _mousePos;
	
	private PlayerInputs _input;

	private void OnEnable() => _input.Enable();
	private void OnDisable() => _input.Disable();

	private void Awake()
	{
		_input = new PlayerInputs();
		_survivor = gameObject.GetComponent<Survivor>();

		_survivor.MoveSpeed = _runSpeed;

		_input.CharacterControls.MousePos.performed += ctx => _mousePos = ctx.ReadValue<Vector2>();
		_input.CharacterControls.Movement.performed += ctx => _movementDir = ctx.ReadValue<Vector2>();
		_input.CharacterControls.Sprint.performed += ctx => Sprint(ctx.ReadValueAsButton());
	}

	private void Start()
	{
		_survivor = gameObject.GetComponent<Survivor>();		
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void Update()
	{
		LookAtMouse();
	}

	private void MovePlayer()
	{
		_survivor.Move(_movementDir);
	}

	private void LookAtMouse()
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(_mousePos);
		_survivor.LookAt(mouseWorldPos);
	}

	private void Sprint(bool isSprinting)
	{
		if (isSprinting == true)
		{
			_survivor.MoveSpeed = _sprinteSpeed;
		}
		else
		{
			_survivor.MoveSpeed = _runSpeed;
		} 
	}
}
