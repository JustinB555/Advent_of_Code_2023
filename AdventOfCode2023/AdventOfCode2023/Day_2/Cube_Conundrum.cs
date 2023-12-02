using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_2
{
	internal class Cube_Conundrum
	{
		static void Main()
		{
			int restult = CubeGames(false);
		}

		static int CubeGames(bool puzzle1)
		{
			string filePath = "C:\\Github\\Advent_of_Code_2023\\AdventOfCode2023\\AdventOfCode2023\\files\\Cube_Conundrum.txt";
			string fullText = "";
			int gameTotal = 0;

			if (File.Exists(filePath))
			{
				using (StreamReader sr = new StreamReader(filePath))
				{
					while (!sr.EndOfStream)
					{
						fullText = sr.ReadToEnd().ToString();
						string[] rows = fullText.Split('\n');
						if (puzzle1)
						{
							gameTotal = PossibleGames(rows);
						}
						else
						{
							gameTotal = FewestPossibleCubes(rows);
						}
					}
				}
			}

			return gameTotal;
		}

		static int PossibleGames(string[] rows)
		{
			int ret = 0;

			foreach (string row in rows)
			{
				bool breakout = false;
				string[] formattingGame = row.Split(':');
				string cleanGameNum = formattingGame[0].Replace("Game ", "");
				int gameNum = Convert.ToInt32(cleanGameNum);

				string[] formattingSet = formattingGame[1].Split(';');
				foreach (string set in formattingSet)
				{
					string[] pull = set.Split(',');
					foreach (string p in pull)
					{
						int num = 0;

						if (p.Contains("red"))
						{
							num = Convert.ToInt32(p.Replace(" red", "").Trim());
							if (num > 12)
							{
								breakout = true;
								break;
							}
						}
						else if (p.Contains("green"))
						{
							num = Convert.ToInt32(p.Replace(" green", "").Trim());
							if (num > 13)
							{
								breakout = true;
								break;
							}

						}
						else if (p.Contains("blue"))
						{
							num = Convert.ToInt32(p.Replace(" blue", "").Trim());
							if (num > 14)
							{
								breakout = true;
								break;
							}
						}
					}

					if (breakout)
					{
						break;
					}
				}

				if (!breakout)
				{
					ret += gameNum;
				}
			}

			return ret;
		}

		static int FewestPossibleCubes(string[] rows)
		{
			int ret = 0;

			foreach (string row in rows)
			{
				string[] formattingGame = row.Split(':');
				string[] formattingSet = formattingGame[1].Split(';');
				int red = 0;
				int green = 0;
				int blue = 0;

				foreach (string set in formattingSet)
				{
					string[] pull = set.Split(',');
					foreach (string p in pull)
					{
						int num = 0;

						if (p.Contains("red"))
						{
							num = Convert.ToInt32(p.Replace(" red", "").Trim());
							if (num > red)
							{
								red = num;
							}
						}
						else if (p.Contains("green"))
						{
							num = Convert.ToInt32(p.Replace(" green", "").Trim());
							if (num > green)
							{
								green = num;
							}

						}
						else if (p.Contains("blue"))
						{
							num = Convert.ToInt32(p.Replace(" blue", "").Trim());
							if (num > blue)
							{
								blue = num;
							}
						}
					}
				}
			
				ret += red * green * blue;
			}

			return ret;
		}

	}
}
