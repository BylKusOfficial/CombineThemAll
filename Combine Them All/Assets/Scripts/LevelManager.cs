using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private GameObject winGo;

	private Level currentLevel;

	public void InitLevel(Level level)
	{
		currentLevel = level;

		currentLevel.IsDone += CurrentLevel_IsDone;
	}

	private void CurrentLevel_IsDone()
	{
		EndLevel();
	}

	private void EndLevel()
	{
		if(currentLevel != null)
			currentLevel.IsDone -= CurrentLevel_IsDone;
		winGo.SetActive(true);
	}
}
