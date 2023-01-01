using System;
using System.Linq;

namespace ThreeStyleTester
{
	public struct Cubie
	{
		public Cube parent;

		public CColor Color;

		public int Face;

		public int X;

		public int Y;

		public int SourceFace;

		public int SourceX;

		public int SourceY;

		public bool IsCenter
		{
			get
			{
				if (X == 1)
				{
					return Y == 1;
				}
				return false;
			}
		}

		public char Letter => Settings.Letters[GetLetterIndex()];

		public bool IsEdgeSticker => (X == 1) ^ (Y == 1);

		public bool IsCornerSticker
		{
			get
			{
				if (X == 0 || X == 2)
				{
					if (Y != 0)
					{
						return Y == 2;
					}
					return true;
				}
				return false;
			}
		}

		public Cubie(Cube parent, CColor color, int face, int x, int y, Cubie source)
			: this(parent, color, face, x, y)
		{
			SourceFace = source.Face;
			SourceX = source.X;
			SourceY = source.Y;
		}

		public Cubie(Cube parent, CColor color, int face, int x, int y)
		{
			this = default(Cubie);
			this.parent = parent;
			Color = color;
			Face = face;
			X = x;
			Y = y;
			SourceFace = (SourceX = (SourceY = -1));
		}

		public int GetLetterIndex()
		{
			if (IsCenter)
			{
				throw new Exception("Cannot get letter for a center.");
			}
			int num = -1;
			if (Y == 0)
			{
				num = X;
			}
			else if (Y == 2)
			{
				num = 6 - X;
			}
			else if (Y == 1)
			{
				num = ((X == 0) ? 7 : 3);
			}
			return 8 * Face + num;
		}

		public bool IsSolved()
		{
			if (Face == SourceFace && X == SourceX)
			{
				return Y == SourceY;
			}
			return false;
		}

		public bool IsMisorientedInPlace()
		{
			if (IsSolved())
			{
				return false;
			}
			Cubie[] stickersOnPiece = parent.Cubies[SourceFace, SourceX, SourceY].GetStickersOnPiece();
			for (int i = 0; i < stickersOnPiece.Length; i++)
			{
				Cubie cubie = stickersOnPiece[i];
				if (Face == cubie.Face && X == cubie.X && Y == cubie.Y)
				{
					return true;
				}
			}
			return false;
		}

		public Cubie[] GetStickersOnPiece()
		{
			string text = "AABBCCDDEEFFGGHHIIJJKKLLMMNNOOPPQQRRSSTTUUVVWWXX";
			char c = text[GetLetterIndex()];
			string text2 = "";
			if (IsCornerSticker)
			{
				switch (c)
				{
				case 'A':
					text2 = "ER";
					break;
				case 'B':
					text2 = "NQ";
					break;
				case 'C':
					text2 = "JM";
					break;
				case 'D':
					text2 = "FI";
					break;
				case 'E':
					text2 = "AR";
					break;
				case 'F':
					text2 = "DI";
					break;
				case 'G':
					text2 = "LU";
					break;
				case 'H':
					text2 = "SX";
					break;
				case 'I':
					text2 = "DF";
					break;
				case 'J':
					text2 = "CM";
					break;
				case 'K':
					text2 = "PV";
					break;
				case 'L':
					text2 = "GU";
					break;
				case 'M':
					text2 = "CJ";
					break;
				case 'N':
					text2 = "BQ";
					break;
				case 'O':
					text2 = "TW";
					break;
				case 'P':
					text2 = "KV";
					break;
				case 'Q':
					text2 = "BN";
					break;
				case 'R':
					text2 = "AE";
					break;
				case 'S':
					text2 = "HX";
					break;
				case 'T':
					text2 = "OW";
					break;
				case 'U':
					text2 = "GL";
					break;
				case 'V':
					text2 = "KP";
					break;
				case 'W':
					text2 = "OT";
					break;
				case 'X':
					text2 = "HS";
					break;
				}
			}
			else
			{
				switch (c)
				{
				case 'A':
					text2 = "Q";
					break;
				case 'B':
					text2 = "M";
					break;
				case 'C':
					text2 = "I";
					break;
				case 'D':
					text2 = "E";
					break;
				case 'E':
					text2 = "D";
					break;
				case 'F':
					text2 = "L";
					break;
				case 'G':
					text2 = "X";
					break;
				case 'H':
					text2 = "R";
					break;
				case 'I':
					text2 = "C";
					break;
				case 'J':
					text2 = "P";
					break;
				case 'K':
					text2 = "U";
					break;
				case 'L':
					text2 = "F";
					break;
				case 'M':
					text2 = "B";
					break;
				case 'N':
					text2 = "T";
					break;
				case 'O':
					text2 = "V";
					break;
				case 'P':
					text2 = "J";
					break;
				case 'Q':
					text2 = "A";
					break;
				case 'R':
					text2 = "H";
					break;
				case 'S':
					text2 = "W";
					break;
				case 'T':
					text2 = "N";
					break;
				case 'U':
					text2 = "K";
					break;
				case 'V':
					text2 = "O";
					break;
				case 'W':
					text2 = "S";
					break;
				case 'X':
					text2 = "G";
					break;
				}
			}
			int[] array = new int[text2.Length];
			for (int j = 0; j < array.Length; j++)
			{
				char value = text2[j];
				int num = text.IndexOf(value);
				if ((IsCornerSticker && num % 2 == 1) || (!IsCornerSticker && num % 2 == 0))
				{
					num = text.IndexOf(value, num + 1);
				}
				array[j] = num;
			}
			Cube parent = this.parent;
			bool isCorner = IsCornerSticker;
			return array.Select((int i) => parent.cubieFromLetter(Settings.Letters[i], isCorner)).ToArray();
		}
	}
}
