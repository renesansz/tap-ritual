using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject GameUI;
	public GameObject MenuUI;
	public GameObject AboutUI;
	public GameObject HighScoreUI;

	/// <summary>
	/// Start game state.
	/// </summary>
	public void StartGame()
	{
		MenuUI.SetActive(false);
		GameUI.SetActive(true);
	}

	/// <summary>
	/// Display game menu.
	/// </summary>
	public void GoToMenu()
	{
		AboutUI.SetActive(false);
		GameUI.SetActive(false);
		MenuUI.SetActive(true);
	}

	/// <summary>
	/// Display about UI.
	/// </summary>
	public void GoToAbout()
	{
		MenuUI.SetActive(false);
		AboutUI.SetActive(true);
	}

	/// <summary>
	/// Display the high score UI.
	/// </summary>
	public void GotoHighScore()
	{
		MenuUI.SetActive(false);
		HighScoreUI.SetActive(true);
	}

}
