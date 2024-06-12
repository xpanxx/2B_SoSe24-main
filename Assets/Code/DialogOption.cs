using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[System.Serializable] //attribute
public class DialogOption : MonoBehaviour {

	public string Text;

	public DialogItem NextDialog;
	

	public UnityEvent OnOptionSelected;
}
