using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

	int score;
	int combo;
	int hitpoints;
	float timeRemaining;
	bool isStart = false;

	Text timeCounterText;
	Text comboCounterText;
	Text scoreCounterText;

	/// <summary>
	/// Resets the counters.
	/// </summary>
	void ResetCounters()
	{
		score = 0;
		combo = 0;
		timeRemaining = 0F;
		hitpoints = 100;
	}

	/// <summary>
	/// Initializes the counters.
	/// </summary>
	void InitializeCounters()
	{
		score = 0;
		combo = 1;
		timeRemaining = 181.0F;
		hitpoints = 100;
	}

	/// <summary>
	/// Raises the game start event.
	/// </summary>
	public void StartGame()
	{
		
		ResetCounters();
		InitializeCounters();

		timeCounterText = GameObject.Find(Constants.TIME_COUNTER).GetComponent<Text>();
		comboCounterText = GameObject.Find(Constants.COMBO_COUNTER).GetComponent<Text>();
		scoreCounterText = GameObject.Find(Constants.SCORE_COUNTER).GetComponent<Text>();

		isStart = true;
	}

	/// <summary>
	/// Fixed update for the game.
	/// </summary>
	void FixedUpdate()
	{
		if (isStart) {
			Debug.Log ("Timer ticking...");

			if (timeRemaining == 0F) {
				Debug.Log ("Timer Ended");
				isStart = false;
			}

			int minutes = Mathf.FloorToInt (timeRemaining / 60F);
			int seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
			string niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

			timeCounterText.text = niceTime;

			timeRemaining -= Time.deltaTime;

			Debug.Log ("Time remaining: " + timeRemaining.ToString ());

		}
	}
		
	////////////////
	/// CONTROLS ///
	////////////////

	/// <summary>
	/// Do dance move 1.
	/// </summary>
	public void DoMove1() {
		Debug.Log("start DoMove1()");
	}

	/// <summary>
	/// Do dance move 2.
	/// </summary>
	public void DoMove2() {
		Debug.Log("start DoMove2()");
	}

	/// <summary>
	/// Do dance move 3.
	/// </summary>
	public void DoMove3() {
		Debug.Log("start DoMove3()");
	}	

	/// <summary>
	/// Do dance move 4.
	/// </summary>
	public void DoMove4() {
		Debug.Log("start DoMove4()");
	}	

	/// <summary>
	/// Do dance move 5.
	/// </summary>
	public void DoMove5() {
		Debug.Log("start DoMove5()");
	}

}
