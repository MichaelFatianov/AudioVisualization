using AudioVisualization.Enums;
using AudioVisualization.Structs;
using UnityEngine;

namespace Assets.Scripts.AudioVisualization.Tools
{
	public class BandsProvider:MonoBehaviour
	{
		public virtual FrequencyBand[] GetBands(SamplesResolution resolution)
		{
			return new FrequencyBand[0];
		}
	}
}