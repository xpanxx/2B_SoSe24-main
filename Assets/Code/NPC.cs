using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	public DialogScreen DialogScreen;
	public DialogItem Item;

	// Start is called before the first frame update
	void Start() {

	}

	public void StartDialog() {
		DialogScreen.StartDialog(Item);
	}

	public void SetDialog(DialogItem newItem) {
		Item = newItem;
	}


}
