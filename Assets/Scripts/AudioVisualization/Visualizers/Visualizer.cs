using UnityEngine;

namespace AudioVisualization.Common
{
	public class Visualizer: MonoBehaviour, IVisualizer
	{
		public virtual void Initialize() { }
		public virtual void Visualize(float[] samplesData) { }
	}
}