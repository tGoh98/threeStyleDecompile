using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class CommTester : Tester
	{
		private bool preCountdown = true;

		private bool holdingSpacePreCountdown;

		private bool doingComms;

		public static Dictionary<string, string> Comms;

		public string[] commOrder;

		public int currentComm;

		private Stopwatch commTimer = new Stopwatch();

		public long[] commTimes;

		public bool[] reminded;

		public CommDataForm dataForm;

		public CommTester(TesterForm parent)
			: base(parent)
		{
			Reset();
		}

		public override void Register()
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			((Control)Parent).add_KeyDown(new KeyEventHandler(KeyDown));
			((Control)Parent).add_KeyUp(new KeyEventHandler(KeyUp));
			Parent.countdownTimer.add_Tick((EventHandler)countdownTimer_Tick);
			Reset();
			((ToolStripItem)Parent.newCommTesterButton).set_Text("Reset Comms Tester");
			((ToolStripItem)Parent.newMemoTesterButton).set_Text("Test Memo");
		}

		public override void Unregister()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			Reset();
			((Control)Parent).remove_KeyDown(new KeyEventHandler(KeyDown));
			((Control)Parent).remove_KeyUp(new KeyEventHandler(KeyUp));
			Parent.countdownTimer.remove_Tick((EventHandler)countdownTimer_Tick);
			((Control)Parent.statusLabel).set_Visible(false);
			((Control)Parent.commLabel).set_Visible(false);
			((Control)Parent.countdownLabel).set_Visible(false);
			((Control)Parent.commsFileLabel).set_Visible(false);
			((Control)Parent.loadCommsButton).set_Visible(false);
		}

		public override void Reset()
		{
			Parent.countdownTimer.Stop();
			((Control)Parent.countdownLabel).set_Visible(true);
			((Control)Parent.commLabel).set_Visible(false);
			((Control)Parent.statusLabel).set_Visible(false);
			((Control)Parent.commsFileLabel).set_Visible(true);
			((Control)Parent.loadCommsButton).set_Visible(true);
			preCountdown = true;
			holdingSpacePreCountdown = false;
			doingComms = false;
			currentComm = 0;
			Random r = new Random();
			if (Comms != null)
			{
				((Control)Parent.countdownLabel).set_Text("Ready");
				commOrder = Comms.Keys.OrderBy((string comm) => r.Next()).ToArray();
				commTimes = new long[Comms.Count];
				reminded = new bool[Comms.Count];
			}
			else
			{
				((Control)Parent.countdownLabel).set_Text("\nNot Ready\nLoad Comms\n↙↙");
			}
			((Control)Parent).set_BackColor(Color.Khaki);
			if (dataForm == null || ((Control)dataForm).get_IsDisposed())
			{
				dataForm = new CommDataForm(this);
			}
			dataForm.Reset();
			((Control)dataForm).Show();
			((Control)Parent).BringToFront();
		}

		public override void KeyDown(object sender, KeyEventArgs e)
		{
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Invalid comparison between Unknown and I4
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Invalid comparison between Unknown and I4
			if (commTimer.IsRunning && commTimer.ElapsedMilliseconds > 500)
			{
				commTimes[currentComm] = commTimer.ElapsedMilliseconds;
				reminded[currentComm] = (int)e.get_KeyCode() == 9;
				commTimer.Stop();
				currentComm++;
				if (currentComm < Comms.Count)
				{
					string text = Tester.msToStr(commTimes[currentComm - 1]);
					((Control)Parent.statusLabel).set_Text("Comm: " + currentComm + "/" + Comms.Count + "    Last: " + commOrder[currentComm - 1] + " (" + (reminded[currentComm - 1] ? "failed" : text) + ")    Average: " + getCurrentAverage());
					if (reminded[currentComm - 1])
					{
						((Control)Parent.commLabel).set_Text("Failed " + commOrder[currentComm - 1] + " =\n" + Comms[commOrder[currentComm - 1]]);
					}
					else
					{
						((Control)Parent.commLabel).set_Text("Comm:\n(    )");
					}
					dataForm.updateData();
					((Control)Parent).set_BackColor(reminded[currentComm - 1] ? Color.Red : Color.Lime);
				}
				else
				{
					((Control)Parent.commLabel).set_Text("Finished " + Comms.Count + " comms!");
					string text2 = Tester.msToStr(commTimes.Take(currentComm).Sum() / currentComm);
					Label commLabel = Parent.commLabel;
					((Control)commLabel).set_Text(((Control)commLabel).get_Text() + "\nAverage: " + text2);
					doingComms = false;
					((Control)Parent.statusLabel).set_Visible(false);
				}
			}
			if ((int)e.get_KeyCode() == 32 && preCountdown && Comms != null)
			{
				preCountdown = false;
				holdingSpacePreCountdown = true;
				((Control)Parent).set_BackColor(Color.Lime);
				((Control)Parent.countdownLabel).set_Text("  Starting...");
				((Control)Parent.commsFileLabel).set_Visible(false);
				((Control)Parent.loadCommsButton).set_Visible(false);
			}
			e.set_Handled(true);
		}

		public override void KeyUp(object sender, KeyEventArgs e)
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			if (doingComms && !commTimer.IsRunning)
			{
				((Control)Parent.commLabel).set_Text("Comm:\n" + commOrder[currentComm]);
				commTimer.Restart();
				((Control)Parent).set_BackColor(Color.DeepSkyBlue);
			}
			else if ((int)e.get_KeyCode() == 32 && holdingSpacePreCountdown)
			{
				holdingSpacePreCountdown = false;
				Parent.countdownTimer.Start();
				((Control)Parent.countdownLabel).set_Text("3");
			}
		}

		private void countdownTimer_Tick(object sender, EventArgs e)
		{
			((Control)Parent.countdownLabel).set_Text((int.Parse(((Control)Parent.countdownLabel).get_Text()) - 1).ToString());
			if (((Control)Parent.countdownLabel).get_Text() == "0")
			{
				Parent.countdownTimer.Stop();
				commTimer.Start();
				((Control)Parent.countdownLabel).set_Visible(false);
				((Control)Parent.commLabel).set_Visible(true);
				((Control)Parent.statusLabel).set_Visible(true);
				((Control)Parent.statusLabel).set_Text("Comm: 1/" + Comms.Count + "    Last: N/A    Average: N/A");
				((Control)Parent.commLabel).set_Text("Comm:\n" + commOrder[currentComm]);
				((Control)Parent).set_BackColor(Color.DeepSkyBlue);
				doingComms = true;
			}
		}

		public string getCurrentAverage()
		{
			long num = 0L;
			long num2 = 0L;
			for (int i = 0; i < currentComm; i++)
			{
				if (!reminded[i])
				{
					num += commTimes[i];
					num2++;
				}
			}
			if (num2 == 0L)
			{
				return "N/A";
			}
			return Tester.msToStr(num / num2);
		}
	}
}
