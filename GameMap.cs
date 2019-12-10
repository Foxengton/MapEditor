using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MapEditor
{
	public partial class GameMap : Form
	{
		public GameMap()
		{
			InitializeComponent();
			KeyPreview = true;

			_Bitmap = new Bitmap(MapBox.Width, MapBox.Height, PixelFormat.Format32bppArgb);
			_Gr = Graphics.FromImage(_Bitmap);
			_Back_Color = Color.Black;
			_Rect = new Rectangle { X = 0, Y = 0, Height = MapBox.Height, Width = MapBox.Width };
			_Gr.FillRectangle(new SolidBrush(_Back_Color), _Rect);


			_StartPos = new Point((int)Math.Round(MapBox.Width / 2.0), (int)Math.Round(MapBox.Height / 2.0));

			_LocationList = new List<CellMap>();
			_Nation = new List<Nation>();
			_GridType = new Hexagon(32);
			_Nation.Add(new Nation(new AxialCoord(0,0)));
			_Nation[0].NameNation = "Гоблинвилль";
			NationSelect.Items.Add(_Nation[0].NameNation);
			NationSelect.SelectedIndex = 0;

			_Location = _Nation[NationSelect.SelectedIndex].NationCoord;

			LoadMap();

			BackgroundSelect.Items.Add("Empty");
			GexesList.ImageSize = new Size(64, 56);
			string Path = Directory.GetCurrentDirectory() + _Path;
			string[] Files = Directory.GetFiles(Path + @"Background\");
			for (int i = 0; i < Files.Length; i++)
			{
				string Tag = Files[i].Replace(Path + @"Background\", "").Replace(".png", "");
				GexesList.Images.Add(Tag, Image.FromFile(Files[i]));
				BackgroundSelect.Items.Add(Tag);
			}
			Files = Directory.GetFiles(Path + @"Special\");
			for (int i = 0; i < Files.Length; i++)
			{
				string Tag = Files[i].Replace(Path + @"Special\", "").Replace(".png", "");
				GexesList.Images.Add(Tag, Image.FromFile(Files[i]));
			}
			Files = Directory.GetFiles(Path + @"Background\Road\");
			for (int i = 0; i < Files.Length; i++)
			{
				string Tag = Files[i].Replace(Path + @"Background\Road\", "").Replace(".png", "");
				GexesList.Images.Add(Tag, Image.FromFile(Files[i]));
			}
			Files = Directory.GetFiles(Path + @"Background\River\");
			for (int i = 0; i < Files.Length; i++)
			{
				string Tag = Files[i].Replace(Path + @"Background\River\", "").Replace(".png", "");
				GexesList.Images.Add(Tag, Image.FromFile(Files[i]));
			}
			BackgroundSelect.SelectedIndex = 0;

			

			BackgroundBox.Visible = false;
			FogOfWarCheck.Checked = true;

			DrawField();
		}
		private void MapEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		private void MapEditor_Resize(object sender, EventArgs e)
		{
			MapBox.Size = new Size { Width = Size.Width - 310, Height = Size.Height - 57 };

			_Bitmap = new Bitmap(MapBox.Width, MapBox.Height);
			_Gr = Graphics.FromImage(_Bitmap);
			_Gr.FillRectangle(new SolidBrush(_Back_Color), 0, 0, MapBox.Width, MapBox.Height);
		}
		private void MapEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Q) _Location = _Location.ToCube().Neighbor((int)CubeCoord.Directions.UpLeft).ToAxial();
			else if (e.KeyCode == Keys.W) _Location = _Location.ToCube().Neighbor((int)CubeCoord.Directions.Up).ToAxial();
			else if (e.KeyCode == Keys.E) _Location = _Location.ToCube().Neighbor((int)CubeCoord.Directions.UpRight).ToAxial();
			else if (e.KeyCode == Keys.A) _Location = _Location.ToCube().Neighbor((int)CubeCoord.Directions.DownLeft).ToAxial();
			else if (e.KeyCode == Keys.S) _Location = _Location.ToCube().Neighbor((int)CubeCoord.Directions.Down).ToAxial();
			else if (e.KeyCode == Keys.D) _Location = _Location.ToCube().Neighbor((int)CubeCoord.Directions.DownRight).ToAxial();
			else if (e.KeyCode == Keys.R) CellMap.Find(_LocationList, _Location).RemoveProp(e.Shift);
			else if (e.KeyCode == Keys.F) Edit();
			else if (e.KeyCode == Keys.C)
			{
				_StartPos = new Point((int)Math.Round(MapBox.Width / 2.0), (int)Math.Round(MapBox.Height / 2.0));
				_Location = _Nation[NationSelect.SelectedIndex].NationCoord;
			}

			if (FogOfWarCheck.Checked) FogOfWar();

			DrawField();

			CoordinatesText.Text = $"Координаты: {_Location.ToString()}";
		}

		private void MapBox_MouseMove(object sender, MouseEventArgs e)
		{
			CubeCoord Location_ = _GridType.PixelToHex(new PointF(e.X, e.Y), _StartPos).Add(_Location.ToCube());

			int Distance = _Location.ToCube().Distance(Location_);

			CoordinatesText.Text = $"Дистанция: {Distance}";
		}
		private void MapBox_MouseDown(object sender, MouseEventArgs e)
		{

		}

		//== КНОПКИ И ПРОЧИЕ КОНТРОЛЫ ==//
		private void ButtonSaveScreen_Click(object sender, EventArgs e)
		{
			DrawField();

			SaveFileDialog savedialog = new SaveFileDialog
			{
				Title = "Сохранить картинку как...",
				OverwritePrompt = true,
				CheckPathExists = true,
				Filter = "Image Files (*.png)|*.png",
				FileName = "Map.png"
			};
			if (savedialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					_Bitmap.Save(savedialog.FileName, ImageFormat.Png);
				}
				catch
				{
					MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonSaveMap_Click(object sender, EventArgs e)
		{
			ButtonMapSave.Enabled = false;

			CellMap.Save(_LocationList, _Path);
		}
		private void ButtonLoadMap_Click(object sender, EventArgs e)
		{
			LoadMap();
		}
		private void LoadMap()
		{
			ButtonMapLoad.Enabled = false;
			ButtonMapScreenShot.Enabled = true;

			_Path = CellMap.Load(_LocationList, @"Resources/Map.txt");
		}
		private void BacksBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			BackgroundSelect.Enabled = false;
			BackgroundSelect.Enabled = true;

			RefreshMap();
		}
		private void ModeGodCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (ModeGodCheck.Checked)
			{
				BackgroundBox.Visible = true;
			}
			else
			{
				BackgroundBox.Visible = false;
				FogOfWarCheck.Checked = true;
			}
		}

		//== ==//
		private void DrawField()
		{
			GC.Collect();
			_Gr.Clear(_Back_Color);

			AxialCoord[] Coord_ = _GridType.СubeSpiral(_Location, 5);

			for (int Loc = 0; Loc < Coord_.Length; Loc++)
			{
				if (FogOfWarCheck.Checked && CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, Coord_[Loc]).State == CellMap.States.Hidden)
				{
					DrawImage(Coord_[Loc], "Hidden");
				}
				else if (FogOfWarCheck.Checked && CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, Coord_[Loc]).State == CellMap.States.Shadow)
				{
					for (int Prop = 0; Prop < 3; Prop++)
						if (CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, Coord_[Loc]).Properties[Prop] != "")
							DrawImage(Coord_[Loc], CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, Coord_[Loc]).Properties[Prop], (Bitmap)GexesList.Images[GexesList.Images.IndexOfKey("Shadow")]);
				}
				else
				{	
					for (int Prop = 0; Prop < 3; Prop++)
						if (CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, Coord_[Loc]).Properties[Prop] != "")
							DrawImage(Coord_[Loc], CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, Coord_[Loc]).Properties[Prop]);
				}
			}

			RefreshMap();
		}
		private string DrawPath(int Index)
		{
			string FinalPath = string.Empty;
			CellMap Loc;

			CubeCoord coord = _Location.ToCube();

			for (int i = 0; i < 6; i++)
				if ((Loc = CellMap.Find(_LocationList, coord.Neighbor(i).ToAxial())).ID != null)
					if (Loc.Properties[Index] != "") FinalPath += i+1;

			if (Index == 1) return "Road" + FinalPath;
			else return "River" + FinalPath;
		}
		private void Edit()
		{
			ButtonMapSave.Enabled = true;

			string[] Prop = new string[3] { "", "", "" };

			if ((string)BackgroundSelect.SelectedItem != "Empty") Prop[0] = (string)BackgroundSelect.SelectedItem;
			else Prop[0] = CellMap.Find(_LocationList, _Location).Properties[0];
			if (RoadCheck.Checked) Prop[1] = DrawPath(1);
			if (RiverCheck.Checked) Prop[2] = DrawPath(2);

			if (CellMap.Find(_LocationList, _Location).ID == null)
			{
				_LocationList.Add(new CellMap(_Location, Prop));
				CellMap.Sort(_LocationList);
			}
			else CellMap.Find(_LocationList, _Location).SetProp(Prop);

		}

		private void DrawImage(AxialCoord Pt, string Key, Bitmap SecondImg = null) => DrawImage(Pt, GexesList.Images.IndexOfKey(Key), SecondImg);
		private void DrawImage(AxialCoord Pt, int Index, Bitmap SecondImg = null)
		{
			try
			{
				PointF coord = _GridType.Draw(Pt.Subtract(_Location), _StartPos);

				Bitmap Img = (Bitmap)GexesList.Images[Index];

				if (SecondImg != null)
				{
					Img = ImageAdditions(Img, SecondImg, 200);
				}

				_Gr.DrawImage(Img, (int)Math.Round(coord.X - 32), (int)Math.Round(coord.Y - 28));
			}
			catch
			{
				MessageBox.Show(CellMap.Find(_LocationList, Pt).ToString());
			}
		}
		private void RefreshMap()
		{
			if (ModeGodCheck.Checked)
			{
				if ((string)BackgroundSelect.SelectedItem != "Empty") DrawImage(_Location, (string)BackgroundSelect.SelectedItem);
				if (RoadCheck.Checked) DrawImage(_Location, "Road");
				if (RiverCheck.Checked) DrawImage(_Location, "River");
			}

			DrawImage(_Location, "Point");

			MapBox.Image = _Bitmap;
		}

		private Bitmap ImageAdditions(Bitmap x, Bitmap y, byte s)
		{
			if (x == null || y == null)
				throw new NullReferenceException();

			Bitmap bmp = new Bitmap(
				Math.Min(x.Width, y.Width),
				Math.Min(x.Height, y.Height),
				PixelFormat.Format32bppArgb
				);

			Color clr0, clr1;

			for (int _x = 0; _x < bmp.Width; _x++)
				for (int _y = 0; _y < bmp.Height; _y++)
				{
					clr0 = x.GetPixel(_x, _y);
					clr1 = y.GetPixel(_x, _y);

					if (clr0.A == 0 || clr1.A == 0)
					{
						bmp.SetPixel(_x, _y, clr0);
					} 
					else
					{
						bmp.SetPixel(_x, _y,
						Color.FromArgb(
							Math.Min(255, clr0.R * (255 - s) / 255 + clr1.R * s / 255),
							Math.Min(255, clr0.G * (255 - s) / 255 + clr1.G * s / 255),
							Math.Min(255, clr0.B * (255 - s) / 255 + clr1.B * s / 255)
						));
					}
				}
			return bmp;
		}

		private void FogOfWar()
		{
			if (CellMap.Find(_LocationList, _Location).ID != null)
			{
				if (CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, _Location).ID == null)
				{
					_Nation[NationSelect.SelectedIndex].Vision.Add(new CellMap(_Location, CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, _Location).Properties));
					CellMap.Sort(_Nation[NationSelect.SelectedIndex].Vision);
				}
				else
				{
					CellMap.Find(_Nation[NationSelect.SelectedIndex].Vision, _Location).State = CellMap.States.Visible;
				}
			}

			//for (int dir = 0; dir < _GridType.Directions; dir++)
			//{
			//	CellMap ThisCell = CellMap.Find(_LocationList, _Location.Neighbor(dir).ToAxial());
			//	//	CellMap PrevCell = CellMap.Find(_LocationList, _Location.ToAxial());

			//	if (CellMap.Find(_Nation.Vision, ThisCell.Coords).ID == null)
			//	{
			//		_Nation.Vision.Add(new CellMap(ThisCell.Coords, CellMap.Find(_LocationList, ThisCell.Coords).Properties));
			//		CellMap.Sort(_Nation.Vision);
			//	}
			//	else
			//	{
			//		CellMap.Find(_Nation.Vision, ThisCell.Coords).State = CellMap.States.Shadow;
			//	}
			//}

			CoordinatesText.Text = $"Координаты: {_Location.ToString()}";
		}

		private Color _Back_Color;
		private Rectangle _Rect;
		private Bitmap _Bitmap;
		private Graphics _Gr;

		private Point _StartPos;
		private AxialCoord _Location;

		private Hexagon _GridType;
		private List<CellMap> _LocationList;

		private List<Nation> _Nation;

		private string _Path;
	}
}