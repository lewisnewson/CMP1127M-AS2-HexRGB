using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HexRGB
{
	class Program
	{
		static void Main(string[] args)
		{
			// Ask the user to enter a HEX value
			Console.Write("Please enter a HEX value: ");
			// Assign this to a variable
			var rawUserInp = Console.ReadLine();
			// Remove the hashtag if they've put it in
			var userInp = Regex.Replace(rawUserInp, @"(#)", "");
			// Make sure it's a valid HEX value
			while (userInp.Length != 6)
			{
				// Ask the user polietly to stop being awkward
				Console.Write("Try again, but behave yourself (hashtag allowed, 6 characters): ");
				// Assign this to a variable
				rawUserInp = Console.ReadLine();
				// Remove the hashtag if they've put it in
				userInp = Regex.Replace(rawUserInp, @"(#)", "");
			}
			if (userInp.Length <= 6)
			{
				// Declare a new list o hold the resulting RGB values
				List<int> values = new List<int>();
				// Loop 3 times, incrementing by 2 everytime to split the HEX string
				for (int i = 0; i < 6; i += 2)
				{
					// Convert the HEX to RGB with a built in function
					int rgb = int.Parse(userInp.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
					// Add the result of this to 'values' list
					values.Add(rgb);
				}
				// Show the user the converted values
				Console.WriteLine("\nOriginal:");
				Console.WriteLine("#{0} ({1}, {2}, {3}) \n", userInp.ToUpper(), values[0], values[1], values[2]);
				// Invert the RGB values bu subtracting them from 255
				var iR = 255 - values[0];
				var iG = 255 - values[1];
				var iB = 255 - values[2];
				// Use the converted RGB values for the HEX
				var invertedHex = string.Format("{0:X2}{1:X2}{2:X2}", iR, iG, iB);
				// Show the inverted colour
				Console.WriteLine("Inverted:");
				Console.WriteLine("#{0} ({1}, {2}, {3}) \n", invertedHex.ToUpper(), iR, iG, iB);
				// User the original values to generate a greyscale version
				decimal greyscale = (values[0] + values[1] + values[2]) / 3;
				// Output the greyscale value
				Console.WriteLine("Greyscale Value:");
				Console.WriteLine("{0} \n", greyscale);
				// Ask theuser for a threshold value
				Console.Write("Please enter a threshold value percentage from 0-100: ");
				// Parse the input as an integer and assign it to a variable
				int thresholdVal = int.Parse(Console.ReadLine());
				// Work out the percentage difference
				decimal percentageDiff = greyscale / 255 * 100;
				// If the difference is less than the threshold, the value becomes white
				if (percentageDiff <= thresholdVal)
				{
					Console.WriteLine("Color converted to Black (0)");
				}
				// Otherwise it'll become black
				else
				{
					Console.WriteLine("Color converted to White (255)");
				}
			}

			// Pause the program
			Console.ReadLine();
		}
	}
}
