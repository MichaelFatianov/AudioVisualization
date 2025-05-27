using System;
using System.Collections.Generic;
using AudioVisualization.Common;
using AudioVisualization.Enums;
using AudioVisualization.ScriptableObjects;
using AudioVisualization.Structs;
using AudioVisualization.Tools;
using UnityEngine;

namespace AudioVisualization
{
	public class MainController : MonoBehaviour
	{
		[SerializeField] private SpectrumProvider _provider;
		[SerializeField] private VisualizerStack[] _visualizerStacks;

		private void Start()
		{
			foreach (var visualizerStack in _visualizerStacks)
			{
				visualizerStack.Initialize(_provider.Resolution);
			}

			foreach (var visualizerStack in _visualizerStacks)
			{
				Debug.Log(visualizerStack.SpectrumBuffer);
			}
		}

		private void Update()
		{
			VisualizeData(_provider.RawSpectrumData);
		}

		private void VisualizeData(float[] spectrumData)
		{
			foreach (var visualizerStack in _visualizerStacks)
			{
				var processedSpectrumData = visualizerStack.SpectrumDataProcessor.GetBandedSpectrumData(spectrumData);
				var bufferedSpectrumData = visualizerStack.SpectrumBuffer.Buffer(processedSpectrumData);
				visualizerStack.Visualizer.Visualize(bufferedSpectrumData);
			}
		}
	}
}