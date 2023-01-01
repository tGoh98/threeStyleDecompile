using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class CubeSettingsControl : UserControl
	{
		public StickerControl currentSticker;

		private const int PADDING_LEFT = 10;

		private const int PADDING_RIGHT = 10;

		private const int PADDING_TOP = 5;

		private const int PADDING_BOTTOM = 15;

		private StickerControl[,,] stickers;

		private IContainer components;

		private Label instructionsLabel;

		public ColorDialog colorPicker;

		private Button saveButton;

		private void saveButton_Click(object sender, EventArgs e)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Settings.Save();
				((Control)saveButton).set_Enabled(false);
			}
			catch (SettingsException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public CubeSettingsControl()
		{
			InitializeComponent();
			Size size = new Size(380, 270 + ((Control)instructionsLabel).get_Height() + 5 + 15);
			((Control)this).set_MaximumSize(size);
			((Control)this).set_MinimumSize(size);
			stickers = new StickerControl[6, 3, 3];
			for (int i = 0; i < 6; i++)
			{
				int num = -1;
				switch (i)
				{
				case 1:
					num = 0;
					break;
				case 0:
				case 2:
				case 5:
					num = 1;
					break;
				case 3:
					num = 2;
					break;
				case 4:
					num = 3;
					break;
				}
				int num2 = -1;
				switch (i)
				{
				case 0:
					num2 = 0;
					break;
				case 1:
				case 2:
				case 3:
				case 4:
					num2 = 1;
					break;
				case 5:
					num2 = 2;
					break;
				}
				num *= 90;
				num2 *= 90;
				num += 10;
				num2 += ((Control)instructionsLabel).get_Height() + 5;
				for (int j = 0; j < 9; j++)
				{
					int num3 = -1;
					int num4 = -1;
					switch (j)
					{
					case 0:
					case 6:
					case 7:
						num3 = 0;
						break;
					case 1:
					case 5:
					case 8:
						num3 = 1;
						break;
					default:
						num3 = 2;
						break;
					}
					switch (j)
					{
					case 0:
					case 1:
					case 2:
						num4 = 0;
						break;
					case 3:
					case 7:
					case 8:
						num4 = 1;
						break;
					default:
						num4 = 2;
						break;
					}
					StickerControl stickerControl = new StickerControl(this, (j == 8) ? i : (-1));
					((Control)stickerControl).set_Left(num + num3 * 30);
					((Control)stickerControl).set_Top(num2 + num4 * 30);
					if (j != 8)
					{
						stickerControl.Letter = Settings.Letters[8 * i + j];
					}
					((Control)this).get_Controls().Add((Control)(object)stickerControl);
					stickers[i, num3, num4] = stickerControl;
				}
				UpdateColors(i);
			}
		}

		public void UpdateColors(int center)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					((Control)stickers[center, i, j]).set_BackColor(Settings.Colors[center]);
				}
			}
		}

		public void CubeSettingsControl_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected I4, but got Unknown
			if (currentSticker == null || currentSticker.IsCenter)
			{
				return;
			}
			int num = (int)e.get_KeyCode();
			if ((num >= 97 && num <= 122) || (num >= 65 && num <= 90))
			{
				char c = char.ToUpper((char)num);
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 3; k++)
						{
							if (stickers[i, j, k] == currentSticker)
							{
								int letterIndex = new Cube().Cubies[i, j, k].GetLetterIndex();
								Settings.Letters = new StringBuilder(Settings.Letters) { [letterIndex] = c }.ToString();
								currentSticker.Letter = c;
							}
						}
					}
				}
			}
			((Control)saveButton).set_Enabled(true);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((ContainerControl)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Expected O, but got Unknown
			instructionsLabel = new Label();
			colorPicker = new ColorDialog();
			saveButton = new Button();
			((Control)this).SuspendLayout();
			((Control)instructionsLabel).set_BackColor(Color.Transparent);
			((Control)instructionsLabel).set_Dock((DockStyle)1);
			((Control)instructionsLabel).set_Font(new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)instructionsLabel).set_Location(new Point(0, 0));
			((Control)instructionsLabel).set_Name("instructionsLabel");
			((Control)instructionsLabel).set_Size(new Size(380, 43));
			((Control)instructionsLabel).set_TabIndex(0);
			((Control)instructionsLabel).set_Text("Click a center to set its color. Type into other stickers to set your letter scheme.");
			colorPicker.set_Color(Color.Green);
			colorPicker.set_SolidColorOnly(true);
			((Control)saveButton).set_BackColor(Color.FromArgb(255, 224, 192));
			((Control)saveButton).set_Enabled(false);
			((Control)saveButton).set_Font(new Font("Microsoft YaHei UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0));
			((Control)saveButton).set_Location(new Point(249, 274));
			((Control)saveButton).set_Name("saveButton");
			((Control)saveButton).set_Size(new Size(106, 23));
			((Control)saveButton).set_TabIndex(1);
			((Control)saveButton).set_Text("Save Letters");
			((ButtonBase)saveButton).set_UseVisualStyleBackColor(false);
			((Control)saveButton).add_Click((EventHandler)saveButton_Click);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((UserControl)this).set_BorderStyle((BorderStyle)2);
			((Control)this).get_Controls().Add((Control)(object)saveButton);
			((Control)this).get_Controls().Add((Control)(object)instructionsLabel);
			((Control)this).set_Name("CubeSettingsControl");
			((Control)this).set_Size(new Size(380, 300));
			((Control)this).add_KeyDown(new KeyEventHandler(CubeSettingsControl_KeyDown));
			((Control)this).ResumeLayout(false);
		}
	}
}
