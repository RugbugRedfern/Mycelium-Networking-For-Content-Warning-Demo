using BepInEx;
using HarmonyLib;
using MyceliumNetworking;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyceliumNetworkingTest
{
	[BepInPlugin(modGUID, modName, modVersion)]
	public class BasePlugin : BaseUnityPlugin
	{
		const string modGUID = "RugbugRedfern.TextChat";
		public const uint MOD_ID = 13515452;
		const string modName = "Text Chat";
		const string modVersion = "1.0.0";
		static bool initialized;

		readonly Harmony harmony = new Harmony(modGUID);

		void Awake()
		{
			if(initialized)
				return;

			initialized = true;

			RugLogger.Initialize(modGUID);

			harmony.PatchAll(Assembly.GetExecutingAssembly());

			// Initialize mod on persistent GameObject
			var go = new GameObject("MyceliumNetworkingTest Persistent");
			go.AddComponent<SyncedGameObject>();
			go.hideFlags = HideFlags.HideAndDontSave;
			DontDestroyOnLoad(go);
		}
	}
}