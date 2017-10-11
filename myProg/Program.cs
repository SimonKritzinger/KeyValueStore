/*
 * Created by SharpDevelop.
 * User: 13krisim
 * Date: 11.10.2017
 * Time: 08:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace myProg
{
	class Program
	{
		public static void Main(string[] args)
		{
			DataBase b = new DataBase();
			while(true){
				
				Console.WriteLine("Enter your command(help for help)");
				
				string command = Console.ReadLine();
				
				if(command.StartsWith("help")){
							Console.WriteLine("put [key] [value]\nget [key]\ndel [key]\nfind [value]");
				}
				else if(command.StartsWith("put")){
				}

			}
		}
	}
}