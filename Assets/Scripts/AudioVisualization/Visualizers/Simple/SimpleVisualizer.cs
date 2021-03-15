using AudioVisualization.Common;
using UnityEngine;

namespace AudioVisualization
{
	public class SimpleVisualizer : Visualizer {

		[SerializeField] private ItemSpawner _spawner;
		[SerializeField] private SimpleItem _prefab;
		[SerializeField] private float _multiplicator = 1;
		[SerializeField] private float _minimalSize = 1;
		[SerializeField] private float _maximalSize = 5;
		[SerializeField] private SpawnShape _shape;
		[SerializeField] private AnimationCurve _mappingCurve;

		private SimpleItem[] _items;

		private void SetSpawnerAmount(int amount)
		{
			_items = _spawner.SpawnPrefabs(_prefab, amount, _shape);
		}

		public override void Visualize(float[] samplesData)
		{
			if (_items == null)
			{
				SetSpawnerAmount(samplesData.Length);
				return;
			}

			for (var i = 0; i < _items.Length; i++)
			{
				var coefficient = 1 / (samplesData[i] + 1);
				var mappedValue = _mappingCurve.Evaluate(coefficient);
				var targetSize = samplesData[i] * mappedValue * _multiplicator + _minimalSize;
				_items[i].transform.localScale = new Vector3(1, targetSize, 1);
				_items[i].SetEmission(samplesData[i]);
			}
		}
	}
}
