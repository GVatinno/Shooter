using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

	private Animator mAnim;
	private Rigidbody mRigidBody;
	private string[] mIdleAnims;
	private const int mIdleAnimCount = 4;
	private string[] mDamagedAnims;
	private const int mDamagedAnimCount = 2;

	// Usawakee this for initialization
	void Awake () {
		mAnim = GetComponent<Animator> ();
		mRigidBody = GetComponent<Rigidbody> ();
		mIdleAnims = new string[mIdleAnimCount];
		mIdleAnims[0] = "WAIT01";
		mIdleAnims[1] = "WAIT02";
		mIdleAnims[2] = "WAIT03";
		mIdleAnims[3] = "WAIT04";
		mDamagedAnims = new string[mDamagedAnimCount];
		mDamagedAnims[0] = "DAMAGED00";
		mDamagedAnims[1] = "DAMAGED01";
	}

	public void PlayIdle()
	{
		int index = Random.Range (0, mIdleAnimCount);
		if (mAnim != null)
			mAnim.Play (mIdleAnims[index], -1, 0.0f);
	}

	public void PlayDamaged()
	{
		int index = Random.Range (0, mDamagedAnimCount);
		if (mAnim != null)
			mAnim.Play (mDamagedAnims[index], -1, 0.0f);
	}

	public void MoveAnimationInDirectionFBLR(Vector2 direction)
	{
		mAnim.SetFloat ("MoveX", direction.x);
		mAnim.SetFloat ("MoveY", direction.y);
	}

	public void ApplyVelocity(Vector3 velocity)
	{
		mRigidBody.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
