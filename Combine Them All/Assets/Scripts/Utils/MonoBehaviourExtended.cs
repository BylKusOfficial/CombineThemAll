//**********************************************************************//
//    
//       \File	:	MonoBehaviourExtended.cs
//       \Description : Brief header for the (reason) class declaration
//
//       \Author	:	fbouchaib
//       \Project 	:	BBU AirScale Nokia
//       \Version	:	0.04.002
//       \Date		:	08/8/2019
//       \BU 		:	ON-X3D
//
// Copyright (c) 2019 Groupe ON-X, All Rights Reserved
// No part of this software and its documentation may be used, copied,
// modified, distributed and transmitted, in any form or by any means,
// without the prior written permission of Groupe ON-X.
//
//Development done by ON-X - 3D Business Unit (www.onx3d.com)
//**********************************************************************//
//**********************************************************************//
//    
//       \File	:	MonoBehaviourExtended.cs
//       \Description : Brief header for the (reason) class declaration
//
//       \Author	:	fbouchaib
//       \Project 	:	BBU AirScale Nokia
//       \Version	:	0.04.002
//       \Date		:	07/8/2019
//       \BU 		:	ON-X3D
//
// Copyright (c) 2019 Groupe ON-X, All Rights Reserved
// No part of this software and its documentation may be used, copied,
// modified, distributed and transmitted, in any form or by any means,
// without the prior written permission of Groupe ON-X.
//
//Development done by ON-X - 3D Business Unit (www.onx3d.com)
//**********************************************************************//
using UnityEngine;
using System.Collections.Generic;
using System;

static public class MethodExtensionForMonoBehaviourTransform
{
	/// <summary>
	/// Gets or add a component. Usage example:
	/// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
	/// </summary>
	static public T GetOrAddComponent<T>(this Component child) where T : Component
	{
		T result = child.GetComponent<T>();
		if (result == null)
		{
			result = child.gameObject.AddComponent<T>();
		}
		return result;
	}

	static public T[] GetComponentsInChildren<T>(this Component child, bool includeInactive, bool includeParent) where T : Component
	{
		T[] result = child.GetComponentsInChildren<T>(includeInactive);
		HashSet<T> temp = new HashSet<T>();

		if (!includeParent)
		{
			foreach (T component in result)
			{
				if (component.transform != child.transform)
					temp.Add(component);
			}
			result = new T[temp.Count];
			temp.CopyTo(result);
		}

		return result;
	}

	/// <summary>
	/// Attach a transform to another, set its scale to one and its position to zero (if specified).
	/// </summary>
	/// <param name="parent">Parent transform for the child transform.</param>
	/// <param name="child">Child to add</param>
	/// <param name="setPositionAtOrigin">If true, the child local position is set to zero.</param>
	public static void AddChildNormalized(
		this Transform parent, Transform child, bool setPositionAtOrigin = true, bool scale = true, bool worldPosition = true)
	{
		child.SetParent(parent, worldPosition);
		if (scale)
			child.localScale = Vector3.one;
		if (setPositionAtOrigin)
			child.localPosition = Vector3.zero;
	}

	/// <summary>
	/// Copy the 3D values (position, rotation and scale) from a source Transform into this one.
	/// If transforms are both RectTransform, also copy pivot and sizeDelta.
	/// </summary>
	public static void CopyValues(this Transform transform, Transform source, float deltaX = 0, float deltaY = 0)
	{
		transform.localPosition = source.localPosition;
		transform.localEulerAngles = source.localEulerAngles;
		transform.localScale = source.localScale;

		if (transform is RectTransform && source is RectTransform)
		{
			RectTransform rTransform = ((RectTransform)transform);
			RectTransform rSource = ((RectTransform)source);

			rTransform.pivot = rSource.pivot;
			rTransform.sizeDelta = rSource.sizeDelta;
		}
	}

	public static bool IsEqualTo(this Color me, Color other, float approximation=0.01f)
	{
		return Math.Abs(me.r - other.r) < approximation && Math.Abs(me.g - other.g) < approximation && Math.Abs(me.b - other.b) < approximation && Math.Abs(me.a - other.a) < approximation;
		//Mathf.Approximately(me.r, other.r)/* && Mathf.Approximately(me.g, other.g) && Mathf.Approximately(me.b, other.b) && Mathf.Approximately(me.a, other.a)*/;
		//return Mathf.Approximately(me.r, other.r) && Mathf.Approximately(me.g, other.g) && Mathf.Approximately(me.b, other.b) && Mathf.Approximately(me.a, other.a);
	}
}