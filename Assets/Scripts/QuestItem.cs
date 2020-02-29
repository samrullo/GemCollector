using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public string QuestName = string.Empty;

    private SpriteRenderer ThisRenderer = null;
    private Collider2D ThisCollider = null;
    private AudioSource ThisAudio = null;


    void Awake()
    {
        ThisRenderer = GetComponent<SpriteRenderer>();
        ThisAudio = GetComponent<AudioSource>();
        ThisCollider = GetComponent<Collider2D>();
    }
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);

        if (QuestManager.GetQuestStatus(QuestName) == Quest.QUESTSTATUS.ASSIGNED)
        {
            gameObject.SetActive(true);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (!gameObject.activeSelf) return;

        QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.COMPLETE);

        ThisRenderer.enabled = ThisCollider.enabled = false;
        if (ThisAudio != null)
        {
            ThisAudio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
