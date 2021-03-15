﻿using System;
using UnityEngine;

namespace AudioVisualization.Structs
{
	[Serializable]
	public struct FrequencyBand
	{
		private readonly int _min;
		private readonly int _max;

		public int Max
		{
			get { return _max; }
		}

		public int Min
		{
			get { return _min; }
		}

		public float Range
		{
			get { return _max - _min; }
		}

		public FrequencyBand(int min, int max)
		{
			if (max > min)
			{
				_max = max;
				_min = min;
			}
			else
			{
				_max = min;
				_min = max;

				Debug.LogWarning("Minimal value is more than max value in band. Values have been swapped.");
			}
		}
	}
}