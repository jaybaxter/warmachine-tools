using System;
using System.Collections.Generic;

namespace wta
{
	public class Alliance
	{
		public static void add( string a, string b )
		{
			var f1 = Faction.find( a );
			var f2 = Faction.find( b );
			allianceMap_[f1] = f2;
			allianceMap_[f2] = f1;
		}

		public static Faction allyFor( Faction faction )
		{
			Faction ally;
			return allianceMap_.TryGetValue( faction, out ally ) ? ally : null;
		}

		public static bool allied( Faction a, Faction b )
		{
			Faction other;
			return allianceMap_.TryGetValue( a, out other ) && other == b;
		}

		public static bool allied( List<Player> players )
		{
			return players.Count == 2 && allied( players[0].faction, players[1].faction );
		}

		private static Dictionary<Faction, Faction> allianceMap_ =
			new Dictionary<Faction, Faction>();
	}
}
