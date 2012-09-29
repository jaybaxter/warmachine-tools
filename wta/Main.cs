using System;
using System.Collections.Generic;

namespace wta
{
	class League
	{
		public static void LoadAlliances ( string path )
		{
			var lines = System.IO.File.ReadAllLines( path );
			foreach ( var line in lines )
			{
				var tokens = line.Split( new[] { ':' } );
				Alliance.add( tokens[0], tokens[1] );
			}
		}

		public static void LoadPlayers ( string path )
		{
			var lines = System.IO.File.ReadAllLines( path );
			foreach ( var line in lines )
			{
				var tokens = line.Split( new[] { ':' } );
				var faction = Faction.find( tokens[1] );
				Player.add( tokens[0], faction );
			}
		}

		public static void LoadGames ( string path )
		{
			var lines = System.IO.File.ReadAllLines( path );
			foreach ( var line in lines )
			{
				if ( String.IsNullOrEmpty( line ) )
					continue;
				if ( line.StartsWith( "#" ) )
					continue;
				var game = Game.create( line );
				if ( game != null )
					game.score();
			}
		}

		public static void ReportScores ()
		{
			var sortedPlayers = new List<Player>( Player.All.Values );
			sortedPlayers.Sort( (a,b) => a.points.CompareTo( b.points ) );
			sortedPlayers.Reverse();

			foreach ( var player in sortedPlayers )
			{
				System.Console.WriteLine( 
					String.Format( 
						"\n{0}/{1} -- {2} points ({3}-{4}) {5}", 
						player.name, 
						player.faction, 
						player.points, 
						player.wins, 
						player.losses,
						player.allyPoints >= 2 ? " -- Alliance Patch" : "" ) );

				foreach ( var game in player.games )
					System.Console.WriteLine( "    " + game );
			}
		}

		public static void Main ( string[] args )
		{
			try
			{
				// TODO: These path should be parameterized from the command line
				LoadAlliances( "../../Data/olgunholt/alliances.txt" );
				LoadPlayers( "../../Data/olgunholt/players.txt" );
				LoadGames( "../../Data/olgunholt/games.txt" );

				ReportScores();
			}
			catch ( IndexOutOfRangeException ex )
			{
				Console.WriteLine( "Please specify the game data file on the command line: ", ex.Message );
			}
		}
	}
}
