using System;
using System.Collections.Generic;

namespace wta
{
	public class Scenario
	{
		public Scenario ( string name, string handle, int winPoints, int losePoints )
		{
			this.name = name;
			this.handle = handle;
			this.winPoints = winPoints;
			this.losePoints = losePoints;
		}

		public string name { get; private set; }
		public string handle { get; private set; }
		public int winPoints { get; private set; }
		public int losePoints { get; private set; }

		public bool isTeam { get { return handle.Contains( "team" ); }  }

		public override string ToString ()
		{
			return name;
		}

		static Scenario ()
		{
			All = new Dictionary<string, Scenario>();

			// No scenario
			Add( "Unknown 15", "xx15", 2, 1 );
			Add( "Unknown 25", "xx25", 2, 1 );
			Add( "Unknown 35", "xx35", 2, 1 );
			Add( "Unknown 50", "xx50", 3, 1 );
			Add( "Unknown 15 Team", "xx15team", 3, 2 );
			Add( "Unknown 25 Team", "xx25team", 3, 2 );
			Add( "Unknown 35 Team", "xx35team", 3, 2 );
			Add( "Unknown 50 Team", "xx50team", 4, 2 );

			// Occupy
			Add( "Occupy 15", "oc15", 3, 1 );
			Add( "Occupy 25", "oc25", 3, 1 );
			Add( "Occupy 35", "oc35", 3, 1 );
			Add( "Occupy 50", "oc50", 4, 1 );

			// Boom & Bust
			Add( "Boom or Bust 15", "bb15", 3, 1 );
			Add( "Boom or Bust 25", "bb25", 3, 1 );
			Add( "Boom or Bust 35", "bb35", 3, 1 );
			Add( "Boom or Bust 50", "bb50", 4, 1 );

			// Fight Club (2-player)
			Add( "Fight Club 15", "fc15", 2, 1 );
			Add( "Fight Club 25", "fc25", 2, 1 );
			Add( "Fight Club 35", "fc35", 2, 1 );
			Add( "Fight Club 50", "fc50", 3, 1 );

			// Fight Club (4-player)
			Add( "Fight Club 15 Team","fc15team", 3, 2 );
			Add( "Fight Club 25 Team","fc25team", 3, 2 );
			Add( "Fight Club 35 Team","fc35team", 3, 2 );
			Add( "Fight Club 50 Team","fc50team", 4, 2 );

			// Mosh Pit
			Add( "Mosh Pit 15", "mp15", 3, 1 );
			Add( "Mosh Pit 25", "mp25", 3, 1 );
			Add( "Mosh Pit 35", "mp35", 3, 1 );
			Add( "Mosh Pit 50", "mp50", 4, 1 );

			// Mosh Pit (4-player)
			Add( "Mosh Pit 15 Team", "mp15team", 4, 2 );
			Add( "Mosh Pit 25 Team", "mp25team", 4, 2 );
			Add( "Mosh Pit 35 Team", "mp35team", 4, 2 );
			Add( "Mosh Pit 50 Team", "mp50team", 5, 2 );

			// King of the Hill (2-player)
			Add( "King of the Hill 15", "kh25", 2, 1 );
			Add( "King of the Hill 25", "kh15", 2, 1 );
			Add( "King of the Hill 35", "kh35", 2, 1 );
			Add( "King of the Hill 50", "kh50", 3, 1 );

			// King of the Hill (4-player)
			Add( "King of the Hill 15 Team", "kh15team", 3, 2 );
			Add( "King of the Hill 25 Team", "kh25team", 3, 2 );
			Add( "King of the Hill 35 Team", "kh35team", 3, 2 );
			Add( "King of the Hill 50 Team", "kh50team", 4, 2 );

			// Encroachment
			Add( "Encroachment 15", "en15", 3, 1 );
			Add( "Encroachment 25", "en25", 3, 1 );
			Add( "Encroachment 35", "en35", 3, 1 );
			Add( "Encroachment 50", "en50", 4, 1 );

			// Confinement
			Add( "Confinement 15", "co15", 3, 1 );
			Add( "Confinement 25", "co25", 3, 1 );
			Add( "Confinement 35", "co35", 3, 1 );
			Add( "Confinement 50", "co50", 4, 1 );

			// Unlikely Alliance (4-player)
			Add( "Unlikely Alliances 15 Team", "ua15team", 3, 2 );
			Add( "Unlikely Alliances 25 Team", "ua25team", 3, 2 );
			Add( "Unlikely Alliances 35 Team", "ua35team", 3, 2 );
			Add( "Unlikely Alliances 50 Team", "ua50team", 4, 2 );

			// Whirling Gauntlet
			Add( "Whirling Gauntlet 15", "wg15", 2, 1 );
			Add( "Whirling Gauntlet 25", "wg25", 2, 1 );
			Add( "Whirling Gauntlet 35", "wg35", 2, 1 );
			Add( "Whirling Gauntlet 50", "wg50", 3, 1 );

			// Black Spot (4-player)
			Add( "Black Spot 15 Team", "bs15team", 3, 2 );
			Add( "Black Spot 25 Team", "bs25team", 3, 2 );
			Add( "Black Spot 35 Team", "bs35team", 3, 2 );
			Add( "Black Spot 50 Team", "bs50team", 4, 2 );

			// No-man's Land
			Add( "No-Man's Land 15", "nm15", 2, 1 );
			Add( "No-Man's Land 25", "nm25", 2, 1 );
			Add( "No-Man's Land 35", "nm35", 2, 1 );
			Add( "No-Man's Land 50", "nm50", 3, 1 );

			// Onslaught
			Add( "Onslaught 15", "on15", 2, 1 );
			Add( "Onslaught 25", "on25", 2, 1 );
			Add( "Onslaught 35", "on35", 2, 1 );
			Add( "Onslaught 50", "on50", 3, 1 );
		}

		public static Scenario Find (string handle)
		{ 
			return All[handle];
		}

		private static void Add( string name, string handle, int winPoints, int losePoints )
		{
			All.Add( handle, new Scenario( name, handle, winPoints, losePoints ) );
		}

		private static Dictionary<string, Scenario> All;
	}
}
