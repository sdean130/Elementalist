using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour {

    public AudioClip MusicClip;

    public AudioSource MusicSource;

    bool started;

	// Use this for initialization
	void Start () {
        MusicSource.clip = MusicClip;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
