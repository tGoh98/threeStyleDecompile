using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class MemoTester : Tester
	{
		private bool preCountdown = true;

		private bool holdingSpacePreCountdown;

		private bool memoing;

		private int memoIndex;

		private Stopwatch memoTimer = new Stopwatch();

		private bool holdingSpaceDuringMemo;

		private bool executing;

		private bool releasedSpaceDuringExec;

		private long memoMS;

		private string scramble;

		private string[] memos;

		private string memoDisplay;

		public MemoTester(TesterForm parent)
			: base(parent)
		{
		}

		public override void Register()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			Reset();
			((Control)Parent).add_KeyUp(new KeyEventHandler(KeyUp));
			((Control)Parent).add_KeyDown(new KeyEventHandler(KeyDown));
			Parent.countdownTimer.add_Tick((EventHandler)countdownTimer_Tick);
			Parent.memoStatusTimer.add_Tick((EventHandler)memoStatusTimer_Tick);
			Parent.execStatusTimer.add_Tick((EventHandler)execStatusTimer_Tick);
			((ToolStripItem)Parent.newCommTesterButton).set_Text("Test Comms");
			((ToolStripItem)Parent.newMemoTesterButton).set_Text("Reset Memo Tester");
		}

		public override void Unregister()
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			((Control)Parent.cubePanel).set_Visible(false);
			((Control)Parent.memoLabel).set_Visible(false);
			((Control)Parent.countdownLabel).set_Visible(false);
			((Control)Parent.memoStatusLabel).set_Visible(false);
			((Control)Parent.cubeExecTimeLabel).set_Visible(false);
			((Control)Parent.solveResultsTextBox).set_Visible(false);
			((Control)Parent).remove_KeyUp(new KeyEventHandler(KeyUp));
			((Control)Parent).remove_KeyDown(new KeyEventHandler(KeyDown));
			Parent.countdownTimer.remove_Tick((EventHandler)countdownTimer_Tick);
			Parent.memoStatusTimer.remove_Tick((EventHandler)memoStatusTimer_Tick);
			Parent.execStatusTimer.remove_Tick((EventHandler)execStatusTimer_Tick);
		}

		public override void Reset()
		{
			Parent.countdownTimer.Stop();
			Parent.execStatusTimer.Stop();
			Parent.memoStatusTimer.Stop();
			((Control)Parent).set_BackColor(Color.Khaki);
			memoTimer.Reset();
			string text = (scramble = Cube.GetScramble());
			Cube cube = new Cube();
			cube.DoMoves(Cube.ParseAlg(text));
			Parent.cubeDisplay.SetColors(cube);
			Random r = new Random();
			string memo = cube.GetMemo((char[] stickers) => stickers[r.Next(stickers.Length)]);
			calcMemos(memo);
			((Control)Parent.cubePanel).set_Visible(true);
			((Control)Parent.memoLabel).set_Visible(false);
			((Control)Parent.countdownLabel).set_Visible(false);
			((Control)Parent.scrambleLabel).set_Text("Scramble: " + text);
			((Control)Parent.memoLabel).set_Text("Memo:\n" + memo);
			((Control)Parent.memoStatusLabel).set_Visible(false);
			((Control)Parent.cubeExecTimeLabel).set_Visible(false);
			((Control)Parent.solveResultsTextBox).set_Visible(false);
			preCountdown = true;
			holdingSpacePreCountdown = false;
			memoing = false;
			memoIndex = 0;
			executing = false;
			releasedSpaceDuringExec = false;
		}

		public override void KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Invalid comparison between Unknown and I4
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Invalid comparison between Unknown and I4
			if ((int)e.get_KeyCode() == 32 && preCountdown)
			{
				preCountdown = false;
				holdingSpacePreCountdown = true;
				((Control)Parent).set_BackColor(Color.Lime);
				((Control)Parent.countdownLabel).set_Text("  Starting memo...");
				((Control)Parent.countdownLabel).set_Visible(true);
				((Control)Parent.cubePanel).set_Visible(false);
			}
			else if ((int)e.get_KeyCode() == 32 && !preCountdown && !memoing && !executing)
			{
				holdingSpaceDuringMemo = true;
			}
			else if ((int)e.get_KeyCode() == 32 && memoing && !holdingSpaceDuringMemo)
			{
				updateMemoLabel();
			}
			else if (executing && releasedSpaceDuringExec)
			{
				((Control)Parent.cubeExecTimeLabel).set_Text("Total: " + Tester.msToStr(memoMS + memoTimer.ElapsedMilliseconds) + "\nMemo: " + Tester.msToStr(memoMS) + "\nExec: " + Tester.msToStr(memoTimer.ElapsedMilliseconds) + "\n");
				memoTimer.Reset();
				Parent.execStatusTimer.Stop();
				executing = false;
				((Control)Parent.solveResultsTextBox).set_Visible(true);
				((Control)Parent.solveResultsTextBox).set_Text(scramble + "\r\n\r\n" + memoDisplay);
				((Control)Parent.solveResultsTextBox).BringToFront();
			}
			e.set_Handled(true);
		}

		public override void KeyUp(object sender, KeyEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Invalid comparison between Unknown and I4
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Invalid comparison between Unknown and I4
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Invalid comparison between Unknown and I4
			if ((int)e.get_KeyCode() == 32 && holdingSpacePreCountdown)
			{
				holdingSpacePreCountdown = false;
				Parent.countdownTimer.Start();
				((Control)Parent.countdownLabel).set_Text("3");
			}
			else if ((int)e.get_KeyCode() == 32 && !preCountdown && !memoing && !executing)
			{
				holdingSpaceDuringMemo = false;
			}
			else if ((int)e.get_KeyCode() == 32 && holdingSpaceDuringMemo)
			{
				holdingSpaceDuringMemo = false;
			}
			else if ((int)e.get_KeyCode() == 32 && executing)
			{
				releasedSpaceDuringExec = true;
			}
		}

		private void countdownTimer_Tick(object sender, EventArgs e)
		{
			((Control)Parent.countdownLabel).set_Text((int.Parse(((Control)Parent.countdownLabel).get_Text()) - 1).ToString());
			if (((Control)Parent.countdownLabel).get_Text() == "0")
			{
				Parent.countdownTimer.Stop();
				((Control)Parent.countdownLabel).set_Visible(false);
				((Control)Parent).set_BackColor(Color.DeepSkyBlue);
				holdingSpacePreCountdown = false;
				memoing = true;
				memoIndex = 0;
				updateMemoLabel();
				((Control)Parent.memoLabel).set_Visible(true);
				memoTimer.Start();
				((Control)Parent.memoStatusLabel).set_Visible(true);
				((Control)Parent.memoStatusLabel).set_Text("Time: " + Tester.msToStr(0L));
				Parent.memoStatusTimer.Start();
			}
		}

		private void memoStatusTimer_Tick(object sender, EventArgs e)
		{
			((Control)Parent.memoStatusLabel).set_Text("Time: " + Tester.msToStr(memoTimer.ElapsedMilliseconds));
		}

		private void execStatusTimer_Tick(object sender, EventArgs e)
		{
			((Control)Parent.cubeExecTimeLabel).set_Text("Memo: " + Tester.msToStr(memoMS) + "\nExec: " + Tester.msToStr(memoTimer.ElapsedMilliseconds));
		}

		private void updateMemoLabel()
		{
			if (memoIndex == memos.Length)
			{
				memoing = false;
				Parent.memoStatusTimer.Stop();
				memoMS = memoTimer.ElapsedMilliseconds;
				((Control)Parent.memoStatusLabel).set_Visible(false);
				memoTimer.Restart();
				executing = true;
				((Control)Parent.cubeExecTimeLabel).set_Visible(true);
				((Control)Parent.cubeExecTimeLabel).set_Text("Memo: " + Tester.msToStr(memoMS) + "\nExec: " + Tester.msToStr(0L));
				Parent.execStatusTimer.Start();
			}
			else
			{
				((Control)Parent.memoLabel).set_Text(memos[memoIndex++]);
				if (memoIndex == memos.Length)
				{
					((Control)Parent.memoLabel).set_Text("\n" + ((Control)Parent.memoLabel).get_Text() + "\nDone!");
				}
			}
		}

		private void calcMemos(string memo)
		{
			string[] array = memo.Split(new char[1] { '\n' })[0].Split(new char[1] { '+' });
			string[] array2 = memo.Split(new char[1] { '\n' })[1].Split(new char[1] { '+' });
			string[] array3 = (Settings.MemoEdgesFirst ? array : array2);
			string[] array4 = (Settings.MemoEdgesFirst ? array2 : array);
			string text = (Settings.MemoEdgesFirst ? "Edge" : "Corner");
			string text2 = (Settings.MemoEdgesFirst ? "Corner" : "Edge");
			memoDisplay = text + "s: " + Regex.Replace(array3[0], ".{2}", "$0 ");
			if (array3.Length > 1)
			{
				memoDisplay = memoDisplay + " + " + string.Join(", ", array3.Skip(1));
			}
			memoDisplay = memoDisplay + "\r\n" + text2 + "s: " + Regex.Replace(array4[0], ".{2}", "$0 ");
			if (array4.Length > 1)
			{
				memoDisplay = memoDisplay + " + " + string.Join(", ", array4.Skip(1));
			}
			bool flag = array[0].Length % 2 == 1;
			List<string> list = new List<string>();
			for (int i = 0; i < array3[0].Length; i += 2)
			{
				if (!flag || i != array3[0].Length - 1)
				{
					list.Add(text + "s:\n" + array3[0][i] + array3[0][i + 1]);
				}
				else if (Settings.OverlapParityMemo)
				{
					list.Add(text + "+" + text2 + ":\n" + array3[0][i] + "+" + array4[0][0]);
				}
				else
				{
					list.Add(text + ":\n" + array3[0][i]);
					if (array3.Length > 1)
					{
						list.Add(text + "s:\n" + string.Join("\n", array3[1].Split(new char[1] { ',' })));
					}
				}
			}
			if ((!flag || !Settings.OverlapParityMemo) && array3.Length > 1)
			{
				list.Add(text + "s:\n" + string.Join("\n", array3[1].Split(new char[1] { ',' })));
			}
			for (int j = ((flag && Settings.OverlapParityMemo) ? 1 : 0); j < array4[0].Length; j += 2)
			{
				if (!flag || j != array4[0].Length - 1)
				{
					list.Add(text2 + "s:\n" + array4[0][j] + array4[0][j + 1]);
					continue;
				}
				if (Settings.OverlapParityMemo)
				{
					throw new Exception();
				}
				list.Add(text2 + ":\n" + array4[0][j]);
			}
			if (Settings.OverlapParityMemo && array3.Length > 1)
			{
				list.Add(text + "s:\n" + string.Join("\n", array3[1].Split(new char[1] { ',' })));
			}
			if (array4.Length > 1)
			{
				list.Add(text2 + "s:\n" + string.Join("\n", array4[1].Split(new char[1] { ',' })));
			}
			memos = list.ToArray();
		}
	}
}
