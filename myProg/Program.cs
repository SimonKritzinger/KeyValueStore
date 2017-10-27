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
			Console.WriteLine("Do you want to create a new KeyValueStore or open a old one?(create , open [path])");
			string command = Console.ReadLine();
			string erg ="";
			var b = new DataBase();
			while(!erg.Equals("ok")){
				if(command.StartsWith("create")){
					b = new DataBase();
					erg = "ok";
				}
				else if(command.StartsWith("open") && command.Split(' ').Length == 2){
					b = new DataBase(command.Split(' ')[1],out erg);
					if(!erg.Equals("ok")){
						Console.WriteLine(erg+"\nEnter new path(create [path]) or open an old one(open)");
					}
				}
			}
			while(true){
				
				Console.WriteLine("Enter your command(help for help)");
				command = Console.ReadLine();
				//switch wurde nicht verwendet, da kein string.StartsWith(string s)
				if(command.StartsWith("help")){
					Console.WriteLine("put [key] [value]\nget [key]\ndel [key]\nfind [value]");
				}
				else if(command.StartsWith("put")){
					string[] buffer = command.Split(' ');
					if(buffer.Length == 3){
						b.put(buffer[1], buffer[2]);
					}
					else{
						Console.WriteLine("Invalid syntax for 'put'\nuse: 'put [key] [value]'");
					}
				}
				else if(command.StartsWith("get")){
					string[] buffer = command.Split(' ');
					if(buffer.Length == 2){
						Console.WriteLine(b.get(buffer[1]));
					}
					else{
						Console.WriteLine("Invalid syntax for 'get'\nuse: 'get [key]'");
					}
				}
				else if(command.StartsWith("del")){
					string[] buffer = command.Split(' ');
					if(buffer.Length == 2){
						bool ret = b.del(buffer[1]);
						if(!ret){
							Console.WriteLine("Error!");
						}
					}
					else{
						Console.WriteLine("Invalid syntax for 'del'\nuse: 'del [key]'");
					}
				}
				else if(command.StartsWith("find")){
					string[] buffer = command.Split(' ');
					if(buffer.Length == 2){
						Console.WriteLine(b.find(buffer[1]));
					}
					else{
						Console.WriteLine("Invalid syntax for 'find'\nuse: 'find [value]'");
					}
				}

			}
		}
	}
}