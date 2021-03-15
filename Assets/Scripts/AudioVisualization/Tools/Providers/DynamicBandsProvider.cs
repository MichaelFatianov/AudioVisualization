using System;
using System.Collections.Generic;
using AudioVisualization.Enums;
using AudioVisualization.Structs;
using AudioVisualization.Tools;
using UnityEngine;

namespace Assets.Scripts.AudioVisualization.Tools
{
	[Serializable]
	public class DynamicBandsProvider: BandsProvider
	{
		private List<FrequencyMilestone> _milestones;
		[SerializeField] private int _bandsCount = 9;
		
		private const int MinimalFrequency = 20;
		private const int MaximalFrequency = 20000;

		public override FrequencyBand[] GetBands(SamplesResolution resolution)
		{
			var coefficient = (float) resolution / MaximalFrequency;
			Debug.Log("Band shrink coefficient: " + coefficient);
			
			var min = Mathf.FloorToInt(MinimalFrequency * coefficient);
			var max = Mathf.FloorToInt(MaximalFrequency * coefficient);
			
			var diapasons = RangeFrequency(min, max);
			Debug.Log("Diapasons: " + diapasons.Length);

			var previousMilestone = min;
			
			for (var i = 0; i <= _milestones.Count; i++)
			{
				if (i == _milestones.Count)
				{
					// Creating last diapason
					diapasons[i] = new FrequencyBand(previousMilestone, max);
					Debug.Log("Created diapason: #" + i + ": " + diapasons[i].Min + " - " + diapasons[i].Max);
				}
				else
				{
					var shrankValue = _milestones[i].FrequencyValue;
					
					diapasons[i] = new FrequencyBand(previousMilestone, shrankValue);
					previousMilestone = shrankValue;
					Debug.Log("Created diapason #" + i + ": " + diapasons[i].Min + " - " + diapasons[i].Max);
				}
			}
			return diapasons;
		}

		private FrequencyBand[] RangeFrequency(float min, float max)
		{
			_milestones = new List<FrequencyMilestone>();
			var workingDiapason = max - min;
			for (var i = 1; i < _bandsCount; i++)
			{
				var milestoneFrequency = workingDiapason / _bandsCount * i;
				var milestone = new FrequencyMilestone(i.ToString(), Mathf.FloorToInt(milestoneFrequency));
				_milestones.Add(milestone);
			}
			return new FrequencyBand[_milestones.Count+1];
		}

		
	}
}