using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ThreeStyleTester
{
	public class CubeDisplayControl : UserControl
	{
		public StickerControl currentSticker;

		private const int PADDING_LEFT = 10;

		private const int PADDING_RIGHT = 10;

		private const int PADDING_TOP = 5;

		private const int PADDING_BOTTOM = 15;

		private IContainer components;

		public CubeDisplayControl()
		{
			InitializeComponent();
			Size size = new Size(380, 290);
			((Control)this).set_MaximumSize(size);
			((Control)this).set_MinimumSize(size);
		}

		public void SetColors(Cube cube)
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			((Control)this).get_Controls().Clear();
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
				num2 += 5;
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
					Label val = new Label();
					((Control)val).set_AutoSize(false);
					((Control)val).set_Size(new Size(30, 30));
					val.set_BorderStyle((BorderStyle)1);
					((Control)val).set_Left(num + num3 * 30);
					((Control)val).set_Top(num2 + num4 * 30);
					((Control)val).set_BackColor(Settings.Colors[cube.Cubies[i, num3, num4].SourceFace]);
					((Control)this).get_Controls().Add((Control)(object)val);
				}
			}
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
			((Control)this).SuspendLayout();
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((UserControl)this).set_BorderStyle((BorderStyle)2);
			((Control)this).set_Name("CubeDisplayControl");
			((Control)this).set_Size(new Size(380, 300));
			((Control)this).ResumeLayout(false);
		}
	}
}
