using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {

	public float minionSpeed = 50.0f;

	private Minion mMinion;


	// Use this for initialization
	void Start () {
		mMinion = GetComponent<Minion> ();
		if ( mMinion != null )
			mMinion.PlayIdle ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1"))
			mMinion.PlayIdle ();
		if (Input.GetKeyDown ("2"))
			mMinion.PlayDamaged ();
		
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		float veclocityX = x * Time.deltaTime * minionSpeed;
		float veclocityZ = y * Time.deltaTime * minionSpeed;

		mMinion.MoveAnimationInDirectionFBLR (new Vector2 (x, y));
		mMinion.ApplyVelocity(new Vector3(-veclocityX, 0.0f, veclocityZ));
	}
}
