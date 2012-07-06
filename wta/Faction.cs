using System;

namespace wta
{

	public class Faction : IComparable
	{
#if false 
		static Faction () {}
		private static Faction cryx, cygnar, khador, protectorate, retribution, mercs;
		private static Faction circle, legion, skorne, trolls, minions;
#endif
		public Faction ( string name ) { Name = name; }

		public string Name { get; private set; }

		public Faction Ally { get; set; }

		public int CompareTo( object other )
		{ 
			var faction = other as Faction;
			if ( other == null ) 
				return 1;
			return Name.CompareTo( faction.Name );
		}
	}
}

