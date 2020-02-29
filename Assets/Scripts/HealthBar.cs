using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    // RectTransform component
    private RectTransform ThisTransform = null;

    // catch up speed 
    public float MaxSpeed = 10f;

    void Awake()
    {
        ThisTransform = GetComponent<RectTransform>();
    }

	// Use this for initialization
	void Start () {
		if (PlayerController.PlayerInstance != null)
        {
            ThisTransform.sizeDelta = new Vector2(Mathf.Clamp(PlayerController.Health, 0, 100), ThisTransform.sizeDelta.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float HealthUpdate = 0f;

        if (PlayerController.PlayerInstance != null)
            HealthUpdate = Mathf.MoveTowards(ThisTransform.rect.width, PlayerController.Health, MaxSpeed);

        ThisTransform.sizeDelta = new Vector2(Mathf.Clamp(HealthUpdate, 0, 100), ThisTransform.sizeDelta.y);
	}
}
