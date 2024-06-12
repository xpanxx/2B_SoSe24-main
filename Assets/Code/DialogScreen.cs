using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogScreen : MonoBehaviour {

	private DialogItem _currentItem;

	public GameObject Container;

	public TMP_Text TextBox;

	public List<GameObject> Buttons;

	public UnityEvent<bool> DialogOpen;

	//event emitter
	public StudioEventEmitter Emitter;
	

	// Start is called before the first frame update
	void Start() {
		EndDialog();
	}
	
	public void StartDialog(DialogItem item) {
		Container.SetActive(true);

		TextBox.text = item.Text;

		//for schleife
		for(int i = 0; i < Buttons.Count; i++) {
			if(i < item.Options.Count) {
				Buttons[i].SetActive(true);
				Buttons[i].GetComponentInChildren<TMP_Text>().text = item.Options[i].Text;
			} else {
				Buttons[i].SetActive(false);
			}
		}

		_currentItem = item;

		DialogOpen.Invoke(true);

		
		Emitter.EventInstance.setParameterByName("Rain", 0);
	}

	public void EndDialog() {
		Container.SetActive(false);
		DialogOpen.Invoke(false);

		Emitter.EventInstance.setParameterByName("Rain", 1);
	}

	public void ChooseOption(int index) {
		DialogOption option = _currentItem.Options[index];

		//Invoke = Auslösen
		option.OnOptionSelected.Invoke();

		if(option.NextDialog != null) {
			StartDialog(option.NextDialog);
		} else {
			EndDialog();
		}
	}
}
