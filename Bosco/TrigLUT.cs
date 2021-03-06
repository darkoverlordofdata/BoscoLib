﻿/**
 *--------------------------------------------------------------------+
 * TrigLUT.cs
 *--------------------------------------------------------------------+
 * Copyright DarkOverlordOfData (c) 2015
 *--------------------------------------------------------------------+
 *
 * This file is a part of Bosco
 *
 * Bosco is free software; you can copy, modify, and distribute
 * it under the terms of the MIT License
 *
 *--------------------------------------------------------------------+
 */
using UnityEngine;
using System;

namespace Bosco.Utils {
	// Thanks to Riven
	// From: http://riven8192.blogspot.com/2009/08/fastmath-sincos-lookup-tables.html
	public class TrigLUT  {
	
		public static float Sin(float rad) {
			return sin[(int) (rad * radToIndex) & SIN_MASK];
		}
	
		public static float Cos(float rad) {
			return cos[(int) (rad * radToIndex) & SIN_MASK];
		}
	
		public static float SinDeg(float deg) {
			return sin[(int) (deg * degToIndex) & SIN_MASK];
		}
	
		public static float CosDeg(float deg) {
			return cos[(int) (deg * degToIndex) & SIN_MASK];
		}
	
		private static int SIN_BITS, SIN_MASK, SIN_COUNT;
		private static float radFull, radToIndex;
		private static float degFull, degToIndex;
		private static float[] sin, cos;
	
		static TrigLUT() {
			Debug.Log("TrigLUT static constructor");
			SIN_BITS = 12;
			SIN_MASK = ~(-1 << SIN_BITS);
			SIN_COUNT = SIN_MASK + 1;
	
			radFull = (float) (Math.PI * 2.0);
			degFull = (float) (360.0);
			radToIndex = SIN_COUNT / radFull;
			degToIndex = SIN_COUNT / degFull;
	
			sin = new float[SIN_COUNT];
			cos = new float[SIN_COUNT];
	
			for (int i = 0; i < SIN_COUNT; i++) {
				sin[i] = (float) Math.Sin((i + 0.5f) / SIN_COUNT * radFull);
				cos[i] = (float) Math.Cos((i + 0.5f) / SIN_COUNT * radFull);
			}
		}
		
	}
}