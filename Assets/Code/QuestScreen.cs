using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScreen : MonoBehaviour {

	public TMP_Text ObjectiveText;

	// Start is called before the first frame update
	void Start() {

	}

	public void ShowQuest(Quest quest) {
		ObjectiveText.text = quest.QuestObjective;
	}

	public void FinishQuest(Quest quest){
		ObjectiveText.text = ""; //string.Empty
	}

}
