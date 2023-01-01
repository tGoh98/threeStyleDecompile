using System;

namespace ThreeStyleTester
{
	public class SettingsException : Exception
	{
		public SettingsException(string msg)
			: base(msg)
		{
		}
	}
}
