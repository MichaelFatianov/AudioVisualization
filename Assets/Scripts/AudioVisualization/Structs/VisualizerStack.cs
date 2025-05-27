using System;
using Assets.Scripts.AudioVisualization.Tools;
using AudioVisualization.Common;
using AudioVisualization.Enums;
using UnityEngine;

namespace AudioVisualization.Structs
{
	[Serializable]
	public class VisualizerStack
	{
		[Space(10f)] [SerializeField] private Visualizer _visualizer;
		[SerializeField] private BandsProvider _bandsProvider;
		[Space(25f)] [SerializeField] private SpectrumDataProcessor _spectrumDataProcessor;
		[Space(25f)] private SpectrumBuffer _spectrumBuffer;
		[SerializeField] private bool _useClamp;
		[SerializeField] private Vector2 _clamp;
		[SerializeField] private BufferReductor _bufferReductor;

		public SpectrumDataProcessor SpectrumDataProcessor => _spectrumDataProcessor;

		public SpectrumBuffer SpectrumBuffer => _spectrumBuffer;

		public Visualizer Visualizer => _visualizer;

		public void Initialize(SamplesResolution resolution)
		{
			_visualizer.Initialize();
			_spectrumDataProcessor.Initialize(_bandsProvider.GetBands(resolution));
			_spectrumBuffer = new SpectrumBuffer(
				_spectrumDataProcessor.BandedSpectrumData.Length, 
				_bufferReductor,
				_clamp,
				_useClamp);
		}
	}
}