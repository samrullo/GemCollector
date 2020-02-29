using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    //damage inflicted on player
    public float Damage = 100f;

    // lifetime for ammo
    public float LifeTime = 1f;

	// Use this for initialization
	void Start () {
        Invoke("Die", LifeTime);
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        // if not player then exit
        if (!other.CompareTag("Player")) return;

        // else inflict damage
        PlayerController.Health -= Damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
