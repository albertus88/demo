using UnityEngine;
using System.Collections;

public class Walk : StateMachineBehaviour {

	Animator _animator = null;
	float _velocity = 2f;
	float _rotationAngle = 30f;
	const float kLerp = 0.01f;
	float _currentVelocity = 0f;
	Transform _player;
	VirtualJoystick _vJ = null;

	public void Init(float velocity,Transform player)
	{
		_velocity = velocity;
		_player = player;
		_vJ = GameObject.FindGameObjectWithTag ("Joystick").GetComponent<VirtualJoystick> ();
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	//
		_animator = animator;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//

		if(_vJ.movement.sqrMagnitude > 0f)
		{
			Vector3 position = Vector3.zero;
			position.x = -_vJ.movement.x;
			position.z = _vJ.movement.y;
			_player.transform.forward = position;
			_currentVelocity = Mathf.Lerp(_currentVelocity, _velocity, kLerp);
			_player.transform.position += _currentVelocity * _player.transform.forward * Time.deltaTime;
		}
		else
		{
			_currentVelocity = Mathf.Lerp(_currentVelocity, 0f,0.1f);
			_player.transform.position += _currentVelocity * _player.transform.forward * Time.deltaTime;
			animator.SetFloat("Speed",0);
		}



	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
