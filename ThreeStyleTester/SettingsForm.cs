using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class SettingsForm : Form
	{
		private IContainer components;

		private CubeSettingsControl cubeSettingsControl1;

		private CheckBox edgeLetterPairsCheckBox;

		private CheckBox memoEdgesFirstCheckBox;

		private CheckBox overlapParityMemoCheckBox;

		private CheckBox cornerLetterPairsCheckBox;

		public SettingsForm()
		{
			InitializeComponent();
			edgeLetterPairsCheckBox.set_Checked(Settings.LetterPairsForFlippedEdges);
			cornerLetterPairsCheckBox.set_Checked(Settings.LetterPairsForTwistedCorners);
			memoEdgesFirstCheckBox.set_Checked(Settings.MemoEdgesFirst);
			overlapParityMemoCheckBox.set_Checked(Settings.OverlapParityMemo);
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			((Form)this).set_ClientSize(new Size(((Control)cubeSettingsControl1).get_Width(), ((Form)this).get_ClientSize().Height));
			((Control)cubeSettingsControl1).Select();
			((Control)cubeSettingsControl1).Focus();
		}

		private void cornerLetterPairsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			Settings.LetterPairsForTwistedCorners = cornerLetterPairsCheckBox.get_Checked();
			try
			{
				Settings.Save();
			}
			catch (SettingsException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void edgeLetterPairsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			Settings.LetterPairsForFlippedEdges = edgeLetterPairsCheckBox.get_Checked();
			try
			{
				Settings.Save();
			}
			catch (SettingsException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void memoEdgesFirstCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			Settings.MemoEdgesFirst = memoEdgesFirstCheckBox.get_Checked();
			try
			{
				Settings.Save();
			}
			catch (SettingsException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void overlapParityMemoCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			Settings.OverlapParityMemo = overlapParityMemoCheckBox.get_Checked();
			try
			{
				Settings.Save();
			}
			catch (SettingsException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
		{
			cubeSettingsControl1.CubeSettingsControl_KeyDown(sender, e);
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
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0477: Expected O, but got Unknown
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SettingsForm));
			edgeLetterPairsCheckBox = new CheckBox();
			memoEdgesFirstCheckBox = new CheckBox();
			overlapParityMemoCheckBox = new CheckBox();
			cornerLetterPairsCheckBox = new CheckBox();
			cubeSettingsControl1 = new CubeSettingsControl();
			((Control)this).SuspendLayout();
			((Control)edgeLetterPairsCheckBox).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)edgeLetterPairsCheckBox).set_Location(new Point(12, 329));
			((Control)edgeLetterPairsCheckBox).set_Name("edgeLetterPairsCheckBox");
			((Control)edgeLetterPairsCheckBox).set_Size(new Size(226, 49));
			((Control)edgeLetterPairsCheckBox).set_TabIndex(1);
			((Control)edgeLetterPairsCheckBox).set_Text("Use Letter Pairs Instead of Visual for Flipped Edges");
			((ButtonBase)edgeLetterPairsCheckBox).set_UseVisualStyleBackColor(true);
			edgeLetterPairsCheckBox.add_CheckedChanged((EventHandler)edgeLetterPairsCheckBox_CheckedChanged);
			((Control)memoEdgesFirstCheckBox).set_AutoSize(true);
			memoEdgesFirstCheckBox.set_Checked(true);
			memoEdgesFirstCheckBox.set_CheckState((CheckState)1);
			((Control)memoEdgesFirstCheckBox).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)memoEdgesFirstCheckBox).set_Location(new Point(12, 428));
			((Control)memoEdgesFirstCheckBox).set_Name("memoEdgesFirstCheckBox");
			((Control)memoEdgesFirstCheckBox).set_Size(new Size(159, 23));
			((Control)memoEdgesFirstCheckBox).set_TabIndex(2);
			((Control)memoEdgesFirstCheckBox).set_Text("Memo Edges First");
			((ButtonBase)memoEdgesFirstCheckBox).set_UseVisualStyleBackColor(true);
			memoEdgesFirstCheckBox.add_CheckedChanged((EventHandler)memoEdgesFirstCheckBox_CheckedChanged);
			((Control)overlapParityMemoCheckBox).set_AutoSize(true);
			overlapParityMemoCheckBox.set_Checked(true);
			overlapParityMemoCheckBox.set_CheckState((CheckState)1);
			((Control)overlapParityMemoCheckBox).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)overlapParityMemoCheckBox).set_Location(new Point(12, 457));
			((Control)overlapParityMemoCheckBox).set_Name("overlapParityMemoCheckBox");
			((Control)overlapParityMemoCheckBox).set_Size(new Size(182, 23));
			((Control)overlapParityMemoCheckBox).set_TabIndex(3);
			((Control)overlapParityMemoCheckBox).set_Text("Overlap Parity Memo");
			((ButtonBase)overlapParityMemoCheckBox).set_UseVisualStyleBackColor(true);
			overlapParityMemoCheckBox.add_CheckedChanged((EventHandler)overlapParityMemoCheckBox_CheckedChanged);
			((Control)cornerLetterPairsCheckBox).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)cornerLetterPairsCheckBox).set_Location(new Point(12, 373));
			((Control)cornerLetterPairsCheckBox).set_Name("cornerLetterPairsCheckBox");
			((Control)cornerLetterPairsCheckBox).set_Size(new Size(226, 49));
			((Control)cornerLetterPairsCheckBox).set_TabIndex(4);
			((Control)cornerLetterPairsCheckBox).set_Text("Use Letter Pairs Instead of Visual for Twisted Corners");
			((ButtonBase)cornerLetterPairsCheckBox).set_UseVisualStyleBackColor(true);
			cornerLetterPairsCheckBox.add_CheckedChanged((EventHandler)cornerLetterPairsCheckBox_CheckedChanged);
			((UserControl)cubeSettingsControl1).set_BorderStyle((BorderStyle)2);
			((Control)cubeSettingsControl1).set_Location(new Point(0, 0));
			((Control)cubeSettingsControl1).set_MaximumSize(new Size(380, 323));
			((Control)cubeSettingsControl1).set_MinimumSize(new Size(380, 323));
			((Control)cubeSettingsControl1).set_Name("cubeSettingsControl1");
			((Control)cubeSettingsControl1).set_Size(new Size(380, 323));
			((Control)cubeSettingsControl1).set_TabIndex(0);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(500, 487));
			((Control)this).get_Controls().Add((Control)(object)cornerLetterPairsCheckBox);
			((Control)this).get_Controls().Add((Control)(object)overlapParityMemoCheckBox);
			((Control)this).get_Controls().Add((Control)(object)memoEdgesFirstCheckBox);
			((Control)this).get_Controls().Add((Control)(object)edgeLetterPairsCheckBox);
			((Control)this).get_Controls().Add((Control)(object)cubeSettingsControl1);
			((Form)this).set_FormBorderStyle((FormBorderStyle)1);
			((Form)this).set_Icon((Icon)componentResourceManager.GetObject("$this.Icon"));
			((Form)this).set_KeyPreview(true);
			((Form)this).set_MaximizeBox(false);
			((Control)this).set_Name("SettingsForm");
			((Form)this).set_SizeGripStyle((SizeGripStyle)2);
			((Control)this).set_Text("Settings");
			((Form)this).add_Load((EventHandler)SettingsForm_Load);
			((Control)this).add_KeyDown(new KeyEventHandler(SettingsForm_KeyDown));
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
