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
		public List<string> Data { get; set; }

		static void Main ()
		{
			CollectCalibrationData();
		}

		static List<string> CollectCalibrationData()
		{
			List<string> dt = new List<string>();
			string filePath = "C:/Github/Advent_of_Code_2023/AdventOfCode2023/AdventOfCode2023/files/Trebuchet_Calibration.txt";
			string fullText = "";

			if (File.Exists(filePath))
			{
				using (StreamReader sr = new StreamReader(filePath))
				{
					while (!sr.EndOfStream)
					{
						fullText = sr.ReadToEnd().ToString();
						string output = Regex.Replace(fullText, "[^0-9.\n]", "");
						string[] rows = output.Split('\n');
						for (int i = 0; i < rows.Length; i++)
						{
							
						}
					}
				}
			}

			return dt;
		}
	}
}
