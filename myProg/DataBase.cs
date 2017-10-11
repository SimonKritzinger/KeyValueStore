/*
 * Created by SharpDevelop.
 * User: 13krisim
 * Date: 11.10.2017
 * Time: 08:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;


namespace myProg
{
	/// <summary>
	/// Description of DataBase.
	/// </summary>
	public class DataBase
	{
				
		private Dictionary<string, string> keyValueStore;
		
		public DataBase()
		{
			keyValueStore = new Dictionary<string, string>();
		}
		
		public void put(String key,String value){
			keyValueStore.Add(key,value);
		}
		
		public string get(String key){
			if(keyValueStore[key] != null)
				return keyValueStore[key];
			else
				return "key doesn't exist";
		}
		
		public void del(String key){
			keyValueStore.
		}
	}
}
