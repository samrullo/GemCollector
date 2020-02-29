using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    // Quest completed status
    public enum QUESTSTATUS { UNASSIGNED=0, ASSIGNED=1, COMPLETE=2};
    public QUESTSTATUS Status = QUESTSTATUS.UNASSIGNED;
    public string QuestName = string.Empty;
}

public class QuestManager : MonoBehaviour {

    // All quests in game
    public Quest[] Quests;

    private static QuestManager SingletonInstance = null;

    public static QuestManager ThisInstance
    {
        get
        {
            if (SingletonInstance == null)
            {
                GameObject QuestObject = new GameObject("Default");
                SingletonInstance = QuestObject.AddComponent<QuestManager>();
            }
            return SingletonInstance;
        }
    }

    void Awake()
    {
        // if there is an existing instance then destroy
        if (SingletonInstance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        // this is only instance
        SingletonInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static Quest.QUESTSTATUS GetQuestStatus(string QuestName)
    {
        foreach(Quest q in ThisInstance.Quests)
        {
            if (q.QuestName.Equals(QuestName))
            {
                return q.Status;
            }            
        }
        return Quest.QUESTSTATUS.UNASSIGNED;
    }

    public static void SetQuestStatus(string QuestName, Quest.QUESTSTATUS newStatus)
    {
        foreach(Quest q in ThisInstance.Quests)
        {
            if (q.QuestName.Equals(QuestName))
            {
                q.Status = newStatus;
                return;
            }
        }
    }

    // reset Quests back to unassigned status
    public static void Reset()
    {
        foreach(Quest q in ThisInstance.Quests)
        {
            q.Status = Quest.QUESTSTATUS.UNASSIGNED;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
