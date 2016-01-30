using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

	int score;
	int combo;
	int hitpoints;
	float timeRemaining;
	bool isStart = false;
	bool isPreviousCorrect = false;

	Text timeCounterText;
	Text comboCounterText;
	Text scoreCounterText;

	/// <summary>
	/// Generate dance steps.
	/// </summary>
	void GenerateSteps()
	{
	}

	/// <summary>
	/// Resets the counters.
	/// </summary>
	void ResetCounters()
	{
		score = 0;
		combo = 0;
		hitpoints = 0;
		timeRemaining = 0F;
	}

	/// <summary>
	/// Initializes the counters.
	/// </summary>
	void InitializeCounters()
	{
		score = 0;
		combo = 1;
		timeRemaining = Constants.MAX_TIME;
		hitpoints = Constants.MAX_HP;

		// Initialize UI
		scoreCounterText.text = score.ToString();
		comboCounterText.text = "";
		GameObject.Find("HitPoints").GetComponent<Text>().text = hitpoints.ToString();

	}

	/// <summary>
	/// Raises the game start event.
	/// </summary>
	public void StartGame()
	{

		timeCounterText = GameObject.Find(Constants.TIME_COUNTER).GetComponent<Text>();
		comboCounterText = GameObject.Find(Constants.COMBO_COUNTER).GetComponent<Text>();
		scoreCounterText = GameObject.Find(Constants.SCORE_COUNTER).GetComponent<Text>();

		ResetCounters();
		InitializeCounters();


		isStart = true;
	}

	/// <summary>
	/// Fixed update for the game.
	/// </summary>
	void FixedUpdate()
	{
		if (isStart) {
			Debug.Log ("Timer ticking...");

			// Time's UP!
			if (timeRemaining < 1F) {
				Debug.Log ("Timer Ended");
			}

			int minutes = Mathf.FloorToInt (timeRemaining / 60F);
			int seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
			string niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

			timeCounterText.text = niceTime;

			timeRemaining -= Time.deltaTime;

			Debug.Log ("Time remaining: " + timeRemaining.ToString ());

		}
	}

	/// <summary>
	/// Add points to user score.
	/// </summary>
	void AddPoints()
	{
		// Check for next combo
		if (isPreviousCorrect) {
			combo++;
			comboCounterText.text = string.Format("Combo {0}", combo);
		} else {
			isPreviousCorrect = true;
		}

		if (hitpoints < Constants.MAX_HP) {
			hitpoints++;
			GameObject.Find("HitPoints").GetComponent<Text>().text = hitpoints.ToString();
		}

		score += (Constants.SCORE_POINTS * combo);
		scoreCounterText.text = score.ToString();

	}

	/// <summary>
	/// Subtract points to user score.
	/// </summary>
	void SubtractPoints()
	{
		if (isPreviousCorrect) {
			isPreviousCorrect = false;
			combo = 1;
			comboCounterText.text = "";
		}

		if (hitpoints == 0) {
			EndGame ();
			return;
		} else {
			hitpoints--;
			GameObject.Find("HitPoints").GetComponent<Text>().text = hitpoints.ToString();
		}

		if (score > 0) {
			score -= Constants.SCORE_POINTS;
			scoreCounterText.text = score.ToString ();
		}
	}

	void EndGame()
	{
		isStart = false;
		GameObject.Find(Constants.GAME_OVER).GetComponent<Text>().enabled = true;
	}
		
	////////////////
	/// CONTROLS ///
	////////////////

	/// <summary>
	/// Do dance move 1.
	/// </summary>
	public void DoMove1() {
		Debug.Log("start DoMove1()");
		AddPoints();
	}

	/// <summary>
	/// Do dance move 2.
	/// </summary>
	public void DoMove2() {
		Debug.Log("start DoMove2()");
		AddPoints();
	}

	/// <summary>
	/// Do dance move 3.
	/// </summary>
	public void DoMove3() {
		Debug.Log("start DoMove3()");
		SubtractPoints();
	}	

	/// <summary>
	/// Do dance move 4.
	/// </summary>
	public void DoMove4() {
		Debug.Log("start DoMove4()");
		SubtractPoints();
	}	

	/// <summary>
	/// Do dance move 5.
	/// </summary>
	public void DoMove5() {
		Debug.Log("start DoMove5()");
		AddPoints();
	}

}
