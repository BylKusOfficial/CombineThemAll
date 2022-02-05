using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
	public event System.Action IsDone;

	[SerializeField] private int levelNumber;
	[SerializeField] private string helpMessage;
	[SerializeField] private float rotationSpeed = 2;
	[SerializeField] private List<CombinedPoints> allCombinedPoints;

	public int LevelNumber => levelNumber;
	public string HelpMessage => helpMessage;

	private const float combinedMinDistance = 0.07f;
	private bool endLevel = false;
	private DragObject[] dragObjects;

	private void Awake()
	{
		dragObjects = GetComponentsInChildren<DragObject>();
	}

	private void Update()
	{
		if (endLevel)
			return;

		endLevel = true;
		foreach (CombinedPoints combinedPoint in allCombinedPoints)
		{
			if(Vector2.Distance(combinedPoint.Point1.position, combinedPoint.Point2.position) > combinedMinDistance)
				endLevel = false;
		}

		if (endLevel)
			End();
	}

	private void End()
	{
		foreach(DragObject dragObject in dragObjects)
			dragObject.EnableDrag(false);

		StartCoroutine(Rotate());
		IsDone?.Invoke();
	}

	private IEnumerator Rotate()
	{
		while(true)
		{
			transform.Rotate(Vector3.up, 45 * Time.deltaTime * rotationSpeed);
			yield return null;
		}
	}
}
