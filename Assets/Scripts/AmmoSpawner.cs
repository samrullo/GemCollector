using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour {

    // reference to ammo prefab
    public GameObject AmmoPrefab = null;

    // reference to Transform
    private Transform ThisTransform = null;

    // Vector for time range
    public Vector2 TimeDelayRange = Vector2.zero;

    // Lifetime for ammo spawned
    public float AmmoLifeTime = 2f;

    // ammo speed
    public float AmmoSpeed = 4f;

    // ammo damage
    public float AmmoDamage = 100f;

    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
        FireAmmo();
	}

    public void FireAmmo()
    {
        GameObject Obj = Instantiate(AmmoPrefab, ThisTransform.position, ThisTransform.rotation) as GameObject;
        Ammo AmmoComp = Obj.GetComponent<Ammo>();
        Mover MoveComp = Obj.GetComponent<Mover>();
        AmmoComp.LifeTime = AmmoLifeTime;
        AmmoComp.Damage = AmmoDamage;
        MoveComp.Speed = AmmoSpeed;

        // wait until next random interval
        Invoke("FireAmmo", Random.Range(TimeDelayRange.x, TimeDelayRange.y));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
