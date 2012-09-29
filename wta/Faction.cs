using System;
using System.Collections.Generic;

namespace wta
{
	public class Faction : IComparable
	{
		public Faction ( string name )
		{ 
			Name = name;
			factions_[name.ToLower()] = this;
		}

		public string Name { get; private set; }

		public Faction Ally { get; set; }

		public int CompareTo( object other )
		{ 
			var faction = other as Faction;
			if ( other != null ) 
				return Name.ToLower().CompareTo( faction.Name.ToLower() );

			var str = other as String;
			if ( other != null )
				return Name.ToLower().CompareTo( str.ToLower() );

			return 1;
		}

		public static Faction find ( string name )
		{
			Faction faction;
			if ( factions_.TryGetValue( name.ToLower(), out faction ) )
				return faction;

			faction = new Faction( name );
			factions_[name.ToLower()] = faction;
			return faction;
		}

		public override string ToString () { return Name; }

		private static Dictionary<string, Faction> factions_ = 
			new Dictionary<string, Faction>();
	}
}
