using System;
using System.Collections.Generic;

namespace wta
{
	public class Player
	{
		public Player ( string name )
		{
			this.name = name;
			games = new List<Game>();
		}

		public static void add ( string name, Faction faction )
		{
			var player = find ( name );
			if ( player != null )
				player.faction = faction;
		}

		public void addWin ( Game game )
		{
			wins++;
			games.Add( game );
			points += game.scenario.winPoints;
			if ( game.scenario.isTeam )
				teamGames++;
		}

		public void addLoss ( Game game )
		{
			losses++;
			games.Add( game );
			points += game.scenario.losePoints;
			if ( game.scenario.isTeam )
				teamGames++;
		}

		public void addAllyPoint ()
		{
			allyPoints += 1;
		}

		public string name { get; private set; }
		public Faction faction { get; set; }
		public int points { get; private set; }
		public int allyPoints { get; private set; }

		public int wins { get; private set; }
		public int losses { get; private set; }
		public int teamGames { get; private set; }

		public List<Game> games { get; private set; }

		public override string ToString () { return name; }

		public static Player find ( string handle )
		{ 
			Player player;
			handle = handle.ToLower();
			if ( All.TryGetValue( handle, out player ) )
				return player;
			player = new Player( handle );
			All.Add( handle, player );
			return player;
		}

		public static Dictionary<string, Player> All = 
			new Dictionary<string, Player>();
	}
}

