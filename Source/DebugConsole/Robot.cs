﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DebugConsole
{
	internal class Robot
	{
		const double DrainRate = .01;
		public string Name { get; set; }
		public double BatteryLevel { get; set; }
		public ConsoleColor LaserColor { get; set; }

		// low WorkEfficiency means the robot can work
		// longer on battery charge
		public double WorkEfficiency { get; set; }
		// higher scan delay the longer
		// it takes to locate item
		public int ScanDelay { get; set; }
		public void PickupItems(int itemCount)
		{
			for (int counter = 1; counter < itemCount + 1; counter++)
			{
				if (BatteryLevel < 0.1)
				{
					Console.WriteLine($"{Name} battery low: Need to recharge");
					break;
				}
				Console.ForegroundColor = LaserColor;
				Console.WriteLine($"{Name} pickup #{counter:D3}");
				Thread.Sleep(ScanDelay);
				BatteryLevel = BatteryLevel - (DrainRate + WorkEfficiency);
			
			}
			Console.WriteLine($"{Name} finished: Battery level: {BatteryLevel:N3} returning to base.");
		}
		public void ChargeBattery()
		{
			//Efficiency 
		}
		public Robot(string name, double workEfficiency, int scanDelay, ConsoleColor laserColor = ConsoleColor.Green)
		{
			Name = name;
			BatteryLevel = 1;
			WorkEfficiency = workEfficiency;
			ScanDelay = Math.Max (50,scanDelay);
			LaserColor = laserColor;
		}
	}
}