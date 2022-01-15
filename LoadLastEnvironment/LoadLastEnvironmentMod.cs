﻿using System;
using Bigscreen;
using MelonLoader;

namespace LoadLastEnvironment
{
    internal static class BuildInfo
    {
        internal const string Name = "LoadLastEnvironment";
        internal const string Author = "gzx";
        internal const string Version = "0.1";
        internal const string DownloadLink = "https://github.com/g-zx/LoadLastEnvironment";
        internal const string Description = "Bigscreen mod that restores the last used environment in your room.";
        internal const string Copyright = "Copyright © 2022";
    }

    internal class LoadLastEnvironmentMod : MelonMod
    {
        internal static LoadLastEnvironmentMod Instance { get; private set; }

        private MelonPreferences_Entry<string> _savedEnvironmentName;

        private string _roomCreatorUserId;
        private App _bigscreen;

        public override void OnApplicationStart()
        {
            Instance = this;

            var prefsCategory = MelonPreferences.CreateCategory(BuildInfo.Name, BuildInfo.Name);
            _savedEnvironmentName = prefsCategory.CreateEntry("EnvironmentName", "Modern Living Room");

            base.OnApplicationStart();
        }

        internal void Initialize(App bigscreenInstance)
        {
            _bigscreen = bigscreenInstance;
            _bigscreen.RoomSwitchFinished += new Action(HandleRoomSwitchFinished);
        }

        private void HandleRoomSwitchFinished()
        {
            _roomCreatorUserId = _bigscreen.CurrentRoom.Creator.UserSessionId;
        }

        public void HandleEnvironmentChanged()
        {
            if (_bigscreen.CurrentRoom.Creator.UserSessionId == _roomCreatorUserId && _bigscreen.CurrentEnvironment.name != _savedEnvironmentName.Value)
            {
                LoggerInstance.Msg("Environment changed to {0}, saving", _bigscreen.CurrentEnvironment.name);

                _savedEnvironmentName.Value = _bigscreen.CurrentEnvironment.name;
            }
        }

        public void OnPreCreateAndJoinMyRoom(ref string environmentName)
        {
            var savedEnvironment = _savedEnvironmentName.Value;

            if (_bigscreen.environments.EnvironmentIsValid(savedEnvironment))
            {
                LoggerInstance.Msg("Restoring environment {0}", savedEnvironment);
                environmentName = savedEnvironment;
            }
            else
            {
                _savedEnvironmentName.Value = environmentName;
            }
        }
    }
}