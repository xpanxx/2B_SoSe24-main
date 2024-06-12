using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private InputAction _move;
	private InputAction _look;
	private InputAction _interact;

	private float _cameraXRotation;

	public Vector3 _velocity;

	//-----------------------

	public PlayerInput PlayerInput;
	public CharacterController Controller;
	public Transform Camera;
	public Animator Animator;


	public float Speed = 10f;

	public float Gravity = -9.8f; // m/s/s

	public Interactable CurrentInteractable;


	// Start is called before the first frame update
	void Start() {
		_move = PlayerInput.actions.FindAction("Move");
		_look = PlayerInput.actions.FindAction("Look");
		_interact = PlayerInput.actions.FindAction("Interact");
		_cameraXRotation = Camera.rotation.eulerAngles.x;

		//wenn Player dynamisch spawnt
		//DialogScreen dialogScreen = FindFirstObjectByType<DialogScreen>();
		//dialogScreen.DialogOpen.AddListener(DisableInput);
	}

	//wenn Player dynamisch spawnt
	//private void OnDestroy() {
	//	DialogScreen dialogScreen = FindFirstObjectByType<DialogScreen>();
	//	dialogScreen.DialogOpen.RemoveListener(DisableInput);
	//}

	// Update is called once per frame
	void Update() {

		Vector2 moveInput = _move.ReadValue<Vector2>();

		Vector3 moveAmount = transform.forward * moveInput.y + transform.right * moveInput.x;

		_velocity.x = moveAmount.x;
		_velocity.y += Gravity * Time.deltaTime;
		_velocity.z = moveAmount.z;

		if(Controller.Move(_velocity * Speed * Time.deltaTime) == CollisionFlags.Below)
			_velocity.y = 0;


		Animator.SetFloat("speed", _velocity.magnitude);

		//holen ein Vector2 aus dem _look
		Vector2 lookInput = _look.ReadValue<Vector2>();
		Vector3 cameraRotation = Camera.rotation.eulerAngles;
		_cameraXRotation -= lookInput.y;
		_cameraXRotation = Mathf.Clamp(_cameraXRotation, 0, 90);

		cameraRotation.x = _cameraXRotation;

		Camera.eulerAngles = cameraRotation;

		transform.Rotate(0, lookInput.x, 0);

		/*Kamera positions selber berechnen
		//radiant (rad)
		//float angle = _cameraXRotation * Mathf.Deg2Rad;
		//float z = Mathf.Cos(angle);
		//float y = Mathf.Sin(angle);

		//Vector3 cameraPosition = Camera.position;
		//cameraPosition.z = z;
		//cameraPosition.y = y;
		//Camera.position = cameraPosition;
		*/

		/*
		//hold
		_interact.IsPressed();
		//pressed
		_interact.WasPressedThisFrame();
		//released
		_interact.WasReleasedThisFrame();
		*/

		if(_interact.WasPressedThisFrame() && CurrentInteractable != null)
			CurrentInteractable.Interact();
	}

	private void OnTriggerEnter(Collider other) {
		//option 1: tag
		//if(other.CompareTag("coin1")){
		//	Destroy(other.gameObject);
		//}

		//option 2: component
		Collectable collectable = other.GetComponent<Collectable>();
		if(collectable != null)
			collectable.Collect();

		//interactable gedöns
		Interactable inter = other.GetComponent<Interactable>();
		if(inter != null) {
			if(CurrentInteractable != null)
				CurrentInteractable.Unhighlight();

			CurrentInteractable = inter;
			CurrentInteractable.Highlight();
		}
	}

	private void OnTriggerExit(Collider other) {
		Interactable inter = other.GetComponent<Interactable>();
		if(inter != null) {
			inter.Unhighlight();
			CurrentInteractable = null;
		}
	}

	public void DisableInput(bool disabled) {
		PlayerInput.enabled = !disabled; //invert bool
	}


}
