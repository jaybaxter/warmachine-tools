using System;
using System.Collections.Generic;

namespace wta
{
	class League
	{
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
				System.Console.WriteLine();
				System.Console.WriteLine( String.Format( "{0} {1} ({2}-{3})", player.name, player.points, player.wins, player.losses ) );
				foreach ( var game in player.games )
					System.Console.WriteLine( "    " + game );
			}
		}

		public static void Main ( string[] args )
		{
			LoadGames( "../../Data/games.txt" );
			ReportScores();
		}
	}
}
