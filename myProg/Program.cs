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
			Console.Write("Do you want to create a new KeyValueStore or open a old one?(create , open [path])\n>");
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
						Console.Write(erg+"\nEnter new path(create [path]) or open an old one(open)\n>");
						command = Console.ReadLine();
					}
				}
				else{
					Console.Write("Do you want to create a new KeyValueStore or open a old one?(create , open [path])\n>");
					command = Console.ReadLine();
				}
			}
			bool running = true;
			while(running){
				
				Console.Write("Enter your command(help for help)\n>");
				command = Console.ReadLine();
				//switch wurde nicht verwendet, da kein string.StartsWith(string s)
				if(command.StartsWith("help")){
					Console.WriteLine("-> put [key] [value]\n-> get [key]\n-> del [key]\n-> find [value]\n-> save [path]\n   File has to be .csv\n-> load [path]\n   Loads a KeyValueStore from .csv file. All unsaved data will be deleted\n-> create\n   creates new KeyValueStore. All unsaved data will be deleted\n-> exit");
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
				else if(command.StartsWith("save")){
					string[] buffer = command.Split(' ');
					if(buffer.Length == 2){
						bool retvalue = b.save(buffer[1]);
						if(!retvalue){
							Console.WriteLine("Couldn't save KeysValueStore");
						}
					}
					else{
						Console.WriteLine("Invalid syntax for 'save'\nuse: 'save [path]'");
					}
				}
				else if(command.StartsWith("create")){
					b = new DataBase();
				}
				else if(command.StartsWith("load")){
					string[] buffer = command.Split(' ');
					if(buffer.Length == 2){
						string e;
						b = new DataBase(buffer[1], out e);
						if(!e.Equals("ok")){
							Console.WriteLine(e);
						}
					}
					else{
						Console.WriteLine("Invalid syntax for 'load'\nuse: 'load [path]'");
					}
				}
				else if(command.StartsWith("exit")){
					running = false;
				}
			}
		}
	}
}