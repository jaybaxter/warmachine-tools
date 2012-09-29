using System;
using System.Collections.Generic;

namespace wta
{
	public class Game
	{
		public static Game create( string gamecode )
		{
			var tokens = gamecode.Split( new[] { ' ' } );
			Scenario scenario;
			try
			{ 
				scenario = Scenario.Find( tokens[1] );
			}
			catch
			{
				System.Console.WriteLine ( "No scenario named " + tokens[1] );
				return null;
			}
			var game = new Game( scenario );

			game.date = tokens[0];

			for ( int i = 2; i < tokens.Length; ++i )
			{
				var token = tokens[i];
				if ( token.StartsWith( "w:" ) )
				{
					var playerName = token.Substring( 2 );
					var player = Player.find( playerName );
					game.addWinner( player );
				}
				if ( token.StartsWith( "l:" ) )
				{
					var playerName = token.Substring( 2 );
					var player = Player.find( playerName );
					game.addLoser( player );
				}
			}

			return game;
		}

		public Game ( Scenario s )
		{
			id = nextID;
			scenario = s;
			winners = new List<Player>();
			losers = new List<Player>();
		}

		public void addWinner ( Player player ) { winners.Add( player ); }
		public void addLoser ( Player player ) { losers.Add( player ); }

		public void score ()
		{
			if ( scored )
				return;
			scored = true;

			foreach ( var winner in winners )
				winner.addWin( this );
			foreach ( var loser in losers )
				loser.addLoss( this );

			if ( Alliance.allied( winners ) )
				foreach ( var player in winners )
					player.addAllyPoint();
			
			if ( Alliance.allied( losers ) )
				foreach ( var player in losers )
					player.addAllyPoint();
		}

		private bool scored;
		public int id { get; private set; }
		public string date { get; set; }
		public Scenario scenario { get; private set; }
		public List<Player> winners { get; private set; }
		public List<Player> losers { get; private set; }

		private static int nextID { get { return ++nextID_; } }
		private static int nextID_;

		private string join<T>( string joiner, List<T> items )
		{
			int count = 0;
			var result = "";
			foreach ( var item in items )
			{
				if ( count++ > 0 )
					result += joiner;
				result += item.ToString();
			}
			return result;
		}

		public override string ToString ()
		{
			var winnersWithPoints = new List<string>();
			foreach ( var player in winners )
				winnersWithPoints.Add( 
					String.Format( "{0}({1}{2})", player.name, scenario.winPoints, Alliance.allied( winners ) ? "+ally" : "" ) );

			var losersWithPoints = new List<string>();
			foreach ( var player in losers )
				losersWithPoints.Add( 
					String.Format( "{0}({1}{2})", player.name, scenario.losePoints, Alliance.allied( losers ) ? "+ally" : "" ) );

			return 
				string.Format(
					"#{0} {1} {2}, W={3} L={4}", 
					id, 
					date,
					scenario, 
					join<string>( ",", winnersWithPoints ), 
					join<string>( ",", losersWithPoints ) );
		}
	}
}
