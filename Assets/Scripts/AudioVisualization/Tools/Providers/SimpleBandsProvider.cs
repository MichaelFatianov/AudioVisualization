using System;
using System.Collections.Generic;
using Assets.Scripts.AudioVisualization.Tools;
using AudioVisualization.Enums;
using AudioVisualization.Structs;
using UnityEngine;

namespace AudioVisualization.Tools
{
	[Serializable]
	public class SimpleBandsProvider: BandsProvider
	{
		[SerializeField] private FrequencyMilestone[] _milestones;

		private const int MinimalFrequency = 20;
		private const int MaximalFrequency = 20000;

		public override FrequencyBand[] GetBands(SamplesResolution resolution)
		{
			var diapasons = new FrequencyBand[_milestones.Length + 1];

			var coefficient = (float) resolution / MaximalFrequency;

			Debug.Log("Band shrink coefficient: " + coefficient);

			var min = Mathf.FloorToInt(MinimalFrequency * coefficient);
			var max = Mathf.FloorToInt(MaximalFrequency * coefficient);

			_milestones = Sort(_milestones);

			var previousMilestone = min;

			for (var i = 0; i <= _milestones.Length; i++)
			{
				if (i == _milestones.Length)
				{
					diapasons[i] = new FrequencyBand(previousMilestone, max);
					Debug.Log("Created diapason: #" + i + ": " + diapasons[i].Min + " - " + diapasons[i].Max);
				}
				else
				{
					var shrankValue = _milestones[i].GetShrankValue(coefficient);

					diapasons[i] = new FrequencyBand(previousMilestone, shrankValue);
					previousMilestone = shrankValue;
					Debug.Log("Created diapason #" + i + ": " + diapasons[i].Min + " - " + diapasons[i].Max);
				}
			}

			return diapasons;
		}

		private FrequencyMilestone[] Sort(IList<FrequencyMilestone> milestones)
		{
			foreach (var milestone in milestones)
			{
				for (var i = 1; i < milestones.Count; i++)
				{
					if (milestones[i].FrequencyValue >= milestones[i - 1].FrequencyValue) continue;
					var tmp = _milestones[i - 1];
					_milestones[i - 1] = _milestones[i];
					_milestones[i] = tmp;
				}
			}

			return _milestones;
		}
	}
}