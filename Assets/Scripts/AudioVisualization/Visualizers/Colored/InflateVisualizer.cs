using AudioVisualization.Common;
using UnityEngine;

namespace AudioVisualization
{
	public class InflateVisualizer : Visualizer {

		[SerializeField] private InflatedItem[] _items;
		[SerializeField] private float _multiplicator = 1;
		[SerializeField] private float _minimalSize = 1;
		[SerializeField] private int _band;
		[SerializeField] private bool _randomOffset;
		[SerializeField] private float _offset;

		public override void Initialize()
		{
			if (_randomOffset)
				foreach (var inflatedItem in _items)
				{
					var randomOffset = Random.Range(0f, 2f);
					inflatedItem.SetOffset(randomOffset);
				}
			else
			{
				foreach (var inflatedItem in _items)
				{
					inflatedItem.SetOffset(_offset);
				}
			}
		}

		public override void Visualize(float[] samplesData)
		{
			for (var i = 0; i < _items.Length; i++)
			{
				var colorRampValue = samplesData[_band] * _multiplicator;
				var scaleValue = colorRampValue + _minimalSize;
				_items[i].SetColor(colorRampValue);
				_items[i].transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
			}
		}
	}
}
