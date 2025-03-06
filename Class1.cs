using System;
using System.Collections;
using System.Data;
using MelonLoader;
using MelonLoader.Utils;
using NAudio.Wave;
using RumbleModdingAPI;
using UnityEngine;
using UnityEngine.Playables;

namespace RumbleMod2
{
    public static class BuildInfo
    {
        public const string Name = "High Noon"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Makes 1hp fights cooler"; // Description for the Mod.  (Set as null if none)
        public const string Author = "rdm8417"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class HighNoon : MelonMod
    {
        private bool soundPlayed;
        private bool loaded;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (loaded) return;
            loaded = true;
            
            MelonLogger.Msg("HighNoon loading...");
            
            Action action = () =>
            {
                var players = Calls.Players.GetAllPlayers();

                if (players.Count == 1) return;

                foreach (var player in players)
                {
                    if (player.Data.HealthPoints != 1) return;
                }

                if (soundPlayed) return;
                soundPlayed = true;

                MelonLogger.Msg(
                    "> HighNoon entered initializing audio playback @ Calls.onLocalPlayerHealthChanged");

                try
                {
                    MelonCoroutines.Start(PlaySound());
                }
                catch (Exception exception)
                {
                    MelonLogger.Error("> HighNoon encountered an error with audio playback: " + exception.Message);
                }

                MelonLogger.Msg(
                    "> HighNoon completed initializing audio playback @ Calls.onLocalPlayerHealthChanged");
            };
            
            Calls.onLocalPlayerHealthChanged += action;
            Calls.onRemotePlayerHealthChanged += action;
            
            MelonLogger.Msg("HighNoon loaded!");
        }

        private IEnumerator PlaySound()
        {
            var reader = new Mp3FileReader(MelonEnvironment.UserDataDirectory + @"\HighNoon\ItsHiiiiggghhNoon.mp3");
            MelonLogger.Msg(MelonEnvironment.UserDataDirectory + " " + reader.Length);
            
            var waveOut = new WaveOutEvent();
            waveOut.Init(reader);
            waveOut.Play();
            
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                yield return new WaitForFixedUpdate();
            }

            soundPlayed = false;
        }
    }
}