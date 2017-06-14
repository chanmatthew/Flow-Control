﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class bgmHandler : MonoBehaviour { 	public static bgmHandler bgm;  	public AudioSource audio; 	public bool hitObstacle = false; 	public bool goalReached = false; 	static bool beginAudio = false;  	void Awake(){ 		if (!beginAudio) { 			audio.Play (); 			DontDestroyOnLoad (gameObject); 			beginAudio = true; 			bgm = this; 		}   	}    	IEnumerator hit(){ 		audio.pitch = .45f; 		yield return new WaitForSeconds (.4f); 		audio.pitch = 1.0f; 		hitObstacle = false; 	}  	IEnumerator collect(){ 		audio.pitch = 1.5f; 		yield return new WaitForSeconds (.2f); 		audio.pitch = 1.0f; 		goalReached = false; 	}  	void Update () {									//	Can stop the audio at a certain scene if you want to 		//	if(Application.loadedLevelName == "Proto2"){ 		//		audio.Stop(); 		//		beginAudio = false; 		if(hitObstacle == true){ 			//audio.pitch = .45f; 			StartCoroutine(hit()); 		} 		if(goalReached == true){ 			StartCoroutine(collect()); 		}  	} 	//}  }  