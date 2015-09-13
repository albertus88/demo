using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float velocity = 2.0f;


	Animator _animator;
	Walk w = null;
	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponentInChildren<Animator> ();
		w = _animator.GetBehaviour<Walk> ();

		w.Init (velocity, transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
