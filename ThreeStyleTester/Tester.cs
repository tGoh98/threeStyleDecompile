using System.Windows.Forms;

namespace ThreeStyleTester
{
	public abstract class Tester
	{
		protected TesterForm Parent;

		public bool Enabled;

		public Tester(TesterForm parent)
		{
			Parent = parent;
		}

		public abstract void Register();

		public abstract void Unregister();

		public abstract void Reset();

		public abstract void KeyDown(object sender, KeyEventArgs e);

		public abstract void KeyUp(object sender, KeyEventArgs e);

		public static string msToStr(long ms)
		{
			string text = (ms / 10 % 100).ToString();
			text = new string('0', 2 - text.Length) + text;
			return ms / 1000 + "." + text + "s";
		}
	}
}
