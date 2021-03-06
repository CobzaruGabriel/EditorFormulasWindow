﻿using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EditorFormulas 
{
	public class FormulaDataStore : ScriptableObject {

		public List<FormulaData> FormulaData;
		public long lastUpdateTimeBinary;
		public DateTime LastUpdateTime
		{
			get
			{
				return DateTime.FromBinary(lastUpdateTimeBinary);
			}
			set
			{
				lastUpdateTimeBinary = value.ToBinary();
			}
		}
		public long lastUpdateAttemptTime;
		public DateTime LastUpdateAttemptTime
		{
			get
			{
				return DateTime.FromBinary(lastUpdateAttemptTime);
			}
			set
			{
				lastUpdateAttemptTime = value.ToBinary();
			}
		}

		public string lastGetOnlineFormulasResponse;


		public static FormulaDataStore LoadFromAssetDatabaseOrCreate()
		{
			var store = AssetDatabase.LoadAssetAtPath<FormulaDataStore>(Constants.assetPath);
			if(store == null)
			{
				store = ScriptableObject.CreateInstance<FormulaDataStore>();

				AssetDatabase.CreateAsset(store, Constants.assetPath);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}
			return store;
		}

		void OnEnable()
		{
			if(FormulaData == null)
			{
				FormulaData = new List<FormulaData>();
			}
		}
	}
}
