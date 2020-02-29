using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMotion : MonoBehaviour {

    private Transform ThisTransform = null;

    // original position
    private Vector3 Origin = Vector3.zero;

    // Axes to move on
    public Vector3 MoveAxes = Vector2.zero;

    // speed
    public float Distance = 3f;

    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
        Origin = ThisTransform.position;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ThisTransform.position = Origin + MoveAxes * Mathf.PingPong(Time.time, Distance);
	}
}
