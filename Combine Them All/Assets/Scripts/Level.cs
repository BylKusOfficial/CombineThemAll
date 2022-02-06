using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
	public event System.Action IsDone;

	[SerializeField] private int levelNumber;
	[SerializeField] private string helpMessage;
	[SerializeField] private List<CombinedPoints> allCombinedPoints;
	[SerializeField] private Transform centerElementTr;

	public int LevelNumber => levelNumber;
	public string HelpMessage => helpMessage;

	private const float rotationSpeed = 35;
	private const float combinedMinDistance = 0.1f;
	private bool endLevel = false;
	private DragObject[] dragObjects;
	private Vector3 originalCenterElementPosition;

	private void Awake()
	{
		dragObjects = GetComponentsInChildren<DragObject>();
		////originalCenterElementPosition = centerElementTr.localPosition;
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
			StartCoroutine(EndAsync());
	}

	private IEnumerator EndAsync()
	{
		foreach(DragObject dragObject in dragObjects)
		{
			dragObject.EnableDrag(false);
			dragObject.SetOriginalMaterial();
		}

		//StartCoroutine(FinishCombinePoints(transform, -originalCenterElementPosition*3));

		//foreach (CombinedPoints combinedPoint in allCombinedPoints)
		//	yield return StartCoroutine(FinishCombinePoints(combinedPoint.Point1.parent, combinedPoint.Point2.parent.position));

		//StartCoroutine(Rotate());
		IsDone?.Invoke();

		yield return null;
	}

	

	private IEnumerator FinishCombinePoints(Transform point1, Vector3 point2)
	{
		while(Vector2.Distance(point1.position, point2) > 0.07f)
		{
			point1.position = Vector3.Lerp(point1.position, point2, Time.deltaTime * 5);
			yield return null;
		}
	}

	private IEnumerator Rotate()
	{
		while(true)
		{
			transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
			//transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (Time.deltaTime * rotationSpeed), transform.localEulerAngles.z);
			//transform.Rotate(Vector3.up, 45 * Time.deltaTime * rotationSpeed, );
			yield return null;
		}
	}
}
