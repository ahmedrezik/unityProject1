using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    void Awake(){
    	DontDestroyOnLoad(transform.gameObject);
    }
    void pause(){
    	gameObject.GetComponent<AudioSource>().Pause();
    }
}
