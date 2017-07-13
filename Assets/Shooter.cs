using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public ParticleSystem effect;
    private Animator anim;
    public GameObject impact;

    GameObject[] impacts;
    int currentImpact = 0;
    int maxInpact = 5;
    bool shooting = false;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        Cursor.visible = false;
        impacts = new GameObject[maxInpact];
        for (int i = 0; i < maxInpact; ++i)
        {
            impacts[i] = (GameObject)Instantiate(impact);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire") && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Fire");
            effect.Play();
            shooting = true;
        }

	}

    void FixedUpdate()
    {
        if (shooting == true)
        {
            shooting = false;
            RaycastHit rayHit;
            if (Physics.Raycast(transform.position, transform.forward, out rayHit, 50.0f))
            {
                impacts[currentImpact].transform.position = rayHit.point;
                impacts[currentImpact].GetComponent<ParticleSystem>().Play();

                if (++currentImpact >= maxInpact)
                    currentImpact = 0;
            }
        }
    }
}
