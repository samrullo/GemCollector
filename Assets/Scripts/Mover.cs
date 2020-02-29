using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    // speed
    public float Speed = 10f;

    // transform component
    private Transform ThisTransform = null;

    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ThisTransform.position += ThisTransform.forward * Speed * Time.deltaTime;
	}
}
