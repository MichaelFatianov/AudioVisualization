using System;
using UnityEngine;

namespace AudioVisualization.Tools
{
	[Serializable]
	public class FrequencyMilestone
	{
		[SerializeField] private string _name;
		
		[Range(21, 19999)]
		[SerializeField] private int _frequencyValue;


		public int FrequencyValue
		{
			get { return _frequencyValue; }
		}

		public string Name
		{
			get { return _name; }
		}

		public FrequencyMilestone(string name, int value)
		{
			_name = name;
			_frequencyValue = value;
		}
		
		public int GetShrankValue(float coefficient)
		{
			var newValue = Mathf.FloorToInt(_frequencyValue * coefficient);
			return newValue;
		}

	}
}