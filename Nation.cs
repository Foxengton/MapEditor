using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
	public class Nation
	{
		public Nation(AxialCoord BaseCoord)
		{
			Vision = new List<CellMap>();
		}

		public void Update()
		{
			Army.VisionPoint = 3;
		}

		public void AddUnit()
		{

		}

		public struct SUnit
		{
			public int VisionPoint;
			public AxialCoord Coord;
		}

		public AxialCoord NationCoord;

		public string TypeNation;
		public string NameNation;

		public int Experience, ExperienceMax, ExperienceGlobal;
		public int PopulationCell;

		public int RiskWinter;
		public int RiskFamine;
		public int RiskRevolution;

		public int Gold;
		public SUnit Army;
		public List<CellMap> Vision;
	}
}