//// Generated code -- CC0 -- No Rights Reserved -- http://www.redblobgames.com/grids/hexagons/

//using System;
//using System.Collections.Generic;
//using System.Drawing;

//namespace Hexa
//{
//	// Tests
//	struct Tests
//	{

//		static public void EqualHex(string name, CubeCoord a, CubeCoord b)
//		{
//			if (!(a.q == b.q && a.s == b.s && a.r == b.r))
//			{
//				Complain(name);
//			}
//		}


//		static public void EqualOffsetcoord(string name, OffsetCoord a, OffsetCoord b)
//		{
//			if (!(a.col == b.col && a.row == b.row))
//			{
//				Complain(name);
//			}
//		}


//		static public void EqualDoubledcoord(string name, DoubledCoord a, DoubledCoord b)
//		{
//			if (!(a.col == b.col && a.row == b.row))
//			{
//				Complain(name);
//			}
//		}


//		static public void EqualInt(string name, int a, int b)
//		{
//			if (!(a == b))
//			{
//				Complain(name);
//			}
//		}


//		static public void EqualHexArray(string name, List<CubeCoord> a, List<CubeCoord> b)
//		{
//			EqualInt(name, a.Count, b.Count);
//			for (int i = 0; i < a.Count; i++)
//			{
//				EqualHex(name, a[i], b[i]);
//			}
//		}


//		static public void TestHexArithmetic()
//		{
//			EqualHex("hex_add", new CubeCoord(4, -10, 6), new CubeCoord(1, -3, 2).Add(new CubeCoord(3, -7, 4)));
//			EqualHex("hex_subtract", new CubeCoord(-2, 4, -2), new CubeCoord(1, -3, 2).Subtract(new CubeCoord(3, -7, 4)));
//		}


//		static public void TestHexDirection()
//		{
//			EqualHex("hex_direction", new CubeCoord(0, -1, 1), CubeCoord.Direction(2));
//		}


//		static public void TestHexNeighbor()
//		{
//			EqualHex("hex_neighbor", new CubeCoord(1, -3, 2), new CubeCoord(1, -2, 1).Neighbor(2));
//		}


//		static public void TestHexDiagonal()
//		{
//			EqualHex("hex_diagonal", new CubeCoord(-1, -1, 2), new CubeCoord(1, -2, 1).DiagonalNeighbor(3));
//		}


//		static public void TestHexDistance()
//		{
//			EqualInt("hex_distance", 7, new CubeCoord(3, -7, 4).Distance(new CubeCoord(0, 0, 0)));
//		}


//		static public void TestHexRotateRight()
//		{
//			EqualHex("hex_rotate_right", new CubeCoord(1, -3, 2).RotateRight(), new CubeCoord(3, -2, -1));
//		}


//		static public void TestHexRotateLeft()
//		{
//			EqualHex("hex_rotate_left", new CubeCoord(1, -3, 2).RotateLeft(), new CubeCoord(-2, -1, 3));
//		}


//		static public void TestHexRound()
//		{
//			FractionalHex a = new FractionalHex(0.0, 0.0, 0.0);
//			FractionalHex b = new FractionalHex(1.0, -1.0, 0.0);
//			FractionalHex c = new FractionalHex(0.0, -1.0, 1.0);
//			EqualHex("hex_round 1", new CubeCoord(5, -10, 5), new FractionalHex(0.0, 0.0, 0.0).HexLerp(new FractionalHex(10.0, -20.0, 10.0), 0.5).HexRound());
//			EqualHex("hex_round 2", a.HexRound(), a.HexLerp(b, 0.499).HexRound());
//			EqualHex("hex_round 3", b.HexRound(), a.HexLerp(b, 0.501).HexRound());
//			EqualHex("hex_round 4", a.HexRound(), new FractionalHex(a.q * 0.4 + b.q * 0.3 + c.q * 0.3, a.r * 0.4 + b.r * 0.3 + c.r * 0.3, a.s * 0.4 + b.s * 0.3 + c.s * 0.3).HexRound());
//			EqualHex("hex_round 5", c.HexRound(), new FractionalHex(a.q * 0.3 + b.q * 0.3 + c.q * 0.4, a.r * 0.3 + b.r * 0.3 + c.r * 0.4, a.s * 0.3 + b.s * 0.3 + c.s * 0.4).HexRound());
//		}


//		static public void TestHexLinedraw()
//		{
//			EqualHexArray("hex_linedraw", new List<CubeCoord> { new CubeCoord(0, 0, 0), new CubeCoord(0, -1, 1), new CubeCoord(0, -2, 2), new CubeCoord(1, -3, 2), new CubeCoord(1, -4, 3), new CubeCoord(1, -5, 4) }, FractionalHex.HexLinedraw(new CubeCoord(0, 0, 0), new CubeCoord(1, -5, 4)));
//		}


