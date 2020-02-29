using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

    public float DamageRate = 100f;

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        // Damage the player by damagerate
        if (PlayerController.PlayerInstance != null)
        {
            PlayerController.Health -= DamageRate*Time.deltaTime;
            Debug.Log(" Current player health : " + PlayerController.Health.ToString());
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
