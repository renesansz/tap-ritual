using UnityEngine;

public static class GameSystem {

	/// <summary>
	/// Sets the high score of the game.
	/// </summary>
	/// <param name="newScore">The new score to set</param>
	public static void SetHighscore(int newScore) {

		Debug.Log("start SetHighscore()");

		if (newScore > PlayerPrefs.GetInt(Constants.HIGH_SCORE)) {
			PlayerPrefs.SetInt(Constants.HIGH_SCORE, newScore);
		}

	}

	/// <summary>
	/// Gets the highscore of the game.
	/// </summary>
	/// <returns>An int value of the high score of the game.</returns>
	public static int GetHighscore() {

		Debug.Log("start GetHighscore()");

		return PlayerPrefs.GetInt(Constants.HIGH_SCORE);

	}

}
