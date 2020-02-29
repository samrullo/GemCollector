using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour {

    public string QuestName;
    public Text NPCTextUI=null;
    public string[] NPCTexts =null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        NPCTextUI.text = NPCTexts[(int)Status];
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag("Player")) return;

        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        if (Status == Quest.QUESTSTATUS.UNASSIGNED)
        {
            QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.ASSIGNED);
        }

        if (Status == Quest.QUESTSTATUS.COMPLETE)
        {
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
