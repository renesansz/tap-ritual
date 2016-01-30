using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

	int score;
	int combo;
	int hitpoints;
	int currentStep;
	int danceSteps;
	float timeRemaining;
	bool isStart = false;
	bool isPreviousCorrect = false;

	GameObject[] stepGuides;

	Text timeCounterText;
	Text comboCounterText;
	Text scoreCounterText;
	Text hpCounterText;

	/// <summary>
	/// Generates the steps.
	/// </summary>
	void GenerateSteps()
	{
		currentStep = Random.Range(0, 4);
		stepGuides[currentStep].SetActive(true);

		Debug.Log(currentStep);
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
		scoreCounterText.text = string.Format("Score: {0}", score);
		hpCounterText.text = string.Format("Chance: {0}", hitpoints);
		comboCounterText.text = "";

		stepGuides = GameObject.FindGameObjectsWithTag("StepMoves");

		for (int c = 0, limit = stepGuides.Length; c < limit; ++c) {
			stepGuides[c].SetActive(false);
		}

		GenerateSteps();

	}

	/// <summary>
	/// Raises the game start event.
	/// </summary>
	public void StartGame()
	{
		
		comboCounterText = GameObject.Find(Constants.COMBO_COUNTER).GetComponent<Text>();
		scoreCounterText = GameObject.Find(Constants.SCORE_COUNTER).GetComponent<Text>();
		timeCounterText = GameObject.Find(Constants.TIME_COUNTER).GetComponent<Text>();
		hpCounterText = GameObject.Find(Constants.HP_COUNTER).GetComponent<Text>();

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
			//Debug.Log ("Timer ticking...");

			// Time's UP!
			if (timeRemaining < 1F) {
				Debug.Log ("Timer Ended");
				isStart = false;
				return;
			}

			int minutes = Mathf.FloorToInt (timeRemaining / 60F);
			int seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
			string niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

			timeCounterText.text = niceTime;

			timeRemaining -= Time.deltaTime;

			//Debug.Log("Time remaining: " + timeRemaining.ToString ());

		}
	}

	/// <summary>
	/// Add points to user score.
	/// </summary>
	void AddPoints()
	{
		Debug.Log("Add Points");

		// Check for next combo
		if (isPreviousCorrect) {
			combo++;
			comboCounterText.text = string.Format("Combo {0}", combo);
		} else {
			isPreviousCorrect = true;
		}

		score += (Constants.SCORE_POINTS * combo);
		scoreCounterText.text = string.Format("Score: {0}", score);
	}

	/// <summary>
	/// Subtract points to user score.
	/// </summary>
	void SubtractPoints()
	{
		Debug.Log("Subtract Points");
		if (isPreviousCorrect) {
			isPreviousCorrect = false;
			combo = 1;
			comboCounterText.text = "";
		}

		if (hitpoints == 0) {
			EndGame();
		} else {
			hitpoints--;
			hpCounterText.text = string.Format("Chance: {0}", hitpoints);
		}

		if (score > 0) {
			score -= Constants.SCORE_POINTS;
			scoreCounterText.text = string.Format("Score: {0}", score);
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

		if (currentStep == 0) {
			AddPoints();
		} else {
			SubtractPoints();
		}

		stepGuides[currentStep].SetActive(false);
		GenerateSteps();
	}

	/// <summary>
	/// Do dance move 2.
	/// </summary>
	public void DoMove2() {
		Debug.Log("start DoMove2()");

		if (currentStep == 1) {
			AddPoints();
		} else {
			SubtractPoints();
		}

		stepGuides[currentStep].SetActive(false);
		GenerateSteps();
	}

	/// <summary>
	/// Do dance move 3.
	/// </summary>
	public void DoMove3() {
		Debug.Log("start DoMove3()");

		if (currentStep == 2) {
			AddPoints();
		} else {
			SubtractPoints();
		}

		stepGuides[currentStep].SetActive(false);
		GenerateSteps();
	}	

	/// <summary>
	/// Do dance move 4.
	/// </summary>
	public void DoMove4() {
		Debug.Log("start DoMove4()");

		if (currentStep == 3) {
			AddPoints();
		} else {
			SubtractPoints();
		}

		stepGuides[currentStep].SetActive(false);
		GenerateSteps();
	}	

	/// <summary>
	/// Do dance move 5.
	/// </summary>
	public void DoMove5() {
		Debug.Log("start DoMove5()");

		if (currentStep == 4) {
			AddPoints();
		} else {
			SubtractPoints();
		}

		stepGuides[currentStep].SetActive(false);
		GenerateSteps();
	}

}
