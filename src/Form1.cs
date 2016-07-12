using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace gCrop
{

	public partial class Form1 : Form
	{
		const int PreviewScale = 3;
		float Ratio = 1.5f;
		float PLeft = 0;
		float PTop = 0;
		float PWidth = 1;
		int MaxPWidth = 1;
		int SaveWidth = 2880;

		string FileName;
		Bitmap PictureOriSize;
		Bitmap Picture;

		ulong LastZoomDistance;
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
		protected override void WndProc(ref Message m)
		{
			// Listen for operating system messages.
			bool bHandled = false;
			switch (m.Msg)
			{
				// The WM_ACTIVATEAPP message occurs when the application
				// becomes the active application or becomes inactive.
				case 0x0119:  //WM_GESTURE
					GESTUREINFO gi = new GESTUREINFO();
					gi.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(gi);
					bool bResult = GetGestureInfo(m.LParam, ref gi);
					if (bResult)
					{
						switch (gi.dwID)
						{
							case 3:  //GID_ZOOM
								if (gi.dwFlags == 1)
									LastZoomDistance = gi.ullArguments;
								else
								{
									float zoomratio = (float)gi.ullArguments / LastZoomDistance;
									float newPWidth = PWidth / zoomratio;
									float newPLeft = PLeft - (float)(gi.ptsLocation.x - pictureBox1.Left - Left) / pictureBox1.Width * (newPWidth - PWidth);
									float newPTop = PTop - (float)(gi.ptsLocation.y - pictureBox1.Top - Top) / pictureBox1.Height * (newPWidth - PWidth) / Ratio;
									PWidth = newPWidth;
									PLeft = newPLeft;
									PTop = newPTop;
									LastZoomDistance = gi.ullArguments;
								}
								bHandled = true;
								break;
							case 4:  //GID_PAN
								Console.WriteLine("pan");
								bHandled = true;
								break;
							default:
								break;
						}
					}
				break;
			}
			if (!bHandled)
				base.WndProc(ref m);
		}

		public Form1()
		{
			InitializeComponent();
			pictureBox1.Height = (int)(pictureBox1.Width / Ratio);
			this.Width = 1280 + 20;
			this.Height = 856 + 20 + SystemInformation.CaptionHeight;
		}

		bool Panning = false;
		int LastMouseX, LastMouseY;
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			LastMouseX = e.X;
			LastMouseY = e.Y;
			Panning = true;
			pictureBox1.Focus();
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (!Panning)
				return;

			PLeft -= (e.X - LastMouseX) / (float)pictureBox1.Width * PWidth;
			PTop -= (e.Y - LastMouseY) / (float)pictureBox1.Width * PWidth;
			LastMouseX = e.X;
			LastMouseY = e.Y;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			Panning = false;
		}

        protected override void OnMouseWheel(MouseEventArgs e)
        {
			if (e.Delta > 0)
			{
				if (PWidth > SaveWidth / PreviewScale)
				{
					PLeft += 5;
					PTop += 5 / Ratio;
					PWidth -= 10;
				}
			}
			else
			{
				if (PWidth < MaxPWidth)
				{
					PLeft -= 5;
					PTop -= 5 / Ratio;
					PWidth += 10;
				}
			}

			UpdateRectangle();
		}


        private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			FileName = files[0];
			if (PictureOriSize != null)
				PictureOriSize.Dispose();
			if (Picture != null)
				Picture.Dispose();
			PictureOriSize = new Bitmap(FileName);
			Picture = new Bitmap(PictureOriSize.Width / PreviewScale, PictureOriSize.Height / PreviewScale);
			Graphics g = Graphics.FromImage(Picture);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(PictureOriSize, new RectangleF(0, 0, Picture.Width, Picture.Height), new RectangleF(0, 0, PictureOriSize.Width, PictureOriSize.Height), GraphicsUnit.Pixel);
			g.Dispose();
			if ((float)Picture.Width / Picture.Height >= Ratio)
			{
				PTop = -1;
				PLeft = (Picture.Width - Picture.Height * Ratio) / 2;
				PWidth = Picture.Height * Ratio;
				MaxPWidth = (int)PWidth;
			}
			else
			{
				PTop = (Picture.Height - Picture.Width / Ratio) / 2;
				PLeft = -1;
				PWidth = Picture.Width;
				MaxPWidth = (int)PWidth;
			}
			timer1.Enabled = true;
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		
		float LastPRatio = 1.5f;
		int LastPLeft = 0;
		int LastPTop = 0;
		int LastPWidth = 1;
		int LastBoxWidth;
		int LastBoxHeight;

		private void Form1_Resize(object sender, EventArgs e)
		{
			int newWidth = this.Width - 60;
			int newHeight = this.Height - SystemInformation.CaptionHeight - panel1.Height - 60;
			if ((int)(newWidth / Ratio) > newHeight)
				newWidth = (int)(newHeight * Ratio + 0.5);
			if ((int)(newHeight * Ratio) > newWidth)
				newHeight = (int)(newWidth / Ratio + 0.5);
			if (newWidth < 160)
			{
				newWidth = 160;
				newHeight = (int)(160 / Ratio + 0.5);
			}
			if (pictureBox1.Image != null)
				pictureBox1.Image.Dispose();
			pictureBox1.Width = newWidth;
			pictureBox1.Height = newHeight;
			pictureBox1.Left = (this.Width - pictureBox1.Width) / 2 - 11;
			pictureBox1.Top = (this.Height - SystemInformation.CaptionHeight - 20 - pictureBox1.Height) / 2 - 20;
			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			panel1.Top = this.Height - SystemInformation.CaptionHeight - panel1.Height - 30;
			panel1.Left = (this.Width - panel1.Width) / 2;
		}

		private void tbSaveWidth_TextChanged(object sender, EventArgs e)
		{
			int width;
			bool re = int.TryParse(tbRes.Text, out width);
			if (re)
			{
				SaveWidth = width;
				lbSaveHeight.Text = "x " + ((int)(width / Ratio + 0.5)).ToString();

				if ((float)Picture.Width / Picture.Height >= Ratio)
				{
					MaxPWidth = (int)(Picture.Height * Ratio);
				}
				else
				{
					MaxPWidth = (int)(Picture.Width);
				}
			}
		}

		private void rRation_CheckedChanged(object sender, EventArgs e)
		{
            float newratio = 1;
            if (r169.Checked)
            {
                newratio = 16 / 9f;
                tbrCustom.Enabled = false;
            }
            else if (r32.Checked)
            {
                newratio = 3 / 2f;
                tbrCustom.Enabled = false;
            }
            else if (rCustom.Checked)
            {
                tbrCustom.Enabled = true;
                bool re = float.TryParse(tbrCustom.Text, out newratio);
                if (!re)
                    return;
                if (newratio > 5 || newratio < 0.2)
                    return;
            }

            if (Ratio != newratio)
            {
                Ratio = newratio;
                int width;
                bool re = int.TryParse(tbRes.Text, out width);
                if (re)
                {
                    SaveWidth = width;
                    lbSaveHeight.Text = "x " + ((int)(width / Ratio + 0.5)).ToString();
                }

				if ((float)Picture.Width / Picture.Height >= Ratio)
				{
					MaxPWidth = (int)(Picture.Height * Ratio);
				}
				else
				{
					MaxPWidth = (int)(Picture.Width);
				}

				this.Form1_Resize(null, null);
            }
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			int savewidth, saveheight;
			savewidth = SaveWidth;
			bool re = int.TryParse(tbRes.Text, out savewidth);
			if (!re)
				return;

			saveheight = (int)(savewidth / Ratio + 0.5);
			Bitmap savebitmap = new Bitmap(savewidth, saveheight);
			Console.WriteLine("1");
			Graphics g = Graphics.FromImage(savebitmap);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(PictureOriSize, new RectangleF(0, 0, savebitmap.Width, savebitmap.Height), new RectangleF(PLeft * PreviewScale, PTop * PreviewScale, PWidth * PreviewScale, PWidth * PreviewScale / Ratio + 0.5f), GraphicsUnit.Pixel);
			g.Dispose();
			Console.WriteLine("2");
			ImageCodecInfo myImageCodecInfo = null;
			System.Drawing.Imaging.Encoder myEncoder;
			EncoderParameter myEncoderParameter;
			EncoderParameters myEncoderParameters;
			Console.WriteLine("3");

			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (int j = 0; j < encoders.Length; j++)
			{
				if (encoders[j].MimeType == "image/jpeg")
					myImageCodecInfo = encoders[j];
			}
			if (myImageCodecInfo == null)
				return;

			myEncoder = System.Drawing.Imaging.Encoder.Quality;
			myEncoderParameters = new EncoderParameters(1);
			myEncoderParameter = new EncoderParameter(myEncoder, 90L);
			myEncoderParameters.Param[0] = myEncoderParameter;

			int lastslash = FileName.LastIndexOf("\\");
			string outpath = FileName.Substring(0, lastslash) + "\\gCrop\\";
			if (!Directory.Exists(outpath))
				Directory.CreateDirectory(outpath);

			string savename = outpath + FileName.Substring(lastslash + 1);
			savebitmap.Save(savename, myImageCodecInfo, myEncoderParameters);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if ((GetKeyState((int)Keys.Up) & 0x8000) == 0x8000)
				PTop -= 2;
			if ((GetKeyState((int)Keys.Down) & 0x8000) == 0x8000)
				PTop += 2;
			if ((GetKeyState((int)Keys.Left) & 0x8000) == 0x8000)
				PLeft -= 2;
			if ((GetKeyState((int)Keys.Right) & 0x8000) == 0x8000)
				PLeft += 2;
			if ((GetKeyState((int)Keys.Oemplus) & 0x8000) == 0x8000)
			{
				if (PWidth > SaveWidth / PreviewScale)
				{
					PLeft += 1;
					PTop += 1 / Ratio;
					PWidth -= 2;
				}
			}
			if ((GetKeyState((int)Keys.OemMinus) & 0x8000) == 0x8000)
			{
				if (PWidth < MaxPWidth)
				{
					PLeft -= 1;
					PTop -= 1 / Ratio;
					PWidth += 2;
				}
			}

			UpdateRectangle();
		}

        private void UpdateRectangle()
        {
			if (Picture == null)
				return;

			if (PWidth > MaxPWidth)
				PWidth = MaxPWidth;
			if (PWidth * PreviewScale < SaveWidth)
				PWidth = SaveWidth / PreviewScale;
			if (PLeft < 0)
				PLeft = 0;
			if (PTop < 0)
				PTop = 0;
			int PHeight = (int)(PWidth / Ratio + 0.5);
			if (PLeft + PWidth >= Picture.Width)
				PLeft = Picture.Width - PWidth - 1;
			if (PTop + PHeight >= Picture.Height)
				PTop = Picture.Height - PHeight - 1;

			int drawPLeft = (int)(PLeft + 0.5);
			int drawPTop = (int)(PTop + 0.5);
			int drawPWidth = (int)(PWidth + 0.5);

			if
			(
				LastPLeft != drawPLeft ||
				LastPTop != drawPTop ||
				LastPWidth != drawPWidth ||
				LastPRatio != Ratio ||
				LastBoxWidth != pictureBox1.Width ||
				LastBoxHeight != pictureBox1.Height
			)
			{
				Graphics g = Graphics.FromImage(pictureBox1.Image);
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.DrawImage(Picture, new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height), new RectangleF(drawPLeft, drawPTop, drawPWidth, drawPWidth / Ratio), GraphicsUnit.Pixel);
				pictureBox1.Refresh();
				g.Dispose();
				LastPLeft = drawPLeft;
				LastPTop = drawPTop;
				LastPWidth = drawPWidth;
				LastPRatio = Ratio;
				LastBoxWidth = pictureBox1.Width;
				LastBoxHeight = pictureBox1.Height;
			}
		}

		[DllImport("user32")]
		public extern static bool GetGestureInfo(IntPtr hGestureInfo, ref GESTUREINFO pGestureInfo);
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern short GetKeyState(int keyCode);

		public struct GESTUREINFO
		{
			public uint cbSize;
			public uint dwFlags;
			public uint dwID;
			public IntPtr hwndTarget;
			public POINTS ptsLocation;
			public uint dwInstanceID;
			public uint dwSequenceID;
			public ulong ullArguments;
			public uint cbExtraArgs;
		}
		public struct POINTS
		{
			public ushort x;
			public ushort y;
		}

	}
}
