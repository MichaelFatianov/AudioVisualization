using System;
using UnityEngine;

namespace AudioVisualization.Structs
{
	[Serializable]
	public struct BufferReductor
	{
		[SerializeField] [Range(0.001f, 0.01f)]
		private float _initialReduceValue;
		[SerializeField] [Range(1f,2f)] 
		private float _reduceValueMultiplicator;

		public float ReduceValueMultiplicator => _reduceValueMultiplicator;
		public float InitialReduceValue => _initialReduceValue;
		
		public BufferReductor(float initialReduceValue, float reduceValueMultiplicator)
		{
			_initialReduceValue = initialReduceValue;
			_reduceValueMultiplicator = reduceValueMultiplicator;
		}
	}
}