using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private List<Level> levels;

	[SerializeField] private TextMeshProUGUI levelTitleTxt;
	[SerializeField] private TextMeshProUGUI helpMessageTxt;
	[SerializeField] private TextMeshProUGUI tutoMessageTxt;
	[SerializeField] private GameObject endGameMessageGo;
	[SerializeField] private Transform rootLevel;
	[SerializeField] private GameObject winGo;
	[SerializeField] private Button nextLevelBtn;

	private Level currentLevel;

	private void Awake()
	{
		nextLevelBtn.onClick.AddListener(GoToNextLevel);
	}

	private void Start()
	{
		InitLevel(0);
	}

	public void InitLevel(int levelNumber)
	{
		if (currentLevel != null)
			Destroy(currentLevel.gameObject);

		winGo.SetActive(false);
		nextLevelBtn.gameObject.SetActive(false);

		if (levels.Count <= levelNumber)
			return;
		currentLevel = Instantiate(levels[levelNumber].gameObject).GetComponent<Level>();
		rootLevel.AddChildNormalized(currentLevel.transform);
		currentLevel.transform.localPosition = new Vector3(currentLevel.transform.localPosition.x, currentLevel.transform.localPosition.y, -1000);
		//currentLevel.transform.parent = rootLevel;

		levelTitleTxt.text = "Level " + currentLevel.LevelNumber;
		helpMessageTxt.text = currentLevel.HelpMessage;
		
		currentLevel.IsDone += CurrentLevel_IsDone;
	}
	private void GoToNextLevel()
	{
		InitLevel(currentLevel.LevelNumber);
	}

	private void CurrentLevel_IsDone()
	{
		EndLevel();
	}

	private void EndLevel()
	{
		tutoMessageTxt.gameObject.SetActive(false);

		if (currentLevel != null)
			currentLevel.IsDone -= CurrentLevel_IsDone;
		winGo.SetActive(true);

		if(currentLevel.LevelNumber < levels.Count)
		{
			nextLevelBtn.gameObject.SetActive(true);
		}
		else
		{
			nextLevelBtn.gameObject.SetActive(false);

			endGameMessageGo.SetActive(true);
		}
	}
}
