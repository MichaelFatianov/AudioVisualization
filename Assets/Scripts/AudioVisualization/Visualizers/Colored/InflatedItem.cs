using UnityEngine;

namespace AudioVisualization
{
	public class InflatedItem : MonoBehaviour
	{
		[SerializeField] private Renderer _renderer;
		private static readonly int EMISSION_VALUE = Shader.PropertyToID("EmissionValue");
		private static readonly int OFFSET_VALUE = Shader.PropertyToID("OffsetValue");

		public void SetColor(float value)
		{
			_renderer.material.SetFloat(EMISSION_VALUE, value);
		}

		public void SetOffset(float offset)
		{
			_renderer.material.SetFloat(OFFSET_VALUE, offset);
		}
	}
}