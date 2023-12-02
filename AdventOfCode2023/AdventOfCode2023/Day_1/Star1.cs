using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_1
{
	internal class Star1
	{
		//static void Main ()
		//{
		//	int results = CollectCalibrationData();

		//	Console.WriteLine(results);
		//}

		static int CollectCalibrationData()
		{
			string filePath = "C:/Github/Advent_of_Code_2023/AdventOfCode2023/AdventOfCode2023/files/Trebuchet_Calibration.txt";
			string fullText = "";
			int totalSum = 0;

			if (File.Exists(filePath))
			{
				using (StreamReader sr = new StreamReader(filePath))
				{
					while (!sr.EndOfStream)
					{
						fullText = sr.ReadToEnd().ToString();
						string convertingOne = ConvertText(fullText);
						string output = Regex.Replace(convertingOne, "[^0-9.\n]", "");
						string[] rows = output.Split('\n');
						int count = 0;
						for (int i = 0; i < rows.Length; i++)
						{
							var number = "";
							var single = "";
							var current = rows[i];
							if (rows[i].Length > 1)
							{
								number = $"{rows[i].Substring(0, 1)}{rows[i].Substring(rows[i].Length - 1)}";
								totalSum += Convert.ToInt32(number);
							}
							else
							{
								single = $"{rows[i]}{rows[i]}";
								totalSum += Convert.ToInt32(single);
							}
							var conditional = number != "" ? number : single;
							Console.WriteLine($"{count} | Rows: {current} | String: {conditional} | Total: {totalSum}");
							count++;
						}
					}
				}
			}

			return totalSum;
		}

		private static string ConvertText(string text)
		{
			string ret = text;
			Dictionary<string, string> formatText = new Dictionary<string, string>
			{
				{"oneight", "oneeight"},
				{"twone", "twoone"},
				{"threeight", "threeeight"},
				{"fiveight", "fiveeight"},
				{"sevenine", "sevennine"},
				{"eightwo", "eighttwo"},
				{"eighthree", "eightthree"},
				{"nineight", "nineeight"}
			};

			Dictionary<string, int> convertText = new Dictionary<string, int>
			{
				{"one", 1},
				{"two", 2},
				{"three", 3},
				{"four", 4},
				{"five", 5},
				{"six", 6},
				{"seven", 7},
				{"eight", 8},
				{"nine", 9}
			};

			foreach (KeyValuePair<string, string> ft in  formatText)
			{
				ret = Regex.Replace(ret, ft.Key, ft.Value);
			}

			foreach (KeyValuePair<string, int> ct in convertText)
			{
				ret = Regex.Replace(ret, ct.Key, ct.Value.ToString());
			}

			return ret;
		}
	}
}
