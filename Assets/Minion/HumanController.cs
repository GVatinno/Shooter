using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {

	public float minionSpeedV = 50.0f;
    public float minionSpeedH = 20.0f;

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
        bool run = Input.GetKey(KeyCode.LeftShift);

        

        float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

        float veclocityZ = y * Time.deltaTime * minionSpeedV;
        float veclocityX = 0.0f;
        if (veclocityZ > 0.0f)
        {
            veclocityX = x * Time.deltaTime * minionSpeedH;

        }
        else
        {
            veclocityX = 0.0f;
            run = false;
        }
            

        if (run)
        {
            veclocityX *= 5.0f;
            veclocityZ *= 5.0f;
        }

        mMinion.MoveAnimationInDirectionFBLR (new Vector2 (x, y));
		mMinion.ApplyVelocity(new Vector3(veclocityX, 0.0f, veclocityZ));

        mMinion.Run(run);
    }
}
