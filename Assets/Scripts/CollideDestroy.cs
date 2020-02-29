using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDestroy : MonoBehaviour {

    // when hit objects with associated tag then destroy
    public string TagCompare = string.Empty;

    void OnTriggerEnter2D(Collider2D other)
    {   
        // if the object with which it collided doesn't match the specified tag then exit
        if (!other.CompareTag(TagCompare)) return;

        // else self destroy
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
