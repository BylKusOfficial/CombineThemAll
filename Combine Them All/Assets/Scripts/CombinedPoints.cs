using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombinedPoints/* : MonoBehaviour*/
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

	[SerializeField] private float minDistanceXaxis = 0.1f;
	[SerializeField] private float minDistanceYaxis = 0.1f;

	public Transform Point1 => point1;
	public Transform Point2 => point2;
	public float MinDistanceXaxis => minDistanceXaxis;
	public float MinDistanceYaxis => minDistanceYaxis;

	//public bool IsCombined { get; private set; }

	//private const float combinedMinDistance = 0.07f;

	//private void Update()
	//{
	//	Debug.Log("Distance(point1.position, point1.position) " + Vector2.Distance(point1.position, point2.position));

	//	IsCombined = Vector2.Distance(point1.position, point2.position) < combinedMinDistance;
	//}
}
