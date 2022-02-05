//**********************************************************************//
//    
//       \File	:	Prefabs.cs
//       \Description : Brief header for the (reason) class declaration
//
//       \Author	:	fbouchaib
//       \Project 	:	BBU AirScale Nokia
//       \Version	:	0.04.002
//       \Date		:	25/11/2019
//       \BU 		:	ON-X3D
//
// Copyright (c) 2019 Groupe ON-X, All Rights Reserved
// No part of this software and its documentation may be used, copied,
// modified, distributed and transmitted, in any form or by any means,
// without the prior written permission of Groupe ON-X.
//
//Development done by ON-X - 3D Business Unit (www.onx3d.com)
//**********************************************************************//
using System;
using UnityEngine;

/// <summary>
/// Utilitaire pour instancier (et caster si besoin) un prefab rapidement.
/// </summary>
public static class Prefabs
{
	/// <summary>
	/// Instantiates a prefab from resources and gets the specified component type.
	/// </summary>
	/// <returns>The specified component on the instantiated prefab</returns>
	/// <param name="prefab">Path to prefab in a resources folder</param>
	/// <typeparam name="T">Type of the component to get and return</typeparam>
	public static T Instantiate<T>(string prefabPath) where T : Component
	{
		GameObject gameObject = Instantiate(prefabPath);
		return (gameObject != null) ? gameObject.transform.GetOrAddComponent<T>() : null;
	}

	/// <summary>
	/// Instantiates a prefab from resources.
	/// </summary>
	/// <returns>The instantiated prefab as a GameObject</returns>
	/// <param name="prefab">Path to prefab in a resources folder</param>
	public static GameObject Instantiate(string prefabPath)
	{
		UnityEngine.Object prefab = Resources.Load(prefabPath);
		if (prefab == null)
			throw new Exception("This prefab doesn't exist : " + prefabPath);
		return UnityEngine.Object.Instantiate(prefab) as GameObject;
	}
}

