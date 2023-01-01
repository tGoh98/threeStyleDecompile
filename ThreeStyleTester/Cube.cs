using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeStyleTester
{
	public class Cube
	{
		public Cubie[,,] Cubies = new Cubie[6, 3, 3];

		public const int U = 0;

		public const int D = 5;

		public const int F = 2;

		public const int B = 4;

		public const int L = 1;

		public const int R = 3;

		public Cube()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Cubies[0, i, j] = new Cubie(this, CColor.W, 0, i, j, new Cubie(this, CColor.W, 0, i, j));
					Cubies[5, i, j] = new Cubie(this, CColor.Y, 5, i, j, new Cubie(this, CColor.Y, 5, i, j));
					Cubies[2, i, j] = new Cubie(this, CColor.G, 2, i, j, new Cubie(this, CColor.G, 2, i, j));
					Cubies[4, i, j] = new Cubie(this, CColor.B, 4, i, j, new Cubie(this, CColor.B, 4, i, j));
					Cubies[1, i, j] = new Cubie(this, CColor.O, 1, i, j, new Cubie(this, CColor.O, 1, i, j));
					Cubies[3, i, j] = new Cubie(this, CColor.R, 3, i, j, new Cubie(this, CColor.R, 3, i, j));
				}
			}
		}

		public void DoMove(Move move)
		{
			Cubie[,,] array = (Cubie[,,])Cubies.Clone();
			if (move.Base == MoveBase.U)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 0, 0] = array[0, 0, 2];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 0, 1] = array[0, 1, 2];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 0, 2] = array[0, 2, 2];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[0, 1, 0] = array[0, 0, 1];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 2] = array[0, 2, 1];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[0, 2, 0] = array[0, 0, 0];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[0, 2, 1] = array[0, 1, 0];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[0, 2, 2] = array[0, 2, 0];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[2, 0, 0] = array[3, 0, 0];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 1, 0] = array[3, 1, 0];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 2, 0] = array[3, 2, 0];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[4, 0, 0] = array[1, 0, 0];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 1, 0] = array[1, 1, 0];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 2, 0] = array[1, 2, 0];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[1, 0, 0] = array[2, 0, 0];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 1, 0] = array[2, 1, 0];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 2, 0] = array[2, 2, 0];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[3, 0, 0] = array[4, 0, 0];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 1, 0] = array[4, 1, 0];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 2, 0] = array[4, 2, 0];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 0, 0] = array[0, 2, 0];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 0, 1] = array[0, 1, 0];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 0, 2] = array[0, 0, 0];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[0, 1, 0] = array[0, 2, 1];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 2] = array[0, 0, 1];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[0, 2, 0] = array[0, 2, 2];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[0, 2, 1] = array[0, 1, 2];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[0, 2, 2] = array[0, 0, 2];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[2, 0, 0] = array[1, 0, 0];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 1, 0] = array[1, 1, 0];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 2, 0] = array[1, 2, 0];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[4, 0, 0] = array[3, 0, 0];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 1, 0] = array[3, 1, 0];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 2, 0] = array[3, 2, 0];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[1, 0, 0] = array[4, 0, 0];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 1, 0] = array[4, 1, 0];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 2, 0] = array[4, 2, 0];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[3, 0, 0] = array[2, 0, 0];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 1, 0] = array[2, 1, 0];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 2, 0] = array[2, 2, 0];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 0, 0] = array[0, 2, 2];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 0, 1] = array[0, 2, 1];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 0, 2] = array[0, 2, 0];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[0, 1, 0] = array[0, 1, 2];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 2] = array[0, 1, 0];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[0, 2, 0] = array[0, 0, 2];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[0, 2, 1] = array[0, 0, 1];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[0, 2, 2] = array[0, 0, 0];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[2, 0, 0] = array[4, 0, 0];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 1, 0] = array[4, 1, 0];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 2, 0] = array[4, 2, 0];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[4, 0, 0] = array[2, 0, 0];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 1, 0] = array[2, 1, 0];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 2, 0] = array[2, 2, 0];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[1, 0, 0] = array[3, 0, 0];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 1, 0] = array[3, 1, 0];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 2, 0] = array[3, 2, 0];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[3, 0, 0] = array[1, 0, 0];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 1, 0] = array[1, 1, 0];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 2, 0] = array[1, 2, 0];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
				}
			}
			else if (move.Base == MoveBase.R)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 2, 0] = array[2, 2, 0];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[0, 2, 1] = array[2, 2, 1];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[0, 2, 2] = array[2, 2, 2];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[5, 2, 0] = array[4, 0, 2];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[5, 2, 1] = array[4, 0, 1];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[5, 2, 2] = array[4, 0, 0];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[2, 2, 0] = array[5, 2, 0];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[2, 2, 1] = array[5, 2, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[2, 2, 2] = array[5, 2, 2];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[4, 0, 0] = array[0, 2, 2];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 0, 1] = array[0, 2, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 0, 2] = array[0, 2, 0];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[3, 0, 0] = array[3, 0, 2];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 0, 1] = array[3, 1, 2];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 0, 2] = array[3, 2, 2];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
					Cubies[3, 1, 0] = array[3, 0, 1];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 1, 2] = array[3, 2, 1];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
					Cubies[3, 2, 0] = array[3, 0, 0];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
					Cubies[3, 2, 1] = array[3, 1, 0];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
					Cubies[3, 2, 2] = array[3, 2, 0];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 2, 0] = array[4, 0, 2];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[0, 2, 1] = array[4, 0, 1];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[0, 2, 2] = array[4, 0, 0];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[5, 2, 0] = array[2, 2, 0];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[5, 2, 1] = array[2, 2, 1];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[5, 2, 2] = array[2, 2, 2];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[2, 2, 0] = array[0, 2, 0];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[2, 2, 1] = array[0, 2, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[2, 2, 2] = array[0, 2, 2];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[4, 0, 0] = array[5, 2, 2];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 0, 1] = array[5, 2, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 0, 2] = array[5, 2, 0];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[3, 0, 0] = array[3, 2, 0];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 0, 1] = array[3, 1, 0];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 0, 2] = array[3, 0, 0];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
					Cubies[3, 1, 0] = array[3, 2, 1];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 1, 2] = array[3, 0, 1];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
					Cubies[3, 2, 0] = array[3, 2, 2];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
					Cubies[3, 2, 1] = array[3, 1, 2];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
					Cubies[3, 2, 2] = array[3, 0, 2];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 2, 0] = array[5, 2, 0];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[0, 2, 1] = array[5, 2, 1];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[0, 2, 2] = array[5, 2, 2];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[5, 2, 0] = array[0, 2, 0];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[5, 2, 1] = array[0, 2, 1];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[5, 2, 2] = array[0, 2, 2];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[2, 2, 0] = array[4, 0, 2];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[2, 2, 1] = array[4, 0, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[2, 2, 2] = array[4, 0, 0];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[4, 0, 0] = array[2, 2, 2];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 0, 1] = array[2, 2, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 0, 2] = array[2, 2, 0];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[3, 0, 0] = array[3, 2, 2];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 0, 1] = array[3, 2, 1];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 0, 2] = array[3, 2, 0];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
					Cubies[3, 1, 0] = array[3, 1, 2];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 1, 2] = array[3, 1, 0];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
					Cubies[3, 2, 0] = array[3, 0, 2];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
					Cubies[3, 2, 1] = array[3, 0, 1];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
					Cubies[3, 2, 2] = array[3, 0, 0];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
			}
			else if (move.Base == MoveBase.F)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 0, 2] = array[1, 2, 2];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[0, 1, 2] = array[1, 2, 1];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[0, 2, 2] = array[1, 2, 0];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[5, 0, 0] = array[3, 0, 2];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 1, 0] = array[3, 0, 1];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 2, 0] = array[3, 0, 0];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[2, 0, 0] = array[2, 0, 2];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 0, 1] = array[2, 1, 2];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 0, 2] = array[2, 2, 2];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[2, 1, 0] = array[2, 0, 1];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 2] = array[2, 2, 1];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[2, 2, 0] = array[2, 0, 0];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[2, 2, 1] = array[2, 1, 0];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[2, 2, 2] = array[2, 2, 0];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[1, 2, 0] = array[5, 0, 0];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[1, 2, 1] = array[5, 1, 0];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[1, 2, 2] = array[5, 2, 0];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
					Cubies[3, 0, 0] = array[0, 0, 2];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 0, 1] = array[0, 1, 2];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 0, 2] = array[0, 2, 2];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 0, 2] = array[3, 0, 0];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[0, 1, 2] = array[3, 0, 1];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[0, 2, 2] = array[3, 0, 2];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[5, 0, 0] = array[1, 2, 0];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 1, 0] = array[1, 2, 1];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 2, 0] = array[1, 2, 2];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[2, 0, 0] = array[2, 2, 0];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 0, 1] = array[2, 1, 0];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 0, 2] = array[2, 0, 0];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[2, 1, 0] = array[2, 2, 1];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 2] = array[2, 0, 1];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[2, 2, 0] = array[2, 2, 2];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[2, 2, 1] = array[2, 1, 2];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[2, 2, 2] = array[2, 0, 2];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[1, 2, 0] = array[0, 2, 2];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[1, 2, 1] = array[0, 1, 2];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[1, 2, 2] = array[0, 0, 2];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
					Cubies[3, 0, 0] = array[5, 2, 0];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 0, 1] = array[5, 1, 0];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 0, 2] = array[5, 0, 0];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 0, 2] = array[5, 2, 0];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[0, 1, 2] = array[5, 1, 0];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[0, 2, 2] = array[5, 0, 0];
					Cubies[0, 2, 2].Face = 0;
					Cubies[0, 2, 2].X = 2;
					Cubies[0, 2, 2].Y = 2;
					Cubies[5, 0, 0] = array[0, 2, 2];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 1, 0] = array[0, 1, 2];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 2, 0] = array[0, 0, 2];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[2, 0, 0] = array[2, 2, 2];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 0, 1] = array[2, 2, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 0, 2] = array[2, 2, 0];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[2, 1, 0] = array[2, 1, 2];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 2] = array[2, 1, 0];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[2, 2, 0] = array[2, 0, 2];
					Cubies[2, 2, 0].Face = 2;
					Cubies[2, 2, 0].X = 2;
					Cubies[2, 2, 0].Y = 0;
					Cubies[2, 2, 1] = array[2, 0, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[2, 2, 2] = array[2, 0, 0];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[1, 2, 0] = array[3, 0, 2];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[1, 2, 1] = array[3, 0, 1];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[1, 2, 2] = array[3, 0, 0];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
					Cubies[3, 0, 0] = array[1, 2, 2];
					Cubies[3, 0, 0].Face = 3;
					Cubies[3, 0, 0].X = 0;
					Cubies[3, 0, 0].Y = 0;
					Cubies[3, 0, 1] = array[1, 2, 1];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 0, 2] = array[1, 2, 0];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
				}
			}
			else if (move.Base == MoveBase.D)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[5, 0, 0] = array[5, 0, 2];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 0, 1] = array[5, 1, 2];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 0, 2] = array[5, 2, 2];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[5, 1, 0] = array[5, 0, 1];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 2] = array[5, 2, 1];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[5, 2, 0] = array[5, 0, 0];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[5, 2, 1] = array[5, 1, 0];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[5, 2, 2] = array[5, 2, 0];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[2, 0, 2] = array[1, 0, 2];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[2, 1, 2] = array[1, 1, 2];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[2, 2, 2] = array[1, 2, 2];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[4, 0, 2] = array[3, 0, 2];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[4, 1, 2] = array[3, 1, 2];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[4, 2, 2] = array[3, 2, 2];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 2] = array[4, 0, 2];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[1, 1, 2] = array[4, 1, 2];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[1, 2, 2] = array[4, 2, 2];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
					Cubies[3, 0, 2] = array[2, 0, 2];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
					Cubies[3, 1, 2] = array[2, 1, 2];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
					Cubies[3, 2, 2] = array[2, 2, 2];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[5, 0, 0] = array[5, 2, 0];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 0, 1] = array[5, 1, 0];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 0, 2] = array[5, 0, 0];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[5, 1, 0] = array[5, 2, 1];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 2] = array[5, 0, 1];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[5, 2, 0] = array[5, 2, 2];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[5, 2, 1] = array[5, 1, 2];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[5, 2, 2] = array[5, 0, 2];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[2, 0, 2] = array[3, 0, 2];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[2, 1, 2] = array[3, 1, 2];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[2, 2, 2] = array[3, 2, 2];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[4, 0, 2] = array[1, 0, 2];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[4, 1, 2] = array[1, 1, 2];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[4, 2, 2] = array[1, 2, 2];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 2] = array[2, 0, 2];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[1, 1, 2] = array[2, 1, 2];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[1, 2, 2] = array[2, 2, 2];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
					Cubies[3, 0, 2] = array[4, 0, 2];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
					Cubies[3, 1, 2] = array[4, 1, 2];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
					Cubies[3, 2, 2] = array[4, 2, 2];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[5, 0, 0] = array[5, 2, 2];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 0, 1] = array[5, 2, 1];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 0, 2] = array[5, 2, 0];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[5, 1, 0] = array[5, 1, 2];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 2] = array[5, 1, 0];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[5, 2, 0] = array[5, 0, 2];
					Cubies[5, 2, 0].Face = 5;
					Cubies[5, 2, 0].X = 2;
					Cubies[5, 2, 0].Y = 0;
					Cubies[5, 2, 1] = array[5, 0, 1];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[5, 2, 2] = array[5, 0, 0];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[2, 0, 2] = array[4, 0, 2];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[2, 1, 2] = array[4, 1, 2];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[2, 2, 2] = array[4, 2, 2];
					Cubies[2, 2, 2].Face = 2;
					Cubies[2, 2, 2].X = 2;
					Cubies[2, 2, 2].Y = 2;
					Cubies[4, 0, 2] = array[2, 0, 2];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[4, 1, 2] = array[2, 1, 2];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[4, 2, 2] = array[2, 2, 2];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 2] = array[3, 0, 2];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[1, 1, 2] = array[3, 1, 2];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[1, 2, 2] = array[3, 2, 2];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
					Cubies[3, 0, 2] = array[1, 0, 2];
					Cubies[3, 0, 2].Face = 3;
					Cubies[3, 0, 2].X = 0;
					Cubies[3, 0, 2].Y = 2;
					Cubies[3, 1, 2] = array[1, 1, 2];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
					Cubies[3, 2, 2] = array[1, 2, 2];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
			}
			else if (move.Base == MoveBase.L)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 0, 0] = array[4, 2, 2];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 0, 1] = array[4, 2, 1];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 0, 2] = array[4, 2, 0];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[5, 0, 0] = array[2, 0, 0];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 0, 1] = array[2, 0, 1];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 0, 2] = array[2, 0, 2];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[2, 0, 0] = array[0, 0, 0];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 0, 1] = array[0, 0, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 0, 2] = array[0, 0, 2];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[4, 2, 0] = array[5, 0, 2];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[4, 2, 1] = array[5, 0, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[4, 2, 2] = array[5, 0, 0];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 0] = array[1, 0, 2];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 0, 1] = array[1, 1, 2];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 0, 2] = array[1, 2, 2];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[1, 1, 0] = array[1, 0, 1];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 1, 2] = array[1, 2, 1];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[1, 2, 0] = array[1, 0, 0];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[1, 2, 1] = array[1, 1, 0];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[1, 2, 2] = array[1, 2, 0];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 0, 0] = array[2, 0, 0];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 0, 1] = array[2, 0, 1];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 0, 2] = array[2, 0, 2];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[5, 0, 0] = array[4, 2, 2];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 0, 1] = array[4, 2, 1];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 0, 2] = array[4, 2, 0];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[2, 0, 0] = array[5, 0, 0];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 0, 1] = array[5, 0, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 0, 2] = array[5, 0, 2];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[4, 2, 0] = array[0, 0, 2];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[4, 2, 1] = array[0, 0, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[4, 2, 2] = array[0, 0, 0];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 0] = array[1, 2, 0];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 0, 1] = array[1, 1, 0];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 0, 2] = array[1, 0, 0];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[1, 1, 0] = array[1, 2, 1];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 1, 2] = array[1, 0, 1];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[1, 2, 0] = array[1, 2, 2];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[1, 2, 1] = array[1, 1, 2];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[1, 2, 2] = array[1, 0, 2];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 0, 0] = array[5, 0, 0];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 0, 1] = array[5, 0, 1];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 0, 2] = array[5, 0, 2];
					Cubies[0, 0, 2].Face = 0;
					Cubies[0, 0, 2].X = 0;
					Cubies[0, 0, 2].Y = 2;
					Cubies[5, 0, 0] = array[0, 0, 0];
					Cubies[5, 0, 0].Face = 5;
					Cubies[5, 0, 0].X = 0;
					Cubies[5, 0, 0].Y = 0;
					Cubies[5, 0, 1] = array[0, 0, 1];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 0, 2] = array[0, 0, 2];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[2, 0, 0] = array[4, 2, 2];
					Cubies[2, 0, 0].Face = 2;
					Cubies[2, 0, 0].X = 0;
					Cubies[2, 0, 0].Y = 0;
					Cubies[2, 0, 1] = array[4, 2, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 0, 2] = array[4, 2, 0];
					Cubies[2, 0, 2].Face = 2;
					Cubies[2, 0, 2].X = 0;
					Cubies[2, 0, 2].Y = 2;
					Cubies[4, 2, 0] = array[2, 0, 2];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[4, 2, 1] = array[2, 0, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[4, 2, 2] = array[2, 0, 0];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 0] = array[1, 2, 2];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 0, 1] = array[1, 2, 1];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 0, 2] = array[1, 2, 0];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[1, 1, 0] = array[1, 1, 2];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 1, 2] = array[1, 1, 0];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[1, 2, 0] = array[1, 0, 2];
					Cubies[1, 2, 0].Face = 1;
					Cubies[1, 2, 0].X = 2;
					Cubies[1, 2, 0].Y = 0;
					Cubies[1, 2, 1] = array[1, 0, 1];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[1, 2, 2] = array[1, 0, 0];
					Cubies[1, 2, 2].Face = 1;
					Cubies[1, 2, 2].X = 2;
					Cubies[1, 2, 2].Y = 2;
				}
			}
			else if (move.Base == MoveBase.B)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 0, 0] = array[3, 2, 0];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 1, 0] = array[3, 2, 1];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 2, 0] = array[3, 2, 2];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[5, 0, 2] = array[1, 0, 0];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[5, 1, 2] = array[1, 0, 1];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[5, 2, 2] = array[1, 0, 2];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[4, 0, 0] = array[4, 0, 2];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 0, 1] = array[4, 1, 2];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 0, 2] = array[4, 2, 2];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[4, 1, 0] = array[4, 0, 1];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 2] = array[4, 2, 1];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[4, 2, 0] = array[4, 0, 0];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[4, 2, 1] = array[4, 1, 0];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[4, 2, 2] = array[4, 2, 0];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 0] = array[0, 2, 0];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 0, 1] = array[0, 1, 0];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 0, 2] = array[0, 0, 0];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[3, 2, 0] = array[5, 2, 2];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
					Cubies[3, 2, 1] = array[5, 1, 2];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
					Cubies[3, 2, 2] = array[5, 0, 2];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 0, 0] = array[1, 0, 2];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 1, 0] = array[1, 0, 1];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 2, 0] = array[1, 0, 0];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[5, 0, 2] = array[3, 2, 2];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[5, 1, 2] = array[3, 2, 1];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[5, 2, 2] = array[3, 2, 0];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[4, 0, 0] = array[4, 2, 0];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 0, 1] = array[4, 1, 0];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 0, 2] = array[4, 0, 0];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[4, 1, 0] = array[4, 2, 1];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 2] = array[4, 0, 1];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[4, 2, 0] = array[4, 2, 2];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[4, 2, 1] = array[4, 1, 2];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[4, 2, 2] = array[4, 0, 2];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 0] = array[5, 0, 2];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 0, 1] = array[5, 1, 2];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 0, 2] = array[5, 2, 2];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[3, 2, 0] = array[0, 0, 0];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
					Cubies[3, 2, 1] = array[0, 1, 0];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
					Cubies[3, 2, 2] = array[0, 2, 0];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 0, 0] = array[5, 2, 2];
					Cubies[0, 0, 0].Face = 0;
					Cubies[0, 0, 0].X = 0;
					Cubies[0, 0, 0].Y = 0;
					Cubies[0, 1, 0] = array[5, 1, 2];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 2, 0] = array[5, 0, 2];
					Cubies[0, 2, 0].Face = 0;
					Cubies[0, 2, 0].X = 2;
					Cubies[0, 2, 0].Y = 0;
					Cubies[5, 0, 2] = array[0, 2, 0];
					Cubies[5, 0, 2].Face = 5;
					Cubies[5, 0, 2].X = 0;
					Cubies[5, 0, 2].Y = 2;
					Cubies[5, 1, 2] = array[0, 1, 0];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[5, 2, 2] = array[0, 0, 0];
					Cubies[5, 2, 2].Face = 5;
					Cubies[5, 2, 2].X = 2;
					Cubies[5, 2, 2].Y = 2;
					Cubies[4, 0, 0] = array[4, 2, 2];
					Cubies[4, 0, 0].Face = 4;
					Cubies[4, 0, 0].X = 0;
					Cubies[4, 0, 0].Y = 0;
					Cubies[4, 0, 1] = array[4, 2, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 0, 2] = array[4, 2, 0];
					Cubies[4, 0, 2].Face = 4;
					Cubies[4, 0, 2].X = 0;
					Cubies[4, 0, 2].Y = 2;
					Cubies[4, 1, 0] = array[4, 1, 2];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 2] = array[4, 1, 0];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[4, 2, 0] = array[4, 0, 2];
					Cubies[4, 2, 0].Face = 4;
					Cubies[4, 2, 0].X = 2;
					Cubies[4, 2, 0].Y = 0;
					Cubies[4, 2, 1] = array[4, 0, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[4, 2, 2] = array[4, 0, 0];
					Cubies[4, 2, 2].Face = 4;
					Cubies[4, 2, 2].X = 2;
					Cubies[4, 2, 2].Y = 2;
					Cubies[1, 0, 0] = array[3, 2, 2];
					Cubies[1, 0, 0].Face = 1;
					Cubies[1, 0, 0].X = 0;
					Cubies[1, 0, 0].Y = 0;
					Cubies[1, 0, 1] = array[3, 2, 1];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 0, 2] = array[3, 2, 0];
					Cubies[1, 0, 2].Face = 1;
					Cubies[1, 0, 2].X = 0;
					Cubies[1, 0, 2].Y = 2;
					Cubies[3, 2, 0] = array[1, 0, 2];
					Cubies[3, 2, 0].Face = 3;
					Cubies[3, 2, 0].X = 2;
					Cubies[3, 2, 0].Y = 0;
					Cubies[3, 2, 1] = array[1, 0, 1];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
					Cubies[3, 2, 2] = array[1, 0, 0];
					Cubies[3, 2, 2].Face = 3;
					Cubies[3, 2, 2].X = 2;
					Cubies[3, 2, 2].Y = 2;
				}
			}
			if (move.Base == MoveBase.u)
			{
				DoMove(new Move(MoveBase.U, move.Dir));
				DoMove(new Move(MoveBase.E, (move.Dir == MoveDir.N) ? MoveDir.P : ((move.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N)));
			}
			else if (move.Base == MoveBase.r)
			{
				DoMove(new Move(MoveBase.R, move.Dir));
				DoMove(new Move(MoveBase.M, (move.Dir == MoveDir.N) ? MoveDir.P : ((move.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N)));
			}
			else if (move.Base == MoveBase.f)
			{
				DoMove(new Move(MoveBase.F, move.Dir));
				DoMove(new Move(MoveBase.S, move.Dir));
			}
			else if (move.Base == MoveBase.d)
			{
				DoMove(new Move(MoveBase.D, move.Dir));
				DoMove(new Move(MoveBase.E, move.Dir));
			}
			else if (move.Base == MoveBase.l)
			{
				DoMove(new Move(MoveBase.L, move.Dir));
				DoMove(new Move(MoveBase.M, move.Dir));
			}
			else if (move.Base == MoveBase.b)
			{
				DoMove(new Move(MoveBase.B, move.Dir));
				DoMove(new Move(MoveBase.S, (move.Dir == MoveDir.N) ? MoveDir.P : ((move.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N)));
			}
			else if (move.Base == MoveBase.M)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 1, 0] = array[4, 1, 2];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 1] = array[4, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 1, 2] = array[4, 1, 0];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[5, 1, 0] = array[2, 1, 0];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 1] = array[2, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 1, 2] = array[2, 1, 2];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[2, 1, 0] = array[0, 1, 0];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 1] = array[0, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 1, 2] = array[0, 1, 2];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[4, 1, 0] = array[5, 1, 2];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 1] = array[5, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 1, 2] = array[5, 1, 0];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
					Cubies[0, 1, 0] = array[4, 1, 2];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 1] = array[4, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 1, 2] = array[4, 1, 0];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[5, 1, 0] = array[2, 1, 0];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 1] = array[2, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 1, 2] = array[2, 1, 2];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[2, 1, 0] = array[0, 1, 0];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 1] = array[0, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 1, 2] = array[0, 1, 2];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[4, 1, 0] = array[5, 1, 2];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 1] = array[5, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 1, 2] = array[5, 1, 0];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 1, 0] = array[2, 1, 0];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 1] = array[2, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 1, 2] = array[2, 1, 2];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[5, 1, 0] = array[4, 1, 2];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 1] = array[4, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 1, 2] = array[4, 1, 0];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[2, 1, 0] = array[5, 1, 0];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 1] = array[5, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 1, 2] = array[5, 1, 2];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[4, 1, 0] = array[0, 1, 2];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 1] = array[0, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 1, 2] = array[0, 1, 0];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 1, 0] = array[5, 1, 0];
					Cubies[0, 1, 0].Face = 0;
					Cubies[0, 1, 0].X = 1;
					Cubies[0, 1, 0].Y = 0;
					Cubies[0, 1, 1] = array[5, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 1, 2] = array[5, 1, 2];
					Cubies[0, 1, 2].Face = 0;
					Cubies[0, 1, 2].X = 1;
					Cubies[0, 1, 2].Y = 2;
					Cubies[5, 1, 0] = array[0, 1, 0];
					Cubies[5, 1, 0].Face = 5;
					Cubies[5, 1, 0].X = 1;
					Cubies[5, 1, 0].Y = 0;
					Cubies[5, 1, 1] = array[0, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 1, 2] = array[0, 1, 2];
					Cubies[5, 1, 2].Face = 5;
					Cubies[5, 1, 2].X = 1;
					Cubies[5, 1, 2].Y = 2;
					Cubies[2, 1, 0] = array[4, 1, 2];
					Cubies[2, 1, 0].Face = 2;
					Cubies[2, 1, 0].X = 1;
					Cubies[2, 1, 0].Y = 0;
					Cubies[2, 1, 1] = array[4, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 1, 2] = array[4, 1, 0];
					Cubies[2, 1, 2].Face = 2;
					Cubies[2, 1, 2].X = 1;
					Cubies[2, 1, 2].Y = 2;
					Cubies[4, 1, 0] = array[2, 1, 2];
					Cubies[4, 1, 0].Face = 4;
					Cubies[4, 1, 0].X = 1;
					Cubies[4, 1, 0].Y = 0;
					Cubies[4, 1, 1] = array[2, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 1, 2] = array[2, 1, 0];
					Cubies[4, 1, 2].Face = 4;
					Cubies[4, 1, 2].X = 1;
					Cubies[4, 1, 2].Y = 2;
				}
			}
			else if (move.Base == MoveBase.E)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[2, 0, 1] = array[1, 0, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 1, 1] = array[1, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 2, 1] = array[1, 2, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[4, 0, 1] = array[3, 0, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 1, 1] = array[3, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 2, 1] = array[3, 2, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[1, 0, 1] = array[4, 0, 1];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 1, 1] = array[4, 1, 1];
					Cubies[1, 1, 1].Face = 1;
					Cubies[1, 1, 1].X = 1;
					Cubies[1, 1, 1].Y = 1;
					Cubies[1, 2, 1] = array[4, 2, 1];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[3, 0, 1] = array[2, 0, 1];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 1, 1] = array[2, 1, 1];
					Cubies[3, 1, 1].Face = 3;
					Cubies[3, 1, 1].X = 1;
					Cubies[3, 1, 1].Y = 1;
					Cubies[3, 2, 1] = array[2, 2, 1];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[2, 0, 1] = array[3, 0, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 1, 1] = array[3, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 2, 1] = array[3, 2, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[4, 0, 1] = array[1, 0, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 1, 1] = array[1, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 2, 1] = array[1, 2, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[1, 0, 1] = array[2, 0, 1];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 1, 1] = array[2, 1, 1];
					Cubies[1, 1, 1].Face = 1;
					Cubies[1, 1, 1].X = 1;
					Cubies[1, 1, 1].Y = 1;
					Cubies[1, 2, 1] = array[2, 2, 1];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[3, 0, 1] = array[4, 0, 1];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 1, 1] = array[4, 1, 1];
					Cubies[3, 1, 1].Face = 3;
					Cubies[3, 1, 1].X = 1;
					Cubies[3, 1, 1].Y = 1;
					Cubies[3, 2, 1] = array[4, 2, 1];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[2, 0, 1] = array[4, 0, 1];
					Cubies[2, 0, 1].Face = 2;
					Cubies[2, 0, 1].X = 0;
					Cubies[2, 0, 1].Y = 1;
					Cubies[2, 1, 1] = array[4, 1, 1];
					Cubies[2, 1, 1].Face = 2;
					Cubies[2, 1, 1].X = 1;
					Cubies[2, 1, 1].Y = 1;
					Cubies[2, 2, 1] = array[4, 2, 1];
					Cubies[2, 2, 1].Face = 2;
					Cubies[2, 2, 1].X = 2;
					Cubies[2, 2, 1].Y = 1;
					Cubies[4, 0, 1] = array[2, 0, 1];
					Cubies[4, 0, 1].Face = 4;
					Cubies[4, 0, 1].X = 0;
					Cubies[4, 0, 1].Y = 1;
					Cubies[4, 1, 1] = array[2, 1, 1];
					Cubies[4, 1, 1].Face = 4;
					Cubies[4, 1, 1].X = 1;
					Cubies[4, 1, 1].Y = 1;
					Cubies[4, 2, 1] = array[2, 2, 1];
					Cubies[4, 2, 1].Face = 4;
					Cubies[4, 2, 1].X = 2;
					Cubies[4, 2, 1].Y = 1;
					Cubies[1, 0, 1] = array[3, 0, 1];
					Cubies[1, 0, 1].Face = 1;
					Cubies[1, 0, 1].X = 0;
					Cubies[1, 0, 1].Y = 1;
					Cubies[1, 1, 1] = array[3, 1, 1];
					Cubies[1, 1, 1].Face = 1;
					Cubies[1, 1, 1].X = 1;
					Cubies[1, 1, 1].Y = 1;
					Cubies[1, 2, 1] = array[3, 2, 1];
					Cubies[1, 2, 1].Face = 1;
					Cubies[1, 2, 1].X = 2;
					Cubies[1, 2, 1].Y = 1;
					Cubies[3, 0, 1] = array[1, 0, 1];
					Cubies[3, 0, 1].Face = 3;
					Cubies[3, 0, 1].X = 0;
					Cubies[3, 0, 1].Y = 1;
					Cubies[3, 1, 1] = array[1, 1, 1];
					Cubies[3, 1, 1].Face = 3;
					Cubies[3, 1, 1].X = 1;
					Cubies[3, 1, 1].Y = 1;
					Cubies[3, 2, 1] = array[1, 2, 1];
					Cubies[3, 2, 1].Face = 3;
					Cubies[3, 2, 1].X = 2;
					Cubies[3, 2, 1].Y = 1;
				}
			}
			else if (move.Base == MoveBase.S)
			{
				if (move.Dir == MoveDir.N)
				{
					Cubies[0, 0, 1] = array[1, 1, 2];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 1, 1] = array[1, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 2, 1] = array[1, 1, 0];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[5, 0, 1] = array[3, 1, 2];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 1, 1] = array[3, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 2, 1] = array[3, 1, 0];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[1, 1, 0] = array[5, 0, 1];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 1, 1] = array[5, 1, 1];
					Cubies[1, 1, 1].Face = 1;
					Cubies[1, 1, 1].X = 1;
					Cubies[1, 1, 1].Y = 1;
					Cubies[1, 1, 2] = array[5, 2, 1];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[3, 1, 0] = array[0, 0, 1];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 1, 1] = array[0, 1, 1];
					Cubies[3, 1, 1].Face = 3;
					Cubies[3, 1, 1].X = 1;
					Cubies[3, 1, 1].Y = 1;
					Cubies[3, 1, 2] = array[0, 2, 1];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.P)
				{
					Cubies[0, 0, 1] = array[3, 1, 0];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 1, 1] = array[3, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 2, 1] = array[3, 1, 2];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[5, 0, 1] = array[1, 1, 0];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 1, 1] = array[1, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 2, 1] = array[1, 1, 2];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[1, 1, 0] = array[0, 2, 1];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 1, 1] = array[0, 1, 1];
					Cubies[1, 1, 1].Face = 1;
					Cubies[1, 1, 1].X = 1;
					Cubies[1, 1, 1].Y = 1;
					Cubies[1, 1, 2] = array[0, 0, 1];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[3, 1, 0] = array[5, 2, 1];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 1, 1] = array[5, 1, 1];
					Cubies[3, 1, 1].Face = 3;
					Cubies[3, 1, 1].X = 1;
					Cubies[3, 1, 1].Y = 1;
					Cubies[3, 1, 2] = array[5, 0, 1];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
				}
				else if (move.Dir == MoveDir.D)
				{
					Cubies[0, 0, 1] = array[5, 2, 1];
					Cubies[0, 0, 1].Face = 0;
					Cubies[0, 0, 1].X = 0;
					Cubies[0, 0, 1].Y = 1;
					Cubies[0, 1, 1] = array[5, 1, 1];
					Cubies[0, 1, 1].Face = 0;
					Cubies[0, 1, 1].X = 1;
					Cubies[0, 1, 1].Y = 1;
					Cubies[0, 2, 1] = array[5, 0, 1];
					Cubies[0, 2, 1].Face = 0;
					Cubies[0, 2, 1].X = 2;
					Cubies[0, 2, 1].Y = 1;
					Cubies[5, 0, 1] = array[0, 2, 1];
					Cubies[5, 0, 1].Face = 5;
					Cubies[5, 0, 1].X = 0;
					Cubies[5, 0, 1].Y = 1;
					Cubies[5, 1, 1] = array[0, 1, 1];
					Cubies[5, 1, 1].Face = 5;
					Cubies[5, 1, 1].X = 1;
					Cubies[5, 1, 1].Y = 1;
					Cubies[5, 2, 1] = array[0, 0, 1];
					Cubies[5, 2, 1].Face = 5;
					Cubies[5, 2, 1].X = 2;
					Cubies[5, 2, 1].Y = 1;
					Cubies[1, 1, 0] = array[3, 1, 2];
					Cubies[1, 1, 0].Face = 1;
					Cubies[1, 1, 0].X = 1;
					Cubies[1, 1, 0].Y = 0;
					Cubies[1, 1, 1] = array[3, 1, 1];
					Cubies[1, 1, 1].Face = 1;
					Cubies[1, 1, 1].X = 1;
					Cubies[1, 1, 1].Y = 1;
					Cubies[1, 1, 2] = array[3, 1, 0];
					Cubies[1, 1, 2].Face = 1;
					Cubies[1, 1, 2].X = 1;
					Cubies[1, 1, 2].Y = 2;
					Cubies[3, 1, 0] = array[1, 1, 2];
					Cubies[3, 1, 0].Face = 3;
					Cubies[3, 1, 0].X = 1;
					Cubies[3, 1, 0].Y = 0;
					Cubies[3, 1, 1] = array[1, 1, 1];
					Cubies[3, 1, 1].Face = 3;
					Cubies[3, 1, 1].X = 1;
					Cubies[3, 1, 1].Y = 1;
					Cubies[3, 1, 2] = array[1, 1, 0];
					Cubies[3, 1, 2].Face = 3;
					Cubies[3, 1, 2].X = 1;
					Cubies[3, 1, 2].Y = 2;
				}
			}
			if (move.Base == MoveBase.x)
			{
				DoMove(new Move(MoveBase.r, move.Dir));
				DoMove(new Move(MoveBase.L, (move.Dir == MoveDir.N) ? MoveDir.P : ((move.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N)));
			}
			else if (move.Base == MoveBase.y)
			{
				DoMove(new Move(MoveBase.u, move.Dir));
				DoMove(new Move(MoveBase.D, (move.Dir == MoveDir.N) ? MoveDir.P : ((move.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N)));
			}
			else if (move.Base == MoveBase.z)
			{
				DoMove(new Move(MoveBase.f, move.Dir));
				DoMove(new Move(MoveBase.B, (move.Dir == MoveDir.N) ? MoveDir.P : ((move.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N)));
			}
		}

		public void DoMoves(IEnumerable<Move> moves)
		{
			foreach (Move move in moves)
			{
				DoMove(move);
			}
		}

		public string GetImageURL(bool frontView = true)
		{
			return ("http://software.rubikscube.info/icube/icube.php?fl=" + getFaceImageStr(0, !frontView) + getFaceImageStr((!frontView) ? 1 : 2) + getFaceImageStr(frontView ? 3 : 2)).ToLower();
		}

		public string GetImageURLTopOnly(bool frontView = true)
		{
			string text = string.Concat(Cubies[2, 0, 0].Color, Cubies[2, 1, 0].Color, Cubies[2, 2, 0].Color, "xxxxxx");
			string text2 = string.Concat(Cubies[3, 0, 0].Color, Cubies[3, 1, 0].Color, Cubies[3, 2, 0].Color, "xxxxxx");
			string text3 = string.Concat(Cubies[1, 0, 0].Color, Cubies[1, 1, 0].Color, Cubies[1, 2, 0].Color, "xxxxxx");
			return ("http://software.rubikscube.info/icube/icube.php?fl=" + getFaceImageStr(0, !frontView) + (frontView ? text : text3) + (frontView ? text2 : text)).ToLower();
		}

		private string getFaceImageStr(int side, bool rotated = false)
		{
			string text = "";
			if (!rotated)
			{
				text += Cubies[side, 0, 0].Color;
				text += Cubies[side, 1, 0].Color;
				text += Cubies[side, 2, 0].Color;
				text += Cubies[side, 0, 1].Color;
				text += Cubies[side, 1, 1].Color;
				text += Cubies[side, 2, 1].Color;
				text += Cubies[side, 0, 2].Color;
				text += Cubies[side, 1, 2].Color;
				return text + Cubies[side, 2, 2].Color;
			}
			text += Cubies[side, 2, 0].Color;
			text += Cubies[side, 2, 1].Color;
			text += Cubies[side, 2, 2].Color;
			text += Cubies[side, 1, 0].Color;
			text += Cubies[side, 1, 1].Color;
			text += Cubies[side, 1, 2].Color;
			text += Cubies[side, 0, 0].Color;
			text += Cubies[side, 0, 1].Color;
			return text + Cubies[side, 0, 2].Color;
		}

		public static IEnumerable<Move> ParseAlg(string alg)
		{
			string[] array = alg.Replace("(", "").Replace(")", "").Split(new char[1] { ' ' });
			foreach (string text in array)
			{
				string value = text[0].ToString();
				string text2 = ((text.Length > 1) ? text[1].ToString() : "N");
				if (text2 == "'")
				{
					text2 = "P";
				}
				else if (text2 == "2")
				{
					text2 = "D";
				}
				MoveBase b = (MoveBase)Enum.Parse(typeof(MoveBase), value);
				MoveDir d = (MoveDir)Enum.Parse(typeof(MoveDir), text2);
				yield return new Move(b, d);
			}
		}

		public static IEnumerable<Move> ReverseAlg(IEnumerable<Move> alg)
		{
			foreach (Move item in alg.Reverse())
			{
				yield return new Move(item.Base, (item.Dir == MoveDir.N) ? MoveDir.P : ((item.Dir != MoveDir.P) ? MoveDir.D : MoveDir.N));
			}
		}

		public Cubie GetCubieSource(Cubie cubie)
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						for (int l = 0; l < 6; l++)
						{
							for (int m = 0; m < 3; m++)
							{
								for (int n = 0; n < 3; n++)
								{
									Cubie result = Cubies[l, m, n];
									if (result.SourceFace == i && result.SourceX == j && result.SourceY == k)
									{
										return result;
									}
								}
							}
						}
					}
				}
			}
			throw new Exception("Could not find source cubie.");
		}

		public static string GetScramble()
		{
			MoveBase[] array = new MoveBase[6]
			{
				MoveBase.U,
				MoveBase.D,
				MoveBase.L,
				MoveBase.R,
				MoveBase.F,
				MoveBase.B
			};
			new Dictionary<MoveBase, MoveBase>
			{
				{
					MoveBase.U,
					MoveBase.D
				},
				{
					MoveBase.D,
					MoveBase.U
				},
				{
					MoveBase.L,
					MoveBase.R
				},
				{
					MoveBase.R,
					MoveBase.L
				},
				{
					MoveBase.F,
					MoveBase.B
				},
				{
					MoveBase.B,
					MoveBase.F
				}
			};
			MoveDir[] array2 = new MoveDir[3]
			{
				MoveDir.N,
				MoveDir.P,
				MoveDir.D
			};
			Move[] array3 = new Move[25];
			Random random = new Random();
			for (int i = 0; i < 25; i++)
			{
				MoveBase moveBase;
				MoveDir d;
				bool flag;
				do
				{
					moveBase = array[random.Next(array.Length)];
					d = array2[random.Next(array2.Length)];
					flag = true;
					if (i > 0 && array3[i - 1].Base == moveBase)
					{
						flag = false;
					}
					else if (i > 1 && array3[i - 2].Base == moveBase)
					{
						flag = false;
					}
				}
				while (!flag);
				array3[i] = new Move(moveBase, d);
			}
			return string.Join(" ", array3);
		}

		private Cubie[] allCubies()
		{
			List<Cubie> list = new List<Cubie>();
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						list.Add(Cubies[i, j, k]);
					}
				}
			}
			return list.ToArray();
		}

		public Cubie cubieFromLetter(char letter, bool corner, string letters = null)
		{
			if (letters == null)
			{
				letters = Settings.Letters;
			}
			int num = letters.IndexOf(letter);
			if ((corner && num % 2 == 1) || (!corner && num % 2 == 0))
			{
				num = letters.IndexOf(letter, num + 1);
			}
			int num2 = num / 8;
			int num3 = num % 8;
			int num4 = -1;
			int num5 = -1;
			switch (num3)
			{
			case 0:
			case 6:
			case 7:
				num4 = 0;
				break;
			case 1:
			case 5:
			case 8:
				num4 = 1;
				break;
			default:
				num4 = 2;
				break;
			}
			switch (num3)
			{
			case 0:
			case 1:
			case 2:
				num5 = 0;
				break;
			case 3:
			case 7:
			case 8:
				num5 = 1;
				break;
			default:
				num5 = 2;
				break;
			}
			return Cubies[num2, num4, num5];
		}

		public string GetMemo(Func<char[], char> cycleBreakSelector)
		{
			Dictionary<Cubie, bool> dictionary = new Dictionary<Cubie, bool>();
			Cubie[] array = allCubies();
			for (int i = 0; i < array.Length; i++)
			{
				Cubie key = array[i];
				if (!key.IsCenter && !key.IsSolved())
				{
					dictionary.Add(key, value: false);
				}
			}
			string text = "";
			string text2 = "";
			for (int j = 0; j < 2; j++)
			{
				bool corners = j == 0;
				Cubie cubie = cubieFromLetter(Settings.Letters[(!corners) ? 41 : 0], corners);
				dictionary[cubie] = true;
				array = cubie.GetStickersOnPiece();
				foreach (Cubie key2 in array)
				{
					dictionary[key2] = true;
				}
				Cubie key3 = cubie;
				Cubie cubie2 = cubie;
				bool flag = false;
				Func<KeyValuePair<Cubie, bool>, bool> func = default(Func<KeyValuePair<Cubie, bool>, bool>);
				while (true)
				{
					Cubie cubie3 = Cubies[cubie2.SourceFace, cubie2.SourceX, cubie2.SourceY];
					if ((cubie3.Face == key3.Face && cubie3.X == key3.X && cubie3.Y == key3.Y) || key3.GetStickersOnPiece().Contains(cubie3))
					{
						if (flag)
						{
							if (corners)
							{
								text += cubie3.Letter;
							}
							else
							{
								text2 += cubie3.Letter;
							}
						}
						Func<KeyValuePair<Cubie, bool>, bool> func2 = func;
						if (func2 == null)
						{
							func2 = (func = (KeyValuePair<Cubie, bool> kvp) => (!corners) ? kvp.Key.IsEdgeSticker : kvp.Key.IsCornerSticker);
						}
						char[] array2 = (from kvp in dictionary.Where(func2)
							where !kvp.Value
							where !kvp.Key.IsMisorientedInPlace()
							select kvp.Key.Letter).ToArray();
						if (array2.Length == 0)
						{
							break;
						}
						char letter = cycleBreakSelector(array2);
						key3 = (cubie2 = cubieFromLetter(letter, corners));
						dictionary[key3] = true;
						array = key3.GetStickersOnPiece();
						foreach (Cubie key4 in array)
						{
							dictionary[key4] = true;
						}
						if (corners)
						{
							text += letter;
						}
						else
						{
							text2 += letter;
						}
						flag = true;
					}
					else
					{
						char letter2 = cubie3.Letter;
						if (corners)
						{
							text += letter2;
						}
						else
						{
							text2 += letter2;
						}
						dictionary[cubie3] = true;
						array = cubie3.GetStickersOnPiece();
						foreach (Cubie key5 in array)
						{
							dictionary[key5] = true;
						}
						cubie2 = cubie3;
					}
				}
			}
			List<Cubie[]> list = new List<Cubie[]>();
			foreach (Cubie c2 in from kvp in dictionary
				where !kvp.Value
				select kvp.Key)
			{
				if (!list.Any((Cubie[] piece) => piece.Contains(c2)))
				{
					List<Cubie> list2 = new List<Cubie> { c2 };
					list2.AddRange(c2.GetStickersOnPiece());
					list.Add(list2.ToArray());
				}
			}
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			foreach (Cubie[] item in list)
			{
				char[] array3 = item.Select((Cubie c) => c.Letter).ToArray();
				char first = cycleBreakSelector(array3);
				if (item.Length == 2)
				{
					if (Settings.LetterPairsForFlippedEdges)
					{
						text2 = text2 + first + array3.Where((char l) => l != first).First();
						continue;
					}
					string text3 = (item.Select((Cubie c) => c.Face).Contains(0) ? "U" : (item.Select((Cubie c) => c.Face).Contains(5) ? "D" : ((!item.Select((Cubie c) => c.Face).Contains(2)) ? "B" : "F")));
					text3 = (item.Select((Cubie c) => c.Face).Contains(1) ? (text3 + "L") : (item.Select((Cubie c) => c.Face).Contains(3) ? (text3 + "R") : ((!item.Select((Cubie c) => c.Face).Contains(2)) ? (text3 + "B") : (text3 + "F"))));
					list3.Add("flip " + text3);
					continue;
				}
				if (Settings.LetterPairsForTwistedCorners)
				{
					Cubie cubie4 = item.Where((Cubie c) => c.Letter == first).First();
					Cubie cubie5 = Cubies[cubie4.SourceFace, cubie4.SourceX, cubie4.SourceY];
					text = text + first + cubie5.Letter;
					continue;
				}
				string text4 = (item.Select((Cubie c) => c.Face).Contains(0) ? "U" : "D") + (item.Select((Cubie c) => c.Face).Contains(2) ? "F" : "B") + (item.Select((Cubie c) => c.Face).Contains(1) ? "L" : "R");
				bool flag2 = true;
				Cubie cubie6 = item.Where((Cubie c) => c.Face == 0 || c.Face == 5).First();
				char letter3 = cubie6.Letter;
				int sourceFace = cubie6.SourceFace;
				if (letter3 == Settings.Letters[0])
				{
					flag2 = sourceFace == 1;
				}
				else if (letter3 == Settings.Letters[2])
				{
					flag2 = sourceFace == 4;
				}
				else if (letter3 == Settings.Letters[4])
				{
					flag2 = sourceFace == 3;
				}
				else if (letter3 == Settings.Letters[6])
				{
					flag2 = sourceFace == 2;
				}
				else if (letter3 == Settings.Letters[40])
				{
					flag2 = sourceFace == 1;
				}
				else if (letter3 == Settings.Letters[42])
				{
					flag2 = sourceFace == 2;
				}
				else if (letter3 == Settings.Letters[44])
				{
					flag2 = sourceFace == 3;
				}
				else if (letter3 == Settings.Letters[46])
				{
					flag2 = sourceFace == 4;
				}
				list4.Add("twist " + text4 + " " + (flag2 ? "CW" : "CCW"));
			}
			if (!Settings.LetterPairsForFlippedEdges && list3.Any())
			{
				text2 = text2 + "+" + string.Join(",", list3);
			}
			if (!Settings.LetterPairsForTwistedCorners && list4.Any())
			{
				text = text + "+" + string.Join(",", list4);
			}
			return text2 + "\n" + text;
		}
	}
}
