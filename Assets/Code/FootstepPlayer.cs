using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour {

	//2 Möglichkeiten
	//event path
	//public string EventPath;
	//event reference
	public EventReference FootstepEvent;

	// Start is called before the first frame update
	void Start() {

	}

	public void PlayFootstep(){
		RuntimeManager.PlayOneShot(FootstepEvent, transform.position);
	}

}
