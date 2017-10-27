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
using System.IO;
using System.Xml.Serialization;


namespace myProg
{
	/// <summary>
	/// Description of DataBase.
	/// </summary>
	public class DataBase
	{
				
		private IDictionary<string, string> keyValueStore;
		
		
		public DataBase(string path, out string erg){
			if(!string.IsNullOrEmpty(path)){
				try{
					var reader = new StreamReader(path);
					keyValueStore = new Dictionary<string, string>();
					foreach(item p in temp){
						put(p.id,p.value);
					}
					erg = "ok";
				}catch(Exception e){
					erg = "error";
				}
			}
			else{
				erg = "Couldn't load file: string is empty or null!";
				this.keyValueStore = new Dictionary<string, string>();
			}
		}
		
		public DataBase()
		{
			keyValueStore = new Dictionary<string, string>();
		}
		
		public void put(String key,String value){
			
			keyValueStore[key] = value;
		}
		
		public string get(String key){
			try{
				return keyValueStore[key];
			}catch(Exception e){
				return "Error: key doesn't exist";
			}
		}
		
		public bool del(String key){
			return keyValueStore.Remove(key);
		}
		
		public string find(string value){
			string ret = null;
			foreach(var key in keyValueStore.Keys){
				if(keyValueStore[key].Equals(value))
					ret = key;
			}
			if(ret ==null)
				ret = "Error: couldn't find key";
			return ret;
		}
		
		public bool save(string path){
			bool ret = false;
			return ret;
		}
		
	}
}
