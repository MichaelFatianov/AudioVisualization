using System;
using System.Collections.Generic;
using AudioVisualization.Structs;
using UnityEngine;

namespace AudioVisualization
{
	[Serializable]
	public class SpectrumBuffer
	{
		[SerializeField] 
		private readonly BufferReductor _bufferReductor;

		private readonly Vector2 _clamp;
		private readonly bool _useClamp;
		private readonly float[] _bufferedSpectrum;
		private readonly float[] _decreaseValue;
		

		public SpectrumBuffer(int bufferSize, BufferReductor bufferReductor, Vector2 clamp, bool useClamp)
		{
			_bufferReductor = bufferReductor;
			_clamp = clamp;
			_useClamp = useClamp;
			_bufferedSpectrum = new float[bufferSize];
			_decreaseValue = new float[bufferSize];
		}

		public float[] BufferedSpectrum
		{
			get { return _bufferedSpectrum; }
		}

		public float[] Buffer(IList<float> spectrumData)
		{
			if (BufferedSpectrum == null)
			{
				return new float[0];
			}
	
			for (var i = 0; i < spectrumData.Count; i++)
			{
				var data = _useClamp ? Mathf.Clamp(spectrumData[i], _clamp.x, _clamp.y) : spectrumData[i];
				if (data > BufferedSpectrum[i])
				{
					BufferedSpectrum[i] = data;
					_decreaseValue[i] = _bufferReductor.InitialReduceValue;
				}
				else
				{
					BufferedSpectrum[i] = BufferedSpectrum[i] - _decreaseValue[i] < 0f ? 0f : BufferedSpectrum[i] - _decreaseValue[i];
					_decreaseValue[i] *= _bufferReductor.ReduceValueMultiplicator;
				}
			}
			
			return BufferedSpectrum;
		}
	}
}