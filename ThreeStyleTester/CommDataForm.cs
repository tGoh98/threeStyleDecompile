using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ThreeStyleTester
{
	public class CommDataForm : Form
	{
		private CommTester parent;

		private Point? prevPosition;

		private ToolTip tooltip = new ToolTip();

		private IContainer components;

		private SplitContainer splitContainer1;

		public Chart chart;

		private FlowLayoutPanel flowPanel;

		private TextBox missedCommsTextBox;

		private TextBox longCommsTextBox;

		private TextBox allCommsTextBox;

		private Panel panel1;

		private LinkLabel exportMissedCommsLink;

		private Label label4;

		private Panel panel2;

		private LinkLabel exportLongCommsLink;

		private Label label1;

		private Panel panel3;

		private LinkLabel exportAllCommsLink;

		private Label label2;

		private SaveFileDialog saveTSVDialog;

		public CommDataForm(CommTester parent)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			this.parent = parent;
			InitializeComponent();
			((Collection<ChartArea>)(object)chart.get_ChartAreas())[0].get_Axes()[0].set_Minimum(1.0);
			Reset();
		}

		public void Reset()
		{
			((Control)missedCommsTextBox).set_Text("(None)");
			((Control)longCommsTextBox).set_Text("(None)");
			((Control)allCommsTextBox).set_Text("(None)");
			((Collection<DataPoint>)(object)((Collection<Series>)(object)chart.get_Series())[0].get_Points()).Clear();
		}

		private void chart_MouseMove(object sender, MouseEventArgs e)
		{
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Invalid comparison between Unknown and I4
			Point location = e.get_Location();
			if (prevPosition.HasValue && location == prevPosition.Value)
			{
				return;
			}
			tooltip.RemoveAll();
			prevPosition = location;
			HitTestResult[] array = chart.HitTest(location.X, location.Y, false, (ChartElementType[])(object)new ChartElementType[1] { (ChartElementType)16 });
			foreach (HitTestResult val in array)
			{
				if ((int)val.get_ChartElementType() != 16)
				{
					continue;
				}
				object @object = val.get_Object();
				DataPoint val2 = (DataPoint)((@object is DataPoint) ? @object : null);
				if (val2 != null)
				{
					double num = val.get_ChartArea().get_AxisX().ValueToPixelPosition(val2.get_XValue());
					double num2 = val.get_ChartArea().get_AxisY().ValueToPixelPosition(val2.get_YValues()[0]);
					if (Math.Abs((double)location.X - num) < 2.0 && Math.Abs((double)location.Y - num2) < 2.0)
					{
						tooltip.Show("X=" + val2.get_XValue() + ", Y=" + val2.get_YValues()[0], (IWin32Window)(object)chart, location.X, location.Y - 15);
					}
				}
			}
		}

		private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)e.get_HitTestResult().get_ChartElementType() == 16)
			{
				int pointIndex = e.get_HitTestResult().get_PointIndex();
				string text = parent.commOrder[pointIndex];
				string text2 = Tester.msToStr(parent.commTimes[pointIndex]);
				e.set_Text(text + " = " + CommTester.Comms[text] + " (" + text2 + ")");
			}
			else
			{
				e.set_Text("");
			}
		}

		public void updateData()
		{
			if (((Control)this).get_IsDisposed())
			{
				return;
			}
			((Collection<DataPoint>)(object)((Collection<Series>)(object)chart.get_Series())[0].get_Points()).Clear();
			for (int j = 0; j < parent.currentComm; j++)
			{
				((Collection<Series>)(object)chart.get_Series())[0].get_Points().AddXY((double)(j + 1), (double)((float)parent.commTimes[j] / 1000f));
			}
			int num = 0;
			foreach (DataPoint item in (Collection<DataPoint>)(object)((Collection<Series>)(object)chart.get_Series())[0].get_Points())
			{
				((DataPointCustomProperties)item).set_MarkerColor(parent.reminded[num++] ? Color.Red : Color.MediumTurquoise);
			}
			string[] array = (from i in Enumerable.Range(0, parent.currentComm)
				where parent.reminded[i]
				select parent.commOrder[i] + " = " + CommTester.Comms[parent.commOrder[i]]).ToArray();
			((Control)missedCommsTextBox).set_Text((array.Length == 0) ? "(None)" : string.Join(Environment.NewLine, array));
			string[] array2 = (from i in Enumerable.Range(0, parent.currentComm)
				where !parent.reminded[i] && parent.commTimes[i] >= 5000
				select parent.commOrder[i] + " = " + CommTester.Comms[parent.commOrder[i]] + " (" + Tester.msToStr(parent.commTimes[i]) + ")").ToArray();
			((Control)longCommsTextBox).set_Text((array2.Length == 0) ? "(None)" : string.Join(Environment.NewLine, array2));
			string[] array3 = (from i in Enumerable.Range(0, parent.currentComm)
				select parent.commOrder[i] + " = " + CommTester.Comms[parent.commOrder[i]] + (parent.reminded[i] ? " (failed)" : (" (" + Tester.msToStr(parent.commTimes[i]) + ")"))).ToArray();
			((Control)allCommsTextBox).set_Text((array3.Length == 0) ? "(None)" : string.Join(Environment.NewLine, array3));
		}

		private string getTSV(IEnumerable<int> comms)
		{
			string text = "Comm\tAlg\tPassed\tTime (s)";
			foreach (int comm in comms)
			{
				string text2 = parent.commOrder[comm];
				string text3 = CommTester.Comms[text2];
				bool flag = !parent.reminded[comm];
				string text4 = Tester.msToStr(parent.commTimes[comm]);
				string text5 = text4;
				text4 = text5.Remove(text5.Length - 1);
				text += string.Format("\n{0}\t{1}\t{2}\t{3}", text2, text3, flag, flag ? text4 : "");
			}
			return text;
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			Control val = (Control)sender;
			val.set_Height(TextRenderer.MeasureText(val.get_Text(), val.get_Font()).Height + 20);
		}

		private void textBox_SizeChanged(object sender, EventArgs e)
		{
		}

		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			textBox_SizeChanged(sender, null);
		}

		private void splitCont_MouseDown(object sender, MouseEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			((SplitContainer)sender).set_IsSplitterFixed(true);
		}

		private void splitCont_MouseUp(object sender, MouseEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			((SplitContainer)sender).set_IsSplitterFixed(false);
		}

		private void splitCont_MouseMove(object sender, MouseEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			if (!((SplitContainer)sender).get_IsSplitterFixed())
			{
				return;
			}
			MouseButtons button = e.get_Button();
			if (((object)(MouseButtons)(ref button)).Equals((object)(MouseButtons)1048576))
			{
				Orientation orientation = ((SplitContainer)sender).get_Orientation();
				if (((object)(Orientation)(ref orientation)).Equals((object)(Orientation)1))
				{
					if (e.get_X() > 0 && e.get_X() < ((Control)(SplitContainer)sender).get_Width())
					{
						((SplitContainer)sender).set_SplitterDistance(e.get_X());
						((Control)(SplitContainer)sender).Refresh();
					}
				}
				else if (e.get_Y() > 0 && e.get_Y() < ((Control)(SplitContainer)sender).get_Height())
				{
					((SplitContainer)sender).set_SplitterDistance(e.get_Y());
					((Control)(SplitContainer)sender).Refresh();
				}
			}
			else
			{
				((SplitContainer)sender).set_IsSplitterFixed(false);
			}
		}

		private void DataForm_Load(object sender, EventArgs e)
		{
			updateData();
		}

		private void saveTSV(string tsv)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			if ((int)((CommonDialog)saveTSVDialog).ShowDialog() == 1)
			{
				File.WriteAllText(((FileDialog)saveTSVDialog).get_FileName(), tsv);
			}
		}

		private void exportMissedCommsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string tSV = getTSV(from i in Enumerable.Range(0, parent.currentComm)
				where parent.reminded[i]
				select i);
			saveTSV(tSV);
		}

		private void exportLongCommsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string tSV = getTSV(from i in Enumerable.Range(0, parent.currentComm)
				where !parent.reminded[i] && parent.commTimes[i] >= 5000
				select i);
			saveTSV(tSV);
		}

		private void exportAllCommsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string tSV = getTSV(Enumerable.Range(0, parent.currentComm));
			saveTSV(tSV);
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
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Expected O, but got Unknown
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Expected O, but got Unknown
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Expected O, but got Unknown
			//IL_0351: Unknown result type (might be due to invalid IL or missing references)
			//IL_035b: Expected O, but got Unknown
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_0372: Expected O, but got Unknown
			//IL_058a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0594: Expected O, but got Unknown
			//IL_07be: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c8: Expected O, but got Unknown
			//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a10: Expected O, but got Unknown
			ChartArea val = new ChartArea();
			Series val2 = new Series();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CommDataForm));
			chart = new Chart();
			splitContainer1 = new SplitContainer();
			flowPanel = new FlowLayoutPanel();
			panel1 = new Panel();
			exportMissedCommsLink = new LinkLabel();
			label4 = new Label();
			missedCommsTextBox = new TextBox();
			panel2 = new Panel();
			exportLongCommsLink = new LinkLabel();
			label1 = new Label();
			longCommsTextBox = new TextBox();
			panel3 = new Panel();
			exportAllCommsLink = new LinkLabel();
			label2 = new Label();
			allCommsTextBox = new TextBox();
			saveTSVDialog = new SaveFileDialog();
			((ISupportInitialize)chart).BeginInit();
			((ISupportInitialize)splitContainer1).BeginInit();
			((Control)splitContainer1.get_Panel1()).SuspendLayout();
			((Control)splitContainer1.get_Panel2()).SuspendLayout();
			((Control)splitContainer1).SuspendLayout();
			((Control)flowPanel).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)panel2).SuspendLayout();
			((Control)panel3).SuspendLayout();
			((Control)this).SuspendLayout();
			((ChartNamedElement)val).set_Name("ChartArea1");
			((Collection<ChartArea>)(object)chart.get_ChartAreas()).Add(val);
			((Control)chart).set_Dock((DockStyle)5);
			((Control)chart).set_Location(new Point(0, 0));
			((Control)chart).set_Name("chart");
			((DataPointCustomProperties)val2).set_BorderColor(Color.Black);
			val2.set_ChartArea("ChartArea1");
			val2.set_ChartType((SeriesChartType)3);
			((DataPointCustomProperties)val2).set_MarkerBorderColor(Color.Black);
			((DataPointCustomProperties)val2).set_MarkerColor(Color.MediumTurquoise);
			((DataPointCustomProperties)val2).set_MarkerSize(8);
			((DataPointCustomProperties)val2).set_MarkerStyle((MarkerStyle)2);
			((ChartNamedElement)val2).set_Name("Series");
			val2.set_XValueType((ChartValueType)3);
			val2.set_YValueType((ChartValueType)1);
			((Collection<Series>)(object)chart.get_Series()).Add(val2);
			chart.set_Size(new Size(379, 318));
			((Control)chart).set_TabIndex(0);
			((Control)chart).set_Text("chart1");
			chart.add_GetToolTipText((EventHandler<ToolTipEventArgs>)chart_GetToolTipText);
			((Control)chart).add_MouseMove(new MouseEventHandler(chart_MouseMove));
			splitContainer1.set_BorderStyle((BorderStyle)2);
			splitContainer1.set_Dock((DockStyle)5);
			splitContainer1.set_FixedPanel((FixedPanel)2);
			((Control)splitContainer1).set_Location(new Point(0, 0));
			((Control)splitContainer1).set_Name("splitContainer1");
			((Control)splitContainer1.get_Panel1()).get_Controls().Add((Control)(object)chart);
			((Control)splitContainer1.get_Panel2()).get_Controls().Add((Control)(object)flowPanel);
			((Control)splitContainer1).set_Size(new Size(661, 322));
			splitContainer1.set_SplitterDistance(383);
			splitContainer1.set_SplitterWidth(5);
			((Control)splitContainer1).set_TabIndex(1);
			splitContainer1.add_SplitterMoved(new SplitterEventHandler(splitContainer1_SplitterMoved));
			((Control)splitContainer1).add_MouseDown(new MouseEventHandler(splitCont_MouseDown));
			((Control)splitContainer1).add_MouseMove(new MouseEventHandler(splitCont_MouseMove));
			((Control)splitContainer1).add_MouseUp(new MouseEventHandler(splitCont_MouseUp));
			((ScrollableControl)flowPanel).set_AutoScroll(true);
			((Control)flowPanel).get_Controls().Add((Control)(object)panel1);
			((Control)flowPanel).get_Controls().Add((Control)(object)missedCommsTextBox);
			((Control)flowPanel).get_Controls().Add((Control)(object)panel2);
			((Control)flowPanel).get_Controls().Add((Control)(object)longCommsTextBox);
			((Control)flowPanel).get_Controls().Add((Control)(object)panel3);
			((Control)flowPanel).get_Controls().Add((Control)(object)allCommsTextBox);
			((Control)flowPanel).set_Dock((DockStyle)5);
			flowPanel.set_FlowDirection((FlowDirection)1);
			((Control)flowPanel).set_Location(new Point(0, 0));
			((Control)flowPanel).set_Name("flowPanel");
			((Control)flowPanel).set_Size(new Size(269, 318));
			((Control)flowPanel).set_TabIndex(0);
			flowPanel.set_WrapContents(false);
			((Control)panel1).get_Controls().Add((Control)(object)exportMissedCommsLink);
			((Control)panel1).get_Controls().Add((Control)(object)label4);
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(239, 20));
			((Control)panel1).set_TabIndex(7);
			exportMissedCommsLink.set_ActiveLinkColor(Color.Red);
			((Control)exportMissedCommsLink).set_AutoSize(true);
			exportMissedCommsLink.set_LinkColor(Color.Blue);
			((Control)exportMissedCommsLink).set_Location(new Point(169, 4));
			((Control)exportMissedCommsLink).set_Name("exportMissedCommsLink");
			((Control)exportMissedCommsLink).set_Size(new Size(67, 13));
			((Control)exportMissedCommsLink).set_TabIndex(7);
			exportMissedCommsLink.set_TabStop(true);
			((Control)exportMissedCommsLink).set_Text("(Export TSV)");
			exportMissedCommsLink.set_VisitedLinkColor(Color.Blue);
			exportMissedCommsLink.add_LinkClicked(new LinkLabelLinkClickedEventHandler(exportMissedCommsLink_LinkClicked));
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)label4).set_Location(new Point(0, 1));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(124, 19));
			((Control)label4).set_TabIndex(6);
			((Control)label4).set_Text("Missed Comms:");
			((Control)missedCommsTextBox).set_Font(new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)missedCommsTextBox).set_Location(new Point(3, 29));
			((TextBoxBase)missedCommsTextBox).set_Multiline(true);
			((Control)missedCommsTextBox).set_Name("missedCommsTextBox");
			((TextBoxBase)missedCommsTextBox).set_ReadOnly(true);
			((Control)missedCommsTextBox).set_Size(new Size(239, 84));
			((Control)missedCommsTextBox).set_TabIndex(0);
			((Control)missedCommsTextBox).add_TextChanged((EventHandler)textBox_TextChanged);
			((Control)panel2).get_Controls().Add((Control)(object)exportLongCommsLink);
			((Control)panel2).get_Controls().Add((Control)(object)label1);
			((Control)panel2).set_Location(new Point(3, 119));
			((Control)panel2).set_Name("panel2");
			((Control)panel2).set_Size(new Size(239, 20));
			((Control)panel2).set_TabIndex(8);
			exportLongCommsLink.set_ActiveLinkColor(Color.Red);
			((Control)exportLongCommsLink).set_AutoSize(true);
			exportLongCommsLink.set_LinkColor(Color.Blue);
			((Control)exportLongCommsLink).set_Location(new Point(169, 5));
			((Control)exportLongCommsLink).set_Name("exportLongCommsLink");
			((Control)exportLongCommsLink).set_Size(new Size(67, 13));
			((Control)exportLongCommsLink).set_TabIndex(7);
			exportLongCommsLink.set_TabStop(true);
			((Control)exportLongCommsLink).set_Text("(Export TSV)");
			exportLongCommsLink.set_VisitedLinkColor(Color.Blue);
			exportLongCommsLink.add_LinkClicked(new LinkLabelLinkClickedEventHandler(exportLongCommsLink_LinkClicked));
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)label1).set_Location(new Point(0, 1));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(127, 19));
			((Control)label1).set_TabIndex(6);
			((Control)label1).set_Text("Comms Over 5s:");
			((Control)longCommsTextBox).set_Anchor((AnchorStyles)13);
			((Control)longCommsTextBox).set_Font(new Font("Microsoft YaHei UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)longCommsTextBox).set_Location(new Point(3, 145));
			((TextBoxBase)longCommsTextBox).set_Multiline(true);
			((Control)longCommsTextBox).set_Name("longCommsTextBox");
			((TextBoxBase)longCommsTextBox).set_ReadOnly(true);
			((Control)longCommsTextBox).set_Size(new Size(239, 84));
			((Control)longCommsTextBox).set_TabIndex(1);
			((Control)longCommsTextBox).add_TextChanged((EventHandler)textBox_TextChanged);
			((Control)panel3).get_Controls().Add((Control)(object)exportAllCommsLink);
			((Control)panel3).get_Controls().Add((Control)(object)label2);
			((Control)panel3).set_Location(new Point(3, 235));
			((Control)panel3).set_Name("panel3");
			((Control)panel3).set_Size(new Size(239, 20));
			((Control)panel3).set_TabIndex(9);
			exportAllCommsLink.set_ActiveLinkColor(Color.Red);
			((Control)exportAllCommsLink).set_AutoSize(true);
			exportAllCommsLink.set_LinkColor(Color.Blue);
			((Control)exportAllCommsLink).set_Location(new Point(169, 5));
			((Control)exportAllCommsLink).set_Name("exportAllCommsLink");
			((Control)exportAllCommsLink).set_Size(new Size(67, 13));
			((Control)exportAllCommsLink).set_TabIndex(7);
			exportAllCommsLink.set_TabStop(true);
			((Control)exportAllCommsLink).set_Text("(Export TSV)");
			exportAllCommsLink.set_VisitedLinkColor(Color.Blue);
			exportAllCommsLink.add_LinkClicked(new LinkLabelLinkClickedEventHandler(exportAllCommsLink_LinkClicked));
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Font(new Font("Microsoft YaHei UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)label2).set_Location(new Point(0, 1));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(91, 19));
			((Control)label2).set_TabIndex(6);
			((Control)label2).set_Text("All Comms:");
			((Control)allCommsTextBox).set_Font(new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)allCommsTextBox).set_Location(new Point(3, 261));
			((TextBoxBase)allCommsTextBox).set_Multiline(true);
			((Control)allCommsTextBox).set_Name("allCommsTextBox");
			((TextBoxBase)allCommsTextBox).set_ReadOnly(true);
			((Control)allCommsTextBox).set_Size(new Size(239, 84));
			((Control)allCommsTextBox).set_TabIndex(4);
			((Control)allCommsTextBox).add_TextChanged((EventHandler)textBox_TextChanged);
			((FileDialog)saveTSVDialog).set_DefaultExt("tsv");
			((FileDialog)saveTSVDialog).set_Filter("*.tsv|Tab-Separated Values");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(661, 322));
			((Control)this).get_Controls().Add((Control)(object)splitContainer1);
			((Form)this).set_Icon((Icon)componentResourceManager.GetObject("$this.Icon"));
			((Control)this).set_Name("CommDataForm");
			((Control)this).set_Text("Comm Data");
			((Form)this).add_Load((EventHandler)DataForm_Load);
			((ISupportInitialize)chart).EndInit();
			((Control)splitContainer1.get_Panel1()).ResumeLayout(false);
			((Control)splitContainer1.get_Panel2()).ResumeLayout(false);
			((ISupportInitialize)splitContainer1).EndInit();
			((Control)splitContainer1).ResumeLayout(false);
			((Control)flowPanel).ResumeLayout(false);
			((Control)flowPanel).PerformLayout();
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)panel2).ResumeLayout(false);
			((Control)panel2).PerformLayout();
			((Control)panel3).ResumeLayout(false);
			((Control)panel3).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
