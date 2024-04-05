using MyceliumNetworking;
using Steamworks;
using System;
using UnityEngine;

namespace MyceliumNetworkingTest
{
	internal class SyncedGameObject : MonoBehaviour
	{
		void Start()
		{
			MyceliumNetwork.RegisterNetworkObject(this, BasePlugin.MOD_ID);
		}

		void Update()
		{
			foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
			{
				if(Input.GetKeyDown(kcode))
				{
					MyceliumNetwork.RPC(BasePlugin.MOD_ID, nameof(KeyReceived), ReliableType.Reliable, kcode.ToString());
				}
			}
		}

		[CustomRPC]
		public void KeyReceived(string keyPressed, RPCInfo info)
		{
			CSteamID sender = info.SenderSteamID;
			string username = SteamFriends.GetFriendPersonaName(sender);
			Debug.Log("Received key from " + username + ": " + keyPressed);
		}
	}
}