using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {

	private AudioSource currentAudio = null;

	public AudioSource bgAudio;
	public AudioSource danceAudio;
	public AudioSource highScoreAudio;
	public AudioSource aboutAudio;

	// Use this for initialization
	void Start() {
		// set audio settings
		aboutAudio.loop = true;
		aboutAudio.playOnAwake = false;
		bgAudio.loop = true;
		bgAudio.playOnAwake = false;
		danceAudio.loop = true;
		danceAudio.playOnAwake = false;
		highScoreAudio.loop = true;
		highScoreAudio.playOnAwake = false;

		// start background music
		StartBgMusic();
	}

	// Starts the about music
	public void StartAboutMusic() {
		clean();
		aboutAudio.Play();
		currentAudio = aboutAudio;
	}

	// Starts the background/main menu music 
	public void StartBgMusic() {
		clean();
		bgAudio.Play();
		currentAudio = bgAudio;
	}

	// Starts the dance/play music
	public void StartDanceMusic() {
		clean();
		danceAudio.Play();
		currentAudio = danceAudio;
	}
		
	// Starts the highscore music
	public void StartHighScoreMusic() {
		clean();
		highScoreAudio.Play();
		currentAudio = highScoreAudio;
	}

	// Used to make sure that any existing/current AudioClip
	// is stopped before playing a new AudioClip.
	private void clean(){
		if (currentAudio != null) {
			currentAudio.Stop();
		}	
	}
		
	// Update is called once per frame
	void Update() {
	
	}
}