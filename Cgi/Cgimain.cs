/*
 * Created by SharpDevelop.
 * User: 13krisim
 * Date: 15.11.2017
 * Time: 08:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using myProg;

namespace Cgi
{
	
	class Cgimain
	{
		public static void Main(string[] args){
			Console.WriteLine("Content-Type: text/plain");
			string buffer =  System.Environment.GetEnvironmentVariable("QUERY_STRING");
			string[] arguments = buffer.Split('&');
			string ret;
			string path = "";
			if(arguments[0].Equals("load")){
				if(arguments.Length == 2)
					path = arguments[1];
				else 
					Console.WriteLine("Invalid syntax for 'load'\nuse: 'load [path]'");
			}
			else 
				path = "buffer.csv";
				
			DataBase b = new DataBase(path,out ret);
			if(ret.Equals("ok")){
				switch(arguments[0]){
						case "help":{
							Console.WriteLine("-> put [key] [value]\n" +
							                  "-> get [key]\n" +
							                  "-> del [key]\n" +
							                  "-> find [value]\n" +
							                  "-> save [path]\n   File has to be .csv\n" +
							                  "-> load [path]\n   Loads a KeyValueStore from .csv file. All unsaved data will be deleted\n" +
							                  "-> create\n   creates new KeyValueStore. All unsaved data will be deleted");
							break;
						}
						case "put":{
							break;
						}
						case "get":{
							break;
						}
						case "del":{
							break;
						}
						case "find":{
							break;
						}
						case "save":{
							break;
						}
						case "create":{
							break;
						}
						default:{
							if(!arguments[0].Equals("load")){
								Console.WriteLine("Wrong command! Please type 'help' for more information.");
							}
							break;
						}
				}
				b.save("buffer.csv");
			}
			else{
				Console.WriteLine(ret);
			}
		
		}
	}
}
