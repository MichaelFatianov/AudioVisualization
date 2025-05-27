using AudioVisualization.Enums;
using UnityEngine;

namespace AudioVisualization.Tools
{
	[RequireComponent(typeof(AudioSource))]
	public class SpectrumProvider : MonoBehaviour
	{
		[SerializeField] private SamplesResolution _resolution;
		public SamplesResolution Resolution => _resolution;
		private AudioSource _source;
		public float[] RawSpectrumData { get; private set; }

		private void Start()
		{
			_source = GetComponent<AudioSource>();

			var numberOfSamples = (int) _resolution;
			RawSpectrumData = new float[numberOfSamples];
		}

		private void Update()
		{
			GetRawSpectrumData();
		}

		private void GetRawSpectrumData()
		{
			_source.GetSpectrumData(RawSpectrumData, 0, FFTWindow.Blackman);
		}
	}
}