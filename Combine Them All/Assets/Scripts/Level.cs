using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
	public event System.Action IsDone;

	[SerializeField] private int levelNumber;
	[SerializeField] private string helpMessage;
	[SerializeField] private Transform fixedElement;
	[SerializeField] private List<CombinedPoints> allCombinedPoints;

	[SerializeField] private Transform centerElementTr;

	public int LevelNumber => levelNumber;
	public string HelpMessage => helpMessage;

	private const float rotationSpeed = 35;
	private bool endLevel = false;
	private ElementPart[] elementsPart;
	private Vector3 originalCenterElementPosition;

	private void Awake()
	{
		elementsPart = GetComponentsInChildren<ElementPart>();
		////originalCenterElementPosition = centerElementTr.localPosition;
	}

	private void Start()
	{
		fixedElement.GetComponent<Renderer>().material = UnityConstant.Instance.FlatFixedMaterial;
	}

	private void Update()
	{
		if (endLevel)
			return;

		endLevel = true;
		foreach (CombinedPoints combinedPoint in allCombinedPoints)
		{
			if (Mathf.Abs(combinedPoint.Point1.position.x - combinedPoint.Point2.position.x) > combinedPoint.MinDistanceXaxis 
				|| Mathf.Abs(combinedPoint.Point1.position.y - combinedPoint.Point2.position.y) > combinedPoint.MinDistanceYaxis)
				endLevel = false;
		}

		if (endLevel)
			StartCoroutine(EndAsync());
	}

	private IEnumerator EndAsync()
	{
		foreach (ElementPart elementPart in elementsPart)
			elementPart.SetFinished();

		//StartCoroutine(FinishCombinePoints(transform, -originalCenterElementPosition*3));

		//foreach (CombinedPoints combinedPoint in allCombinedPoints)
		//	yield return StartCoroutine(FinishCombinePoints(combinedPoint.Point1.parent, combinedPoint.Point2.parent.position));

		StartCoroutine(Rotate());
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
			yield return null;
		}
	}
}
