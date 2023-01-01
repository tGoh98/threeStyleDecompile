namespace ThreeStyleTester
{
	public struct Move
	{
		public MoveBase Base;

		public MoveDir Dir;

		public Move(MoveBase b, MoveDir d)
		{
			this = default(Move);
			Base = b;
			Dir = d;
		}

		public override string ToString()
		{
			return Base.ToString() + ((Dir == MoveDir.N) ? "" : ((Dir == MoveDir.P) ? "'" : "2"));
		}
	}
}
