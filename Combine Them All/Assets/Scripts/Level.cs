using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
	public event System.Action IsDone;

	[SerializeField] private string helpMessage;
	[SerializeField] private List<CombinedPoints> allCombinedPoints;
	[SerializeField] private GameObject winGo;

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

		IsDone?.Invoke();
	}
}
