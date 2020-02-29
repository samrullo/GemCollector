using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitHandler : MonoBehaviour {

    public string LevelName = string.Empty;
    public Vector3 playerPosition = Vector3.zero;
    public GameObject playerPrefab = null;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);        
        Debug.Log("Player entered the trigger");
        GameObject playerInstance = (GameObject)Instantiate(playerPrefab);
        Transform playerTransform = playerInstance.GetComponent<Transform>();
        playerTransform.position = playerPosition;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
