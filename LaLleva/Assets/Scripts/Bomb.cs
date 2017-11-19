using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    Transform mTransform;

    Transform reference;

    float t = 0f;

	void Start ()
    {
        mTransform = GetComponent<Transform>();

        reference = GameObject.Find("Reference").GetComponent<Transform>();

        Movement.OnPassBomb += PassedBomb;
	}
	
	void Update ()
    {
        mTransform.position = reference.position;

        Explode();
    }

    public void Explode()
    {
        t += Time.deltaTime;

        if (t > 10f)
        {
            Destroy(gameObject);
        }
        Debug.Log(t);
    }

    public void PassedBomb()
    {
        mTransform.position = reference.position;
    }

}
