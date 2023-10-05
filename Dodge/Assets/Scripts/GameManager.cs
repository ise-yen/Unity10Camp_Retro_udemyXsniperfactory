using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public GameObject gameOverText;
	public TextMeshProUGUI recordText;

	public int score;
	bool isGameOver;

    private void Start()
    {
		score = 0;
		isGameOver = false;
    }

    private void Update()
    {
		if (!isGameOver)
		{
			scoreText.text = "Score: " + score;
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene("SampleScene");
			}
		}
    }

	/// <summary>
	/// 현재 게임을 게임오버 상태로 변경하는 메서드
	/// </summary>
	public void EndGame()
	{
		isGameOver = true;
		gameOverText.SetActive(true);

		int bestScore = PlayerPrefs.GetInt("BestScore");

		if(score > bestScore)
		{
			bestScore = score;
			PlayerPrefs.SetInt("BestScore", bestScore);
		}

		recordText.text = "Best Score: " + bestScore;
	}
}
