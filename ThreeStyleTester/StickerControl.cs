using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class StickerControl : Label
	{
		public const int SIZE = 30;

		private char letter = ' ';

		private int center;

		private CubeSettingsControl parent;

		public char Letter
		{
			get
			{
				return letter;
			}
			set
			{
				letter = value;
				((Control)this).set_Text(letter.ToString());
			}
		}

		public bool IsCenter => center >= 0;

		public StickerControl(CubeSettingsControl parent, int center)
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			this.center = center;
			((Label)this).set_BorderStyle((BorderStyle)1);
			((Label)this).set_TabStop(false);
			((Control)this).set_Text(Letter.ToString());
			((Label)this).set_TextAlign(ContentAlignment.MiddleCenter);
			((Control)this).set_AutoSize(false);
			int width;
			((Control)this).set_Height(width = 30);
			((Control)this).set_Width(width);
			((Control)this).add_MouseEnter((EventHandler)StickerControl_MouseEnter);
			((Control)this).add_MouseLeave((EventHandler)StickerControl_MouseLeave);
			if (center >= 0)
			{
				((Control)this).add_MouseClick(new MouseEventHandler(StickerControl_MouseClick));
			}
			this.parent = parent;
		}

		private void StickerControl_MouseClick(object sender, MouseEventArgs e)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Invalid comparison between Unknown and I4
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			if (center >= 0 && (int)((CommonDialog)parent.colorPicker).ShowDialog() == 1)
			{
				Settings.Colors[center] = parent.colorPicker.get_Color();
				try
				{
					Settings.Save();
				}
				catch (SettingsException ex)
				{
					MessageBox.Show(ex.Message);
				}
				parent.UpdateColors(center);
			}
		}

		private void StickerControl_MouseLeave(object sender, EventArgs e)
		{
			((Label)this).set_BorderStyle((BorderStyle)1);
			if (parent.currentSticker == this)
			{
				parent.currentSticker = null;
			}
		}

		private void StickerControl_MouseEnter(object sender, EventArgs e)
		{
			((Label)this).set_BorderStyle((BorderStyle)2);
			parent.currentSticker = this;
		}
	}
}
