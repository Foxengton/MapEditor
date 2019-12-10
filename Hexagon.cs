using System;
using System.Collections.Generic;
using System.Drawing;

namespace MapEditor
{
	public class Hexagon
	{
		public Hexagon(int SizeHex, bool flat = true)
		{
			size = new Size(SizeHex, SizeHex);

			if (flat) orientation = Orientation.flat;
			else orientation = Orientation.pointy;
		}

		public Point HexToPixel(CubeCoord cube, Point offset)
		{
			Orientation M = orientation;
			int x = (int)Math.Round((M.f0 * cube.q + M.f1 * cube.r) * size.Width);
			int y = (int)Math.Round((M.f2 * cube.q + M.f3 * cube.r) * size.Height);
			return new Point(x + offset.X, y + offset.Y);
		}
		public CubeCoord PixelToHex(PointF PtF, Point offset)
		{
			Orientation M = orientation;
			PointF pt = new PointF((PtF.X - offset.X) / size.Width, (PtF.Y - offset.Y) / size.Width);
			float q = (float)(M.b0 * pt.X + M.b1 * pt.Y);
			float r = (float)(M.b2 * pt.X + M.b3 * pt.Y);
			return new FractionalCoord(q, r, -q - r).ToCube();
		}

		public Point Draw(object Coord)
		{
			if (Coord.GetType().Name == "Point") return HexToPixel(new AxialCoord((Point)Coord).ToCube(), new Point(0,0));
			else if (Coord.GetType().Name == "AxialCoord") return HexToPixel(((AxialCoord)Coord).ToCube(), new Point(0, 0));
			else if (Coord.GetType().Name == "CubeCoord") return HexToPixel((CubeCoord)Coord, new Point(0, 0));
			return new Point();
		}
		public Point Draw(object Coord, Point offset)
		{
			if (Coord.GetType().Name == "Point") return HexToPixel(new AxialCoord((Point)Coord).ToCube(), offset);
			else if (Coord.GetType().Name == "AxialCoord") return HexToPixel(((AxialCoord)Coord).ToCube(), offset);
			else if (Coord.GetType().Name == "CubeCoord") return HexToPixel((CubeCoord)Coord, offset);
			return new Point();
		}
		public PointF[] DrawPolygon(CubeCoord cube, Point offset)
		{
			Orientation M = orientation;
			PointF[] corners = new PointF[6];
			PointF center = HexToPixel(cube, offset);

			for (int i = 0; i < 6; i++)
			{
				double angle = 2.0 * Math.PI * (M.start_angle - i) / 6.0;
				PointF offset_ = new PointF(size.Width * (float)Math.Cos(angle), size.Height * (float)Math.Sin(angle));
				corners[i] = new PointF(center.X + offset_.X, center.Y + offset_.Y);
			}

			return corners;
		}

		public AxialCoord[] СubeSpiral(AxialCoord center, int Radius)
		{
			List<AxialCoord> Coords = new List<AxialCoord> { center };
			for (int i = 1; i < Radius; i++)
				Coords.AddRange(СubeRing(center, i));

			AxialCoord[] Result = new AxialCoord[Coords.Count];
			for (int i = 0; i < Result.Length; i++)
				Result[i] = Coords[i];

			return Result;
		}
		public AxialCoord[] СubeRing(AxialCoord center, int Radius)
		{
			AxialCoord[] Coords = new AxialCoord[Radius * 6];

			CubeCoord cube = new CubeCoord().Neighbor(4).Scale(Radius).Add(center.ToCube());

			int Index = 0;

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < Radius; j++)
				{
					Coords[Index] = new AxialCoord(cube.q, cube.r);

					cube = cube.Neighbor(i);
					Index++;
				}
			}

