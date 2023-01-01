using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ThreeStyleTester
{
	public static class Settings
	{
		private const string FileName = ".settings";

		public static Color[] Colors = new Color[6]
		{
			Color.White,
			Color.Orange,
			Color.Green,
			Color.Red,
			Color.Blue,
			Color.Yellow
		};

		public static string Letters = "AABBCCDDEEFFGGHHIIJJKKLLMMNNOOPPQQRRSSTTUUVVWWXX";

		public static bool LetterPairsForTwistedCorners = false;

		public static bool LetterPairsForFlippedEdges = false;

		public static bool MemoEdgesFirst = true;

		public static bool OverlapParityMemo = true;

		public static string CommsFile = "Comms.txt";

		public static void Load()
		{
			string[] array;
			try
			{
				if (!File.Exists(".settings"))
				{
					Save();
				}
				array = File.ReadAllLines(".settings");
			}
			catch (SettingsException ex)
			{
				throw ex;
			}
			catch (Exception)
			{
				throw new SettingsException("Could not read or write settings file.");
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] array3 = text.Split(new char[1] { '=' });
				if (array3.Length != 2)
				{
					throw new SettingsException("Settings must be key-value pairs separated by '='.");
				}
				switch (array3[0])
				{
				case "colors":
					parseColors(array3[1]);
					break;
				case "letters":
					parseLetters(array3[1]);
					break;
				case "letter-pairs-for-twisted-corners":
					parseLetterPairsForTwistedCorners(array3[1]);
					break;
				case "letter-pairs-for-flipped-edges":
					parseLetterPairsForFlippedEdges(array3[1]);
					break;
				case "memo-edges-first":
					parseMemoEdgesFirst(array3[1]);
					break;
				case "overlap-parity-memo":
					parseOverlapParityMemo(array3[1]);
					break;
				case "comms-file":
					parseCommsFile(text.Substring(text.IndexOf('=') + 1));
					break;
				default:
					throw new SettingsException("Unknown setting '" + array3[0] + "'.");
				}
			}
		}

		public static void Save()
		{
			verifyColors(Colors);
			verifyLetters(Letters);
			try
			{
				File.WriteAllLines(".settings", new string[7]
				{
					"colors=" + string.Join("|", Colors.Select((Color c) => string.Join(", ", c.R, c.G, c.B))),
					"letters=" + Letters,
					"letter-pairs-for-twisted-corners=" + LetterPairsForTwistedCorners,
					"letter-pairs-for-flipped-edges=" + LetterPairsForFlippedEdges,
					"memo-edges-first=" + MemoEdgesFirst,
					"overlap-parity-memo=" + OverlapParityMemo,
					"comms-file=" + CommsFile
				});
			}
			catch (Exception)
			{
				throw new SettingsException("Could not write settings file.");
			}
		}

		private static void parseColors(string input)
		{
			Color[] colors;
			try
			{
				colors = (from part in input.Split(new char[1] { '|' })
					select (from p in part.Split(new char[1] { ',' })
						select int.Parse(p)).ToArray() into parts
					select Color.FromArgb(parts[0], parts[1], parts[2])).ToArray();
			}
			catch (Exception)
			{
				throw new SettingsException("Could not parse colors.");
			}
			verifyColors(colors);
			Colors = colors;
		}

		private static void parseLetters(string input)
		{
			verifyLetters(input);
			Letters = input;
		}

		private static void parseLetterPairsForTwistedCorners(string input)
		{
			if (!bool.TryParse(input, out LetterPairsForTwistedCorners))
			{
				throw new SettingsException("Could not parse letter-pairs-for-twisted-corners.");
			}
		}

		private static void parseLetterPairsForFlippedEdges(string input)
		{
			if (!bool.TryParse(input, out LetterPairsForFlippedEdges))
			{
				throw new SettingsException("Could not parse letter-pairs-for-flipped-edges.");
			}
		}

		private static void parseMemoEdgesFirst(string input)
		{
			if (!bool.TryParse(input, out MemoEdgesFirst))
			{
				throw new SettingsException("Could not parse memo-edges-first.");
			}
		}

		private static void parseOverlapParityMemo(string input)
		{
			if (!bool.TryParse(input, out OverlapParityMemo))
			{
				throw new SettingsException("Could not parse overlap-parity-memo.");
			}
		}

		private static void parseCommsFile(string input)
		{
			if (!input.EndsWith(".txt"))
			{
				throw new SettingsException("Invalid comms file '" + input + "'. (Must be *.txt)");
			}
			CommsFile = input;
		}

		private static void verifyLetters(string letters)
		{
			if (letters.Length != 48)
			{
				throw new SettingsException("There must be 48 letters.");
			}
			if ((from i in Enumerable.Range(0, 24)
				select letters[2 * i]).Distinct().Count() != 24)
			{
				throw new SettingsException("The corner letters must be distinct.");
			}
			if ((from i in Enumerable.Range(0, 24)
				select letters[2 * i + 1]).Distinct().Count() != 24)
			{
				throw new SettingsException("The edge letters must be distinct.");
			}
		}

		private static void verifyColors(Color[] colors)
		{
			if (colors.Length != 6)
			{
				throw new SettingsException("There must be 6 center colors.");
			}
		}
	}
}
