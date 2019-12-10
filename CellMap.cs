using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MapEditor
{
	public class CellMap
	{
		public CellMap()
		{
			ID = null;
			Properties = new string[3] { "", "", "" };
			LevelGround = 9999;
			HeightTerrain = 9999;
			StepCost = 9999;
		}
		public CellMap(AxialCoord Coords_, string[] Properties_)
		{
			ID = Coords_.x * 1000 + Coords_.y;
			Coords = Coords_;

			SetProp(Properties_);
		}
		public override string ToString()
		{
			string Text;

			Text = "[" + Coords.x + "; " + Coords.y + "]: ";
			for (int x = 0; x < Properties.Length; x++)
			{
				if (Properties[x] != "")
				{
					Text += Properties[x];
					if (x != Properties.Length - 1) Text += ", ";
				}
			}

			return Text;
		}

		public static void Save(List<CellMap> CellList, string SavePath)
		{
			string WritePath = @"Resources/Map.txt";

			try
			{
				using (StreamWriter SW = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
				{
					SW.WriteLine(SavePath);

					for (int Index = 0; Index < CellList.Count; Index++)
					{
						if (CellList[Index].Properties.Length != 0)
						{
							string Text = $"{CellList[Index].Coords.x};{CellList[Index].Coords.y};";

							for (int IndexPr = 0; IndexPr < CellList[Index].Properties.Length; IndexPr++)
							{
								Text += CellList[Index].Properties[IndexPr];

								if (IndexPr != CellList[Index].Properties.Length - 1) Text += ";";
							}

							SW.WriteLine(Text);
						}
					}
				}
			}
			catch (Exception er)
			{
				Console.WriteLine(er.Message);
			}
		}
		public static string Load(List<CellMap> CellList, string ReadPath)
		{
			try
			{
				using (StreamReader SR = new StreamReader(ReadPath, System.Text.Encoding.Default))
				{
					if (CellList != null) CellList.Clear();
					else CellList = new List<CellMap>();

					string Line;
					int Index = 0;

					ReadPath = SR.ReadLine();

					while ((Line = SR.ReadLine()) != null)
					{
						string[] Words = Line.Split(new char[] { ';' });
						string[] Prop = new string[] { Words[2], Words[3], Words[4] };

						CellList.Add(new CellMap(new AxialCoord(int.Parse(Words[0]), int.Parse(Words[1])), Prop));

						Index++;
					}

					SR.Close();
				}
			}
			catch (Exception er)
			{
				Console.WriteLine(er.Message);
			}

			return ReadPath;
		}

		public static void Sort(List<CellMap> Array) => Sort(Array, 0, Array.Count - 1);
		private static void Sort(List<CellMap> Array, int Left, int Right)
		{
			int LHold = Left;
			int RHold = Right;
			CellMap Middle = Array[Left + (Right - Left) / 2];

			while (LHold < RHold)
			{
				while (Middle.ID > Array[LHold].ID) LHold++;
				while (Middle.ID < Array[RHold].ID) RHold--;
				if (LHold <= RHold)
				{
					CellMap Buffer = Array[LHold];
					Array[LHold] = Array[RHold];
					Array[RHold] = Buffer;

					LHold++; RHold--;
				}
			}

			if (Left < RHold) Sort(Array, Left, RHold);
			if (LHold < Right) Sort(Array, LHold, Right);
		}

		public static CellMap Find(List<CellMap> Array, AxialCoord Coord) => Find(Array, Coord.x * 1000 + Coord.y, 0, Array.Count);
		private static CellMap Find(List<CellMap> Array, int Key, int Left, int Right)
		{
			int Middle;

			while (Left < Right)
			{
				Middle = Left + (Right - Left) / 2;

				if (Key < Array[Middle].ID) Right = Middle;
				else Left = Middle + 1;
			}

			Right--;

			if (Right == -1)
			{
				return new CellMap { Coords = new AxialCoord(0, 0), Properties = new string[] { "Water", "", "" }, State = -1 };
			}
			else if (Array[Right].ID == Key) return Array[Right];
			else
			{
				return new CellMap { Coords = new AxialCoord(0, 0), Properties = new string[] { "Water", "", "" }, State = -1 };
			}
		}

		public void SetProp(string[] Properties_)
		{
			Properties = Properties_;

			if (Properties_[1] != "") Road = true;
			if (Properties_[2] != "") River = true;

			LevelGround = 1;
			HeightTerrain = 1;
			StepCost = 1;

			switch (Properties_[0])
			{
				case "Desert": StepCost += 1; break;
				case "Forest": StepCost += 1; HeightTerrain += 2; break;
				case "Hill": StepCost += 1; LevelGround += 1; HeightTerrain += 1; break;
				case "Meadow": break;
				case "Mountain": StepCost += 2; LevelGround += 2; HeightTerrain += 2; break;
				case "Swamp": StepCost += 1; break;
				case "Tundra": StepCost += 1; break;
				case "Wasteland": break;
				case "Water": break;
			}

			if (River) StepCost += 1;
			if (Road) StepCost -= 1;
		}
		public void RemoveProp(bool Shift)
		{
			if (Shift) Properties = new string[3] { "", "", "" };
			else for (int i = 2; i >= 0; i--) if (Properties[i] != "")
					{
						Properties[i] = "";
						break;
					}
		}

		public bool IsBlockVision(CellMap prev) => prev.LevelGround >= HeightTerrain;

		public struct States
		{
			public static int Hidden => -1;
			public static int Shadow => 0;
			public static int Visible => 1;
		}

		public int? ID;
		public AxialCoord Coords;
		public string[] Properties;

		public int LevelGround;
		public int HeightTerrain;
		public int StepCost;

		public bool Road;
		public bool River;

		public int State;
	}
}