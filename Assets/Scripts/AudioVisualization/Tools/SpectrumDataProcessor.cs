using System;
using AudioVisualization.Enums;
using AudioVisualization.Structs;
using UnityEngine;

namespace Assets.Scripts.AudioVisualization.Tools
{
	[Serializable]
	public class SpectrumDataProcessor
	{
		private FrequencyBand[] _bands;
		private float[] _bandedSpectrumData;
		[SerializeField] private SpectrumMode _spectrumMode;

		public float[] BandedSpectrumData => _bandedSpectrumData;

		public void Initialize(FrequencyBand[] bands)
		{
			_bands = bands;
			_bandedSpectrumData = new float[bands.Length];
		}

		public float[] GetBandedSpectrumData(float[] spectrumData)
		{
			if (_bands == null || _spectrumMode == SpectrumMode.Raw)
			{
				return spectrumData;
			}

			for (var i = 0; i < _bands.Length; i++)
			{
				var sum = 0f;
				var count = 1;

				var band = _bands[i];
				for (var j = band.Min; j < band.Max; j++)
				{
					sum += spectrumData[j] * count;
					count++;
				}

				_bandedSpectrumData[i] = sum / count;
			}

			return _bandedSpectrumData;
		}
	}
}