			return Coords;
		}

		public struct Orientation
		{
			public Orientation(double f0, double f1, double f2, double f3, double b0, double b1, double b2, double b3, double start_angle)
			{
				this.f0 = f0;
				this.f1 = f1;
				this.f2 = f2;
				this.f3 = f3;
				this.b0 = b0;
				this.b1 = b1;
				this.b2 = b2;
				this.b3 = b3;
				this.start_angle = start_angle;
			}
			public readonly double f0;
			public readonly double f1;
			public readonly double f2;
			public readonly double f3;
			public readonly double b0;
			public readonly double b1;
			public readonly double b2;
			public readonly double b3;
			public readonly double start_angle;

			static public Orientation pointy = new Orientation(Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0, Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0, 0.5);
			static public Orientation flat = new Orientation(3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0), 2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0, 0.0);
		}
		public readonly Orientation orientation;
		public readonly Size size;
		public readonly int Directions = 6;
	}

	public struct AxialCoord
	{
		public AxialCoord(Point Pt)
		{
			x = Pt.X;
			y = Pt.Y;
		}
		public AxialCoord(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public readonly int x;
		public readonly int y;

		public override string ToString() => $"[{x}; {y}]";

		public Point ToPixel() => new Point(x, y);
		public CubeCoord ToCube() => new CubeCoord(x, y, -x - y);

		public AxialCoord Add(AxialCoord other) => new AxialCoord(x + other.x, y + other.y);
		public AxialCoord Subtract(AxialCoord other) => new AxialCoord(x - other.x, y - other.y);
		public AxialCoord Scale(int k) => new AxialCoord(x * k, y * k);

		public AxialCoord Neighbor(int direction) => Add(directions[direction]);
		public static AxialCoord[] directions = new AxialCoord[] { new AxialCoord(1, 0), new AxialCoord(0, -1), new AxialCoord(-1, 0), new AxialCoord(0, 1)};

		public AxialCoord DiagonalNeighbor(int direction) => Add(diagonals[direction]);
		static public AxialCoord[] diagonals = new AxialCoord[] { new AxialCoord(1, 1), new AxialCoord(1, -1), new AxialCoord(-1, -1), new AxialCoord(-1, 1)};

		public int Length() => (Math.Abs(x) + Math.Abs(y)) / 2;
		public int Distance(AxialCoord b) => Subtract(b).Length();

	}

	public struct CubeCoord
	{
		public CubeCoord(Point Pt)
		{
			q = Pt.X;
			r = Pt.Y;
			s = -Pt.X - Pt.Y;
			if (q + r + s != 0) throw new ArgumentException("q + r + s must be 0");
		}
		public CubeCoord(int x, int y)
		{
			q = x;
			r = y;
			s = -x - y;
			if (q + r + s != 0) throw new ArgumentException("q + r + s must be 0");
		}
		public CubeCoord(int q, int r, int s)
		{
			this.q = q;
			this.r = r;
			this.s = s;
			if (q + r + s != 0) throw new ArgumentException("q + r + s must be 0");
		}
		public readonly int q;
		public readonly int r;
		public readonly int s;

		public override string ToString() => $"[{q}; {r}; {s}]";

		public bool Equals(CubeCoord other)
		{
			if (q == other.q && r == other.r) return true;

			return false;
		}

		public AxialCoord ToAxial() => new AxialCoord(q, r);
		public Point ToPixel() => new Point(q, r);
		public DoubledCoord ToRdoubled() => new DoubledCoord(2 * q + r, r);
		public DoubledCoord ToQdoubled() => new DoubledCoord(q, 2 * r + q);


		public CubeCoord Add(CubeCoord other) => new CubeCoord(q + other.q, r + other.r, s + other.s);
		public CubeCoord Subtract(CubeCoord other) => new CubeCoord(q - other.q, r - other.r, s - other.s);
		public CubeCoord Scale(int k) => new CubeCoord(q * k, r * k, s * k);

		public CubeCoord RotateLeft() => new CubeCoord(-s, -q, -r);
		public CubeCoord RotateRight() => new CubeCoord(-r, -s, -q);

		public enum Directions
		{
			Up = 0,
			UpRight = 1,
			DownRight = 2,
			Down = 3,
			DownLeft = 4,
			UpLeft = 5
		}

		public CubeCoord Neighbor(int direction) => Add(directions[direction]);
		public static CubeCoord[] directions = new CubeCoord[] { new CubeCoord(0, -1, 1), new CubeCoord(1, -1, 0), new CubeCoord(1, 0, -1), new CubeCoord(0, 1, -1), new CubeCoord(-1, 1, 0), new CubeCoord(-1, 0, 1) };

		public CubeCoord DiagonalNeighbor(int direction) => Add(diagonals[direction]);
		public static CubeCoord[] diagonals = new CubeCoord[] { new CubeCoord(-1, -1, 2), new CubeCoord(1, -2, 1), new CubeCoord(2, -1, -1), new CubeCoord(1, 1, -2), new CubeCoord(-1, 2, -1), new CubeCoord(-2, 1, 1) };

		public int Length() => (Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2;
		public int Distance(CubeCoord b) => Subtract(b).Length();
	}

	public struct FractionalCoord
	{
		public FractionalCoord(float q, float r, float s)
		{
			this.q = q;
			this.r = r;
			this.s = s;
			if (Math.Round(q + r + s) != 0) throw new ArgumentException("q + r + s must be 0");
		}
		public FractionalCoord(float q, float r)
		{
			this.q = q;
			this.r = r;
			this.s = -q - r;
			if (Math.Round(q + r + s) != 0) throw new ArgumentException("q + r + s must be 0");
		}
		public readonly float q;
		public readonly float r;
		public readonly float s;

		public AxialCoord ToAxial()
		{
			int qi = (int)Math.Round(q);
			int ri = (int)Math.Round(r);
			int si = (int)Math.Round(s);
			double q_diff = Math.Abs(qi - q);
			double r_diff = Math.Abs(ri - r);
			double s_diff = Math.Abs(si - s);
			if (q_diff > r_diff && q_diff > s_diff)
			{
				qi = -ri - si;
			}
			else
				if (r_diff > s_diff)
			{
				ri = -qi - si;
			}
			else
			{
				si = -qi - ri;
			}
			return new AxialCoord(qi, si);
		}
		public CubeCoord ToCube()
		{
			int qi = (int)Math.Round(q);
			int ri = (int)Math.Round(r);
			int si = (int)Math.Round(s);
			double q_diff = Math.Abs(qi - q);
			double r_diff = Math.Abs(ri - r);
			double s_diff = Math.Abs(si - s);
			if (q_diff > r_diff && q_diff > s_diff)
			{
				qi = -ri - si;
			}
			else
				if (r_diff > s_diff)
			{
				ri = -qi - si;
			}
			else
			{
				si = -qi - ri;
			}
			return new CubeCoord(qi, ri, si);
		}
		public FractionalCoord HexLerp(FractionalCoord b, float t)
		{
			return new FractionalCoord(q * (1F - t) + b.q * t, r * (1F - t) + b.r * t, s * (1F - t) + b.s * t);
		}
		static public List<CubeCoord> HexLinedraw(CubeCoord a, CubeCoord b)
		{
			int N = a.Distance(b);
			FractionalCoord a_nudge = new FractionalCoord(a.q + 0.000001F, a.r + 0.000001F, a.s - 0.000002F);
			FractionalCoord b_nudge = new FractionalCoord(b.q + 0.000001F, b.r + 0.000001F, b.s - 0.000002F);
			List<CubeCoord> results = new List<CubeCoord> { };
			float step = 1F / Math.Max(N, 1);
			for (int i = 0; i <= N; i++)
			{
				results.Add(a_nudge.HexLerp(b_nudge, step * i).ToCube());
			}
			return results;
		}
	}

	public struct OffsetCoord
	{
		public OffsetCoord(int col, int row)
		{
			this.col = col;
			this.row = row;
		}
		public readonly int col;
		public readonly int row;
		static public int EVEN = 1;
		static public int ODD = -1;

		static public OffsetCoord CubeToQoffset(int shift, CubeCoord cube)
		{
			int col = cube.q;
			int row = cube.r + (cube.q + shift * (cube.q & 1)) / 2;
			return new OffsetCoord(col, row);
		}
		static public CubeCoord QoffsetToCube(int shift, OffsetCoord offset)
		{
			int q = offset.col;
			int r = offset.row - (offset.col + shift * (offset.col & 1)) / 2;
			int s = -q - r;
			return new CubeCoord(q, r, s);
		}

		static public OffsetCoord CubeToRoffset(int shift, CubeCoord cube)
		{
			int col = cube.q + (cube.r + shift * (cube.r & 1)) / 2;
			int row = cube.r;
			return new OffsetCoord(col, row);
		}
		static public CubeCoord RoffsetToCube(int shift, OffsetCoord offset)
		{
			int q = offset.col - (offset.row + shift * (offset.row & 1)) / 2;
			int r = offset.row;
			int s = -q - r;
			return new CubeCoord(q, r, s);
		}
	}

	public struct DoubledCoord
	{
		public DoubledCoord(int col, int row)
		{
			this.col = col;
			this.row = row;
		}
		public readonly int col;
		public readonly int row;

		public CubeCoord QdoubledToCube()
		{
			int q = col;
			int r = (row - col) / 2;
			int s = -q - r;
			return new CubeCoord(q, r, s);
		}

		public CubeCoord RdoubledToCube()
		{
			int q = (col - row) / 2;
			int r = row;
			int s = -q - r;
			return new CubeCoord(q, r, s);
		}
	}
}