using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

	private AudioSource currentAudio = null;

	public AudioSource menuAudio;
	public AudioSource danceAudio;
	public AudioSource highScoreAudio;
	public AudioSource aboutAudio;
	public AudioSource introAudio;
	public AudioSource failAudio;

	// Use this for initialization
	void Start() {
		// set audio settings
		aboutAudio.loop = true;
		aboutAudio.playOnAwake = false;

		menuAudio.loop = true;
		menuAudio.playOnAwake = false;

		danceAudio.loop = true;
		danceAudio.playOnAwake = false;

		highScoreAudio.loop = true;
		highScoreAudio.playOnAwake = false;

		introAudio.loop = false;
		introAudio.playOnAwake = false;

		failAudio.loop = false;
		failAudio.playOnAwake = false;

		StartMenuMusic();
	}

	// Starts the about music
	public void StartAboutMusic() {
		clean();
		introAudio.Play();
		aboutAudio.Play();
		currentAudio = aboutAudio;
	}

	// Starts the background/main menu music 
	public void StartMenuMusic() {
		clean();
		menuAudio.Play();
		currentAudio = menuAudio;
	}

	// Starts the dance/play music
	public void StartDanceMusic() {
		menuAudio.volume = (float)0.5;
		StartCoroutine(playDanceClip());
	}

	// Coroutine for StartDanceMusic
	// Play intro music, then follow with dance music
	IEnumerator playDanceClip(){
		AudioClip danceClip = danceAudio.clip;
		AudioClip introClip = introAudio.clip;

		danceAudio.clip = introClip;
		danceAudio.Play();
		yield return new WaitForSeconds(danceAudio.clip.length);
		danceAudio.clip = danceClip;
		danceAudio.Play();
		currentAudio = danceAudio;
	}
		
	// Starts the highscore music
	public void StartHighScoreMusic() {
		clean();
		highScoreAudio.Play();
		currentAudio = highScoreAudio;
	}

	// Starts fail music
	public void StartFailMusic(){
		clean();
		failAudio.Play();
		currentAudio = failAudio;
	}

	// Used to make sure that any existing/current AudioClip
	// is stopped before playing a new AudioClip.
	private void clean(){
		if (currentAudio != null) {
			currentAudio.Stop();
		}

		if (menuAudio.isPlaying) {
			menuAudio.Stop ();
		}
	}
		
	// Update is called once per frame
	void Update() {
	
	}
}