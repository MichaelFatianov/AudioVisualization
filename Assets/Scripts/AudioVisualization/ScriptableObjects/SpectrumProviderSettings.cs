using AudioVisualization.Enums;
using UnityEngine;

namespace AudioVisualization.ScriptableObjects
{
	[CreateAssetMenu(menuName = "AudioVisualization/Settings", fileName = "ProviderSettings")]
	public class SpectrumProviderSettings : ScriptableObject
	{
		[SerializeField] private SamplesResolution _resolution;

		public SamplesResolution Resolution
		{
			get { return _resolution; }
		}
	}
}
