using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class TesterForm : Form
	{
		public Tester commTester;

		public Tester memoTester;

		public Tester activeTester;

		public SettingsForm settingsForm;

		private IContainer components;

		private MenuStrip menuStrip;

		private ToolStripMenuItem settingsToolStripMenuItem;

		public Label countdownLabel;

		public Label commLabel;

		public Timer countdownTimer;

		public Label statusLabel;

		public CubeDisplayControl cubeDisplay;

		private Label label1;

		public Label scrambleLabel;

		public Label memoLabel;

		public FlowLayoutPanel cubePanel;

		public Label memoStatusLabel;

		public Timer memoStatusTimer;

		public ToolStripMenuItem newCommTesterButton;

		public ToolStripMenuItem newMemoTesterButton;

		public Label cubeExecTimeLabel;

		public Timer execStatusTimer;

		public TextBox solveResultsTextBox;

		public Label commsFileLabel;

		private OpenFileDialog commsFileDialog;

		public Button loadCommsButton;

		public TesterForm()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			InitializeComponent();
			try
			{
				Settings.Load();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load settings due to error. Using default settings.\n\n" + ex.ToString());
			}
			settingsForm = new SettingsForm();
			commTester = new CommTester(this);
			memoTester = new MemoTester(this);
			memoTester.Enabled = false;
			memoTester.Unregister();
			commTester.Enabled = true;
			commTester.Register();
			activeTester = commTester;
		}

		private void switchToTester(Tester tester)
		{
			if (tester == activeTester)
			{
				activeTester.Reset();
				return;
			}
			activeTester.Unregister();
			activeTester.Enabled = false;
			tester.Register();
			tester.Enabled = true;
			tester.Reset();
			activeTester = tester;
		}

		private void newCommTesterButton_Click(object sender, EventArgs e)
		{
			switchToTester(commTester);
		}

		private void newMemoTesterButton_Click(object sender, EventArgs e)
		{
			switchToTester(memoTester);
		}

		private void loadCommsFile(string file)
		{
			string[] source = File.ReadAllLines(file);
			source = (from l in source
				select l.Trim() into l
				where l.Length > 0
				where !l.StartsWith("#")
				select l).ToArray();
			string[] array = source;
			foreach (string text in array)
			{
				if (!Enumerable.Contains(text, '='))
				{
					throw new Exception("Invalid line '" + text + "'. Lines must be key-value pairs separated by '='.");
				}
			}
			CommTester.Comms = source.ToDictionary((string l) => l.Split(new char[1] { '=' })[0].Trim(), (string l) => l.Split(new char[1] { '=' })[1].Trim());
		}

		private void TesterForm_Load(object sender, EventArgs e)
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			((Control)loadCommsButton).add_GotFocus((EventHandler)delegate
			{
				((Control)this).Focus();
			});
			((Control)commsFileLabel).set_Text(Path.GetFileName(Settings.CommsFile));
			try
			{
				loadCommsFile(Settings.CommsFile);
				commTester.Reset();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not read " + Settings.CommsFile + " due to error:\n" + ex.ToString());
				Settings.CommsFile = "";
				((Control)commsFileLabel).set_Text("");
				commTester.Reset();
			}
			((FileDialog)commsFileDialog).set_InitialDirectory(Environment.CurrentDirectory);
		}

		private void loadCommsButton_Click(object sender, EventArgs e)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			if ((int)((CommonDialog)commsFileDialog).ShowDialog() != 1)
			{
				return;
			}
			try
			{
				loadCommsFile(((FileDialog)commsFileDialog).get_FileName());
				Settings.CommsFile = ((FileDialog)commsFileDialog).get_FileName();
				((Control)commsFileLabel).set_Text(commsFileDialog.get_SafeFileName());
				if (((Control)countdownLabel).get_Text() == "Not Ready\nLoad Comms")
				{
					((Control)countdownLabel).set_Text("Ready");
				}
				commTester.Reset();
				try
				{
					Settings.Save();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not save settings due to error:\n" + ex.ToString());
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show("Could not read " + Settings.CommsFile + " due to error:\n" + ex2.ToString());
				Environment.Exit(1);
			}
		}

		private void loadCommsButton_KeyDown(object sender, KeyEventArgs e)
		{
			e.set_Handled(true);
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (((Control)settingsForm).get_IsDisposed())
			{
				settingsForm = new SettingsForm();
			}
			((Control)settingsForm).Show();
			((Control)settingsForm).BringToFront();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0b12: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b1c: Expected O, but got Unknown
			components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TesterForm));
			commLabel = new Label();
			countdownLabel = new Label();
			countdownTimer = new Timer(components);
			statusLabel = new Label();
			menuStrip = new MenuStrip();
			newCommTesterButton = new ToolStripMenuItem();
			newMemoTesterButton = new ToolStripMenuItem();
			settingsToolStripMenuItem = new ToolStripMenuItem();
			scrambleLabel = new Label();
			label1 = new Label();
			memoLabel = new Label();
			cubePanel = new FlowLayoutPanel();
			cubeDisplay = new CubeDisplayControl();
			memoStatusLabel = new Label();
			memoStatusTimer = new Timer(components);
			cubeExecTimeLabel = new Label();
			execStatusTimer = new Timer(components);
			solveResultsTextBox = new TextBox();
			commsFileLabel = new Label();
			loadCommsButton = new Button();
			commsFileDialog = new OpenFileDialog();
			((Control)menuStrip).SuspendLayout();
			((Control)cubePanel).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)commLabel).set_Anchor((AnchorStyles)15);
			((Control)commLabel).set_BackColor(Color.Transparent);
			((Control)commLabel).set_Font(new Font("Microsoft YaHei UI", 48f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)commLabel).set_Location(new Point(12, 24));
			((Control)commLabel).set_Name("commLabel");
			((Control)commLabel).set_Size(new Size(801, 467));
			((Control)commLabel).set_TabIndex(1);
			((Control)commLabel).set_Text("Comm:\r\nVF");
			commLabel.set_TextAlign(ContentAlignment.MiddleCenter);
			((Control)countdownLabel).set_Anchor((AnchorStyles)15);
			((Control)countdownLabel).set_BackColor(Color.Transparent);
			((Control)countdownLabel).set_Font(new Font("Microsoft YaHei UI", 48f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)countdownLabel).set_Location(new Point(12, 24));
			((Control)countdownLabel).set_Name("countdownLabel");
			((Control)countdownLabel).set_Size(new Size(801, 467));
			((Control)countdownLabel).set_TabIndex(2);
			((Control)countdownLabel).set_Text("Ready");
			countdownLabel.set_TextAlign(ContentAlignment.MiddleCenter);
			countdownTimer.set_Interval(1000);
			((Control)statusLabel).set_AutoSize(true);
			((Control)statusLabel).set_Dock((DockStyle)2);
			((Control)statusLabel).set_Font(new Font("Microsoft YaHei UI", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)statusLabel).set_Location(new Point(0, 476));
			((Control)statusLabel).set_Name("statusLabel");
			((Control)statusLabel).set_Size(new Size(129, 24));
			((Control)statusLabel).set_TabIndex(5);
			((Control)statusLabel).set_Text("Comm 8/108");
			((Control)statusLabel).set_Visible(false);
			((ToolStrip)menuStrip).set_BackColor(SystemColors.Control);
			((ToolStrip)menuStrip).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[3]
			{
				(ToolStripItem)newCommTesterButton,
				(ToolStripItem)newMemoTesterButton,
				(ToolStripItem)settingsToolStripMenuItem
			});
			((Control)menuStrip).set_Location(new Point(0, 0));
			((Control)menuStrip).set_Name("menuStrip");
			((Control)menuStrip).set_Size(new Size(825, 24));
			((Control)menuStrip).set_TabIndex(7);
			((Control)menuStrip).set_Text("menuStrip2");
			((ToolStripItem)newCommTesterButton).set_Name("newCommTesterButton");
			((ToolStripItem)newCommTesterButton).set_Size(new Size(86, 20));
			((ToolStripItem)newCommTesterButton).set_Text("Test Comms");
			((ToolStripItem)newCommTesterButton).add_Click((EventHandler)newCommTesterButton_Click);
			((ToolStripItem)newMemoTesterButton).set_Name("newMemoTesterButton");
			((ToolStripItem)newMemoTesterButton).set_Size(new Size(79, 20));
			((ToolStripItem)newMemoTesterButton).set_Text("Test Memo");
			((ToolStripItem)newMemoTesterButton).add_Click((EventHandler)newMemoTesterButton_Click);
			((ToolStripItem)settingsToolStripMenuItem).set_Name("settingsToolStripMenuItem");
			((ToolStripItem)settingsToolStripMenuItem).set_Size(new Size(61, 20));
			((ToolStripItem)settingsToolStripMenuItem).set_Text("Settings");
			((ToolStripItem)settingsToolStripMenuItem).add_Click((EventHandler)settingsToolStripMenuItem_Click);
			((Control)scrambleLabel).set_AutoSize(true);
			((Control)scrambleLabel).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)scrambleLabel).set_Location(new Point(3, 315));
			((Control)scrambleLabel).set_Name("scrambleLabel");
			((Control)scrambleLabel).set_Size(new Size(97, 19));
			((Control)scrambleLabel).set_TabIndex(9);
			((Control)scrambleLabel).set_Text("Scramble: ...");
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)label1).set_Location(new Point(3, 296));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(156, 19));
			((Control)label1).set_TabIndex(10);
			((Control)label1).set_Text("Scramble and verify.");
			((Control)memoLabel).set_BackColor(Color.Transparent);
			((Control)memoLabel).set_Dock((DockStyle)5);
			((Control)memoLabel).set_Font(new Font("Microsoft YaHei UI", 48f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)memoLabel).set_Location(new Point(0, 0));
			((Control)memoLabel).set_Name("memoLabel");
			((Control)memoLabel).set_Size(new Size(825, 500));
			((Control)memoLabel).set_TabIndex(11);
			((Control)memoLabel).set_Text("Memo:\r\nED GE ME MO + flip UR\r\nCO RN ER ME MO + twist UFR CCW");
			memoLabel.set_TextAlign(ContentAlignment.MiddleCenter);
			((Control)memoLabel).set_Visible(false);
			((Control)cubePanel).get_Controls().Add((Control)(object)cubeDisplay);
			((Control)cubePanel).get_Controls().Add((Control)(object)label1);
			((Control)cubePanel).get_Controls().Add((Control)(object)scrambleLabel);
			((Control)cubePanel).set_Dock((DockStyle)5);
			cubePanel.set_FlowDirection((FlowDirection)1);
			((Control)cubePanel).set_Location(new Point(0, 24));
			((Control)cubePanel).set_Name("cubePanel");
			((Control)cubePanel).set_Size(new Size(825, 452));
			((Control)cubePanel).set_TabIndex(12);
			cubePanel.set_WrapContents(false);
			((UserControl)cubeDisplay).set_BorderStyle((BorderStyle)2);
			((Control)cubeDisplay).set_Location(new Point(3, 3));
			((Control)cubeDisplay).set_MaximumSize(new Size(380, 290));
			((Control)cubeDisplay).set_MinimumSize(new Size(380, 290));
			((Control)cubeDisplay).set_Name("cubeDisplay");
			((Control)cubeDisplay).set_Size(new Size(380, 290));
			((Control)cubeDisplay).set_TabIndex(8);
			((Control)cubeDisplay).set_TabStop(false);
			((Control)memoStatusLabel).set_Anchor((AnchorStyles)6);
			((Control)memoStatusLabel).set_AutoSize(true);
			((Control)memoStatusLabel).set_Font(new Font("Microsoft YaHei UI", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)memoStatusLabel).set_Location(new Point(3, 476));
			((Control)memoStatusLabel).set_Name("memoStatusLabel");
			((Control)memoStatusLabel).set_Size(new Size(102, 24));
			((Control)memoStatusLabel).set_TabIndex(13);
			((Control)memoStatusLabel).set_Text("Time: 0.3s");
			((Control)memoStatusLabel).set_Visible(false);
			memoStatusTimer.set_Interval(5);
			((Control)cubeExecTimeLabel).set_Anchor((AnchorStyles)15);
			((Control)cubeExecTimeLabel).set_BackColor(Color.Transparent);
			((Control)cubeExecTimeLabel).set_Font(new Font("Microsoft YaHei UI", 48f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)cubeExecTimeLabel).set_Location(new Point(12, 24));
			((Control)cubeExecTimeLabel).set_Name("cubeExecTimeLabel");
			((Control)cubeExecTimeLabel).set_Size(new Size(801, 460));
			((Control)cubeExecTimeLabel).set_TabIndex(14);
			((Control)cubeExecTimeLabel).set_Text("Memo: 23.09\r\nExec: 34.03");
			cubeExecTimeLabel.set_TextAlign(ContentAlignment.MiddleCenter);
			((Control)cubeExecTimeLabel).set_Visible(false);
			execStatusTimer.set_Interval(5);
			((Control)solveResultsTextBox).set_Anchor((AnchorStyles)14);
			((Control)solveResultsTextBox).set_BackColor(Color.Beige);
			((TextBoxBase)solveResultsTextBox).set_BorderStyle((BorderStyle)1);
			((Control)solveResultsTextBox).set_Font(new Font("Microsoft YaHei UI", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)solveResultsTextBox).set_Location(new Point(205, 343));
			((TextBoxBase)solveResultsTextBox).set_Multiline(true);
			((Control)solveResultsTextBox).set_Name("solveResultsTextBox");
			((TextBoxBase)solveResultsTextBox).set_ReadOnly(true);
			solveResultsTextBox.set_ScrollBars((ScrollBars)2);
			((Control)solveResultsTextBox).set_Size(new Size(437, 126));
			((Control)solveResultsTextBox).set_TabIndex(11);
			((Control)solveResultsTextBox).set_TabStop(false);
			((Control)solveResultsTextBox).set_Text("Edges: FW VC TJ MA DM  + flip DL\r\nCorners: JB TC VD PL HL ");
			solveResultsTextBox.set_TextAlign((HorizontalAlignment)2);
			((Control)solveResultsTextBox).set_Visible(false);
			((Control)commsFileLabel).set_Anchor((AnchorStyles)6);
			((Control)commsFileLabel).set_AutoSize(true);
			((Control)commsFileLabel).set_Font(new Font("Microsoft YaHei UI", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)commsFileLabel).set_Location(new Point(144, 464));
			((Control)commsFileLabel).set_Name("commsFileLabel");
			((Control)commsFileLabel).set_Size(new Size(109, 24));
			((Control)commsFileLabel).set_TabIndex(15);
			((Control)commsFileLabel).set_Text("Comms.txt");
			((Control)loadCommsButton).set_Anchor((AnchorStyles)6);
			((Control)loadCommsButton).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)loadCommsButton).set_Location(new Point(7, 461));
			((Control)loadCommsButton).set_Name("loadCommsButton");
			((Control)loadCommsButton).set_Size(new Size(131, 30));
			((Control)loadCommsButton).set_TabIndex(16);
			((Control)loadCommsButton).set_Text("Load Comms");
			((ButtonBase)loadCommsButton).set_UseVisualStyleBackColor(true);
			((Control)loadCommsButton).add_Click((EventHandler)loadCommsButton_Click);
			((Control)loadCommsButton).add_KeyDown(new KeyEventHandler(loadCommsButton_KeyDown));
			((FileDialog)commsFileDialog).set_DefaultExt("Comm Files|*.txt");
			((FileDialog)commsFileDialog).set_FileName("Comms.txt");
			((FileDialog)commsFileDialog).set_Filter("Comm Files|*.txt");
			((FileDialog)commsFileDialog).set_Title("Select a Comms File");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Control)this).set_BackColor(Color.Khaki);
			((Form)this).set_ClientSize(new Size(825, 500));
			((Control)this).get_Controls().Add((Control)(object)commsFileLabel);
			((Control)this).get_Controls().Add((Control)(object)loadCommsButton);
			((Control)this).get_Controls().Add((Control)(object)solveResultsTextBox);
			((Control)this).get_Controls().Add((Control)(object)cubeExecTimeLabel);
			((Control)this).get_Controls().Add((Control)(object)cubePanel);
			((Control)this).get_Controls().Add((Control)(object)memoStatusLabel);
			((Control)this).get_Controls().Add((Control)(object)statusLabel);
			((Control)this).get_Controls().Add((Control)(object)countdownLabel);
			((Control)this).get_Controls().Add((Control)(object)commLabel);
			((Control)this).get_Controls().Add((Control)(object)menuStrip);
			((Control)this).get_Controls().Add((Control)(object)memoLabel);
			((Form)this).set_Icon((Icon)componentResourceManager.GetObject("$this.Icon"));
			((Form)this).set_KeyPreview(true);
			((Control)this).set_MinimumSize(new Size(841, 538));
			((Control)this).set_Name("TesterForm");
			((Control)this).set_Text("3Style Tester");
			((Form)this).add_Load((EventHandler)TesterForm_Load);
			((Control)menuStrip).ResumeLayout(false);
			((Control)menuStrip).PerformLayout();
			((Control)cubePanel).ResumeLayout(false);
			((Control)cubePanel).PerformLayout();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
