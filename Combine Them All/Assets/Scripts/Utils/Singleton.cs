//**********************************************************************//
//    
//       \File	:	Singleton.cs
//       \Description : Brief header for the (reason) class declaration
//
//       \Author	:	fbouchaib
//       \Project 	:	BBU AirScale Nokia
//       \Version	:	0.04.002
//       \Date		:	01/8/2019
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
//       \File	:	Singleton.cs
//       \Description : Brief header for the (reason) class declaration
//
//       \Author	:	fbouchaib
//       \Project 	:	Pro MT Borne
//       \Version	:	1.01.002
//       \Date		:	08/7/2019
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

/// <summary>
/// Simple MonoBehaviour singleton.
/// The singleton must already exist when Instance is called, otherwise it
/// will return null (this kind of singleton is not automatically created).
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
				_instance = (T)FindObjectOfType(typeof(T));
			return _instance;
		}
	}

	public static bool Exists { get { return _instance != null; } }

	public static void CreateIfDoNotExist()
	{
		if (_instance == null)
			_instance = new GameObject("(singleton) " + typeof(T).ToString()).AddComponent<T>();
	}

	private void OnDestroy()
	{
		_instance = null;
	}
}
