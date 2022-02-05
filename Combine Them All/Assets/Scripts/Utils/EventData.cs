//**********************************************************************//
//    
//       \File	:	EventData.cs
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
using UnityEngine;
using System.Collections;

namespace ToolRex.Utils
{
    public class EventData<T>
    {
        public class EventDataArgs : System.EventArgs
        {
            public T Value { get; private set; }
            public EventDataArgs(T newValue)
            {
                Value = newValue;
            }
        }

        public event System.EventHandler<EventDataArgs> OnValueChanged;
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (object.Equals(_value, value))
                    return;
                _value = value;
                if (OnValueChanged != null)
                    OnValueChanged.Invoke(this, new EventDataArgs(_value));
            }
        }
    }
}