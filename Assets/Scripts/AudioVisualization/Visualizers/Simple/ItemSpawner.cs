using System.Collections.Generic;
using UnityEngine;

namespace AudioVisualization
{
	public class ItemSpawner : MonoBehaviour
	{
		private SimpleItem[] _items;
		[SerializeField] private float _offset = 0.05f;

		public SimpleItem[] GetItems()
		{
			return _items;
		}

		public SimpleItem[] SpawnPrefabs(SimpleItem prefab, int amount, SpawnShape shape)
		{
			switch (shape)
			{
				case SpawnShape.Line:
					_items = SpawnLine(prefab, amount);
					break;
				case SpawnShape.Circle:
					_items = SpawnCircle(prefab, amount);
					break;
			}

			return _items;
		}

		private SimpleItem[] SpawnLine(SimpleItem prefab, int amount)
		{
			var cubes = new List<SimpleItem>();
		
			for (var i = 0; i < amount; i++)
			{
				var cube = Instantiate(prefab, transform);
				// cube.name = "Cube " + i;
				var position = transform.position;
				position.x += i +( i * _offset) ;
				cube.transform.SetPositionAndRotation(position, Quaternion.identity);
				cubes.Add(cube);
			}

			return cubes.ToArray();
		}

		private SimpleItem[] SpawnCircle(SimpleItem prefab, int amount)
		{
			var cubes = new List<SimpleItem>();
			var offset = (float) 360 / amount;
			var radius = amount /  (Mathf.PI * 2);
			var parentTransform = transform;
			for (var i = 0; i < amount; i++)
			{
				var item = Instantiate(prefab, transform);
				// cube.name = "Cube " + i;
				parentTransform.localRotation = Quaternion.Euler(0, 1 - offset * i,0);
				var position = parentTransform.forward * radius;
				var itemTransform = item.transform;
				itemTransform.position = parentTransform.TransformPoint(position);
				itemTransform.localRotation = parentTransform.rotation;
				cubes.Add(item);
			}
			return cubes.ToArray();
		}
	}
}
