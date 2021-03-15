using UnityEngine;

namespace AudioVisualization
{
	public class SimpleItem: MonoBehaviour
	{
		[SerializeField] private Renderer _renderer;
		private static readonly int EMISSION_VALUE = Shader.PropertyToID("EmissionValue");

		public void SetEmission(float value)
		{
			_renderer.material.SetFloat(EMISSION_VALUE, value);
		}
	}
}