//		static public void TestLayout()
//		{
//			CubeCoord h = new CubeCoord(3, 4, -7);
//			Layout flat = new Layout(Layout.flat, new Size(10, 15), new PointF(35.0f, 71.0f));
//			EqualHex("layout", h, flat.PixelToHex(flat.HexToPixel(h)).HexRound());
//			Layout pointy = new Layout(Layout.pointy, new Size(10, 15), new PointF(35.0f, 71.0f));
//			EqualHex("layout", h, pointy.PixelToHex(pointy.HexToPixel(h)).HexRound());
//		}


//		static public void TestOffsetRoundtrip()
//		{
//			CubeCoord a = new CubeCoord(3, 4, -7);
//			OffsetCoord b = new OffsetCoord(1, -3);
//			EqualHex("conversion_roundtrip even-q", a, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, a)));
//			EqualOffsetcoord("conversion_roundtrip even-q", b, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, b)));
//			EqualHex("conversion_roundtrip odd-q", a, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, a)));
//			EqualOffsetcoord("conversion_roundtrip odd-q", b, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, b)));
//			EqualHex("conversion_roundtrip even-r", a, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, a)));
//			EqualOffsetcoord("conversion_roundtrip even-r", b, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, b)));
//			EqualHex("conversion_roundtrip odd-r", a, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, a)));
//			EqualOffsetcoord("conversion_roundtrip odd-r", b, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, b)));
//		}


//		static public void TestOffsetFromCube()
//		{
//			EqualOffsetcoord("offset_from_cube even-q", new OffsetCoord(1, 3), OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, new CubeCoord(1, 2, -3)));
//			EqualOffsetcoord("offset_from_cube odd-q", new OffsetCoord(1, 2), OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, new CubeCoord(1, 2, -3)));
//		}


//		static public void TestOffsetToCube()
//		{
//			EqualHex("offset_to_cube even-", new CubeCoord(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, new OffsetCoord(1, 3)));
//			EqualHex("offset_to_cube odd-q", new CubeCoord(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.ODD, new OffsetCoord(1, 2)));
//		}


//		static public void TestDoubledRoundtrip()
//		{
//			CubeCoord a = new CubeCoord(3, 4, -7);
//			DoubledCoord b = new DoubledCoord(1, -3);
//			EqualHex("conversion_roundtrip doubled-q", a, DoubledCoord.QdoubledFromCube(a).QdoubledToCube());
//			EqualDoubledcoord("conversion_roundtrip doubled-q", b, DoubledCoord.QdoubledFromCube(b.QdoubledToCube()));
//			EqualHex("conversion_roundtrip doubled-r", a, DoubledCoord.RdoubledFromCube(a).RdoubledToCube());
//			EqualDoubledcoord("conversion_roundtrip doubled-r", b, DoubledCoord.RdoubledFromCube(b.RdoubledToCube()));
//		}


//		static public void TestDoubledFromCube()
//		{
//			EqualDoubledcoord("doubled_from_cube doubled-q", new DoubledCoord(1, 5), DoubledCoord.QdoubledFromCube(new CubeCoord(1, 2, -3)));
//			EqualDoubledcoord("doubled_from_cube doubled-r", new DoubledCoord(4, 2), DoubledCoord.RdoubledFromCube(new CubeCoord(1, 2, -3)));
//		}


//		static public void TestDoubledToCube()
//		{
//			EqualHex("doubled_to_cube doubled-q", new CubeCoord(1, 2, -3), new DoubledCoord(1, 5).QdoubledToCube());
//			EqualHex("doubled_to_cube doubled-r", new CubeCoord(1, 2, -3), new DoubledCoord(4, 2).RdoubledToCube());
//		}


//		static public void TestAll()
//		{
//			TestHexArithmetic();
//			TestHexDirection();
//			TestHexNeighbor();
//			TestHexDiagonal();
//			TestHexDistance();
//			TestHexRotateRight();
//			TestHexRotateLeft();
//			TestHexRound();
//			TestHexLinedraw();
//			TestLayout();
//			TestOffsetRoundtrip();
//			TestOffsetFromCube();
//			TestOffsetToCube();
//			TestDoubledRoundtrip();
//			TestDoubledFromCube();
//			TestDoubledToCube();
//		}


//		static public void Start()
//		{
//			TestAll();
//		}


//		static public void Complain(string name)
//		{
//			Console.WriteLine("FAIL " + name);
//		}

//	}
//}