using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour {

	private QuestScreen QuestScreen;

	public string QuestObjective;

	public bool Completed;
	public UnityEvent OnCompleted;

	// Start is called before the first frame update
	void Start() {
		//sehr vorsichtig benutzen
		QuestScreen = FindFirstObjectByType<QuestScreen>();
	}

	// Update is called once per frame
	void Update() {

	}

	public void StartQuest() {
		if(Completed)
			return;

		//1. QuestScreen den Text geben
		QuestScreen.ShowQuest(this);
	}

	public void EndQuest() {
		if(Completed)
			return;

		QuestScreen.FinishQuest(this);
		Completed = true;
		OnCompleted.Invoke();
	}
}
