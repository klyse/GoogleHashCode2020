using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode.Base
{
	public abstract class BaseAnalyzer<TInput> where TInput : IInput, new() 
	{
		public TInput Input { get; } = new TInput();

		public StringBuilder Results { get; } = new StringBuilder();

		public abstract void Analyze();
	}
}
