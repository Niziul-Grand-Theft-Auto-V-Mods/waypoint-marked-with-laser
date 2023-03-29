using GTA;

using System.IO;

using System.Collections.Generic;

using Waypoint_marked_with_laser.laser_beam_settings_manager.single_beam;
using Waypoint_marked_with_laser.laser_beam_settings_manager.prefabricated_beam;

using Waypoint_marked_with_laser.settings.the_damn_strings_for_the_configuration_files;


namespace Waypoint_marked_with_laser.settings
{
    class Settings
    {
        private string[] SettingsDirectory
        { get; set; }

        private ScriptSettings[] ScriptSettingsFiles
        { get; set; }

        private SingleBeamManager _singleBeamManager;

        private IList<PrefabricatedBeamManager> _prefabricatedBeamManager;

        private IList<ScriptSettings> _prefabricatedBeamScriptSettingsFiles;



        public Settings()
        {
            _prefabricatedBeamScriptSettingsFiles =
                new List<ScriptSettings>();

            _prefabricatedBeamManager =
                new List<PrefabricatedBeamManager>();
        }
        public Settings(string directory) : this()
        {
            SettingsDirectory = new[]
            {
                $@"{directory}\",
                $@"{directory}\SingleBeam",
                $@"{directory}\PrefabricatedBeams"
            };

            ScriptSettingsFiles = new[]
            {
                ScriptSettings
                    .Load($@"{SettingsDirectory[0]}\SettingUpForLaserOperation.ini"),
                ScriptSettings
                    .Load($@"{SettingsDirectory[1]}\SetTheSingleBeamColor.ini"),
                ScriptSettings
                    .Load($@"{SettingsDirectory[2]}\BaseToCreateTheBeams.ini")
            };

            DetermineTheCreationOfTheMainScriptSettingsFiles();

            if (GetIfItIsToEnableThePrefabricatedBeams())
            {
                LoadTheSettingsOfThePrefabricatedBeams();
            }

            if (GetIfItIsToEnableTheSingleBeam())
            {
                LoadTheSettingsOfTheSingleBeam();
            }
        }

        private void DetermineTheCreationOfTheMainScriptSettingsFiles()
        {
            for (var i = 0; i < ScriptSettingsFiles.Length; i++)
            {
                var scriptSettingsFiles =
                    Directory.GetFiles(SettingsDirectory[i], "*.ini");

                var isThereAnySettingsFileForTheScript =
                    scriptSettingsFiles.Length == 0;


                if (!isThereAnySettingsFileForTheScript)
                {
                    foreach (var scriptSettingsFile in scriptSettingsFiles)
                    {
                        var hasTheScriptSettingsFileAlreadyBeenCreated =
                            File.Exists(scriptSettingsFile);

                        if (!hasTheScriptSettingsFileAlreadyBeenCreated)
                        {
                            CreateTheMainScriptSettingsFiles(i);
                        }
                    }
                }
                else
                {
                    CreateTheMainScriptSettingsFiles(i);
                }
            }
        }
        private void CreateTheMainScriptSettingsFiles(int i)
        {
            switch (i)
            {
                case 0:
                    {
                        LaserOperationSettings();
                    }
                    break;
                case 1:
                    {
                        SingleBeamColor();
                    }
                    break;
                case 2:
                    {
                        BaseToCreateThePrefabricatedBeams();
                    }
                    break;
            }
        }

        private void SingleBeamColor()
        {
            var settingsString =
                new StStringsForSetTheSingleBeamColor().Get();


            ScriptSettingsFiles[1]
                .SetValue(settingsString[0],
                          settingsString[1],
                          value: 0);

            ScriptSettingsFiles[1]
                .SetValue(settingsString[0],
                          settingsString[2],
                          value: 0);

            ScriptSettingsFiles[1]
                .SetValue(settingsString[0],
                          settingsString[3],
                          value: 0);

            ScriptSettingsFiles[1]
                .SetValue(settingsString[0],
                          settingsString[4],
                          value: 0);

            ScriptSettingsFiles[1]
                .Save();
        }
        private void LaserOperationSettings()
        {
            var settingsString =
                new StStringsForTheLaserOperationSettings()
                        .Get();


            ScriptSettingsFiles[0]
                .SetValue(settingsString[0],
                          settingsString[1],
                          value: settingsString[3]);

            ScriptSettingsFiles[0]
                .SetValue(settingsString[0],
                          settingsString[2],
                          value: settingsString[4]);

            ScriptSettingsFiles[0]
                .SetValue(settingsString[5],
                          settingsString[6],
                          value: settingsString[7]);

            ScriptSettingsFiles[0]
                .Save();
        }
        private void BaseToCreateThePrefabricatedBeams()
        {
            var settingsString =
                new StStringsForBaseToCreateThePrefabricatedBeams().Get();


            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[1],
                          value: false);

            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[2],
                          value: false);

            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[3],
                          value: false);


            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[4],
                          value: 0);

            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[5],
                          value: 0);


            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[6],
                          value: 0.0f);

            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[7],
                          value: 0.0f);


            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[8],
                          value: 0.0f);
            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[9],
                          value: 0.0f);
            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[10],
                          value: 0.0f);


            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[11],
                          value: 0);
            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[12],
                          value: 0);
            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[13],
                          value: 0);
            ScriptSettingsFiles[2]
                .SetValue(settingsString[0],
                          settingsString[14],
                          value: 0);


            ScriptSettingsFiles[2]
                .Save();
        }


        private void LoadTheSettingsOfTheSingleBeam()
        {
            _singleBeamManager =
                new SingleBeamManager(ScriptSettingsFiles[1]);

            _singleBeamManager
                .SetTheColor();
        }
        internal StSingleBeamSetup ReturnTheCurrentStSingleBeamSetup()
        {
            return _singleBeamManager.ReturnStSingleBeamSetup();
        }

        private void LoadTheSettingsOfThePrefabricatedBeams()
        {
            LoadAllSettingsOfThePrefabricatedBeams();

            var indexOne = 0;
            foreach (var prefabricatedBeamScriptSettingsFile in _prefabricatedBeamScriptSettingsFiles)
            {
                var item =
                    new PrefabricatedBeamManager(prefabricatedBeamScriptSettingsFile);

                _prefabricatedBeamManager
                    .Add(item);

                _prefabricatedBeamManager[indexOne]
                    .SetTheColor();
                _prefabricatedBeamManager[indexOne]
                    .SetTheRotation();

                _prefabricatedBeamManager[indexOne]
                    .SetTheScale();
                _prefabricatedBeamManager[indexOne]
                    .SetTheRotation();
                _prefabricatedBeamManager[indexOne]
                    .SetTheVerticalSpace();

                _prefabricatedBeamManager[indexOne]
                    .SetTheMakerType();
                _prefabricatedBeamManager[indexOne]
                    .SetTheNumberOfMarkers();

                _prefabricatedBeamManager[indexOne]
                    .SetTheValueOfTheSettingRotateY();
                _prefabricatedBeamManager[indexOne]
                    .SetTheValueOfTheSettingFaceCamera();
                _prefabricatedBeamManager[indexOne]
                    .SetTheValueOfTheSettingIsBobUpAndDown();


                indexOne++;
            }
        }
        internal List<StPrefabricatedBeamSetup> ReturnAllStPrefabricatedBeamSetup()
        {
            var stPrefabricatedBeamSetup =
                new List<StPrefabricatedBeamSetup>();

            for (int i = 0; i < _prefabricatedBeamManager.Count; i++)
            {
                stPrefabricatedBeamSetup
                    .Add(_prefabricatedBeamManager[i]
                        .ReturnStPrefabricatedBeamSetup());
            }

            return stPrefabricatedBeamSetup;
        }

        private void LoadAllSettingsOfThePrefabricatedBeams()
        {
            var prefabricatedBeamsToBeUsed =
                    GetAllPrefabricatedBeamsToBeUsed();
            var prefabricatedBeamsFromTheFolder =
                    GetAllPrefabricatedBeamsFromTheFolder();


            foreach (var prefabricatedBeamFromTheFolder in prefabricatedBeamsFromTheFolder)
            {
                var startIndex =
                    0;

                var count =
                    SettingsDirectory[2].Length;

                var PrefabricatedBeamTakenFromTheFolder =
                    prefabricatedBeamFromTheFolder
                        .Remove(startIndex, count);

                var isThePrefabricatedBeamInTheFolderDesignatedForUse =
                    false;

                foreach (var prefabricatedBeamToBeUsed in prefabricatedBeamsToBeUsed)
                {
                    isThePrefabricatedBeamInTheFolderDesignatedForUse =
                        prefabricatedBeamToBeUsed
                            .Replace("'", "")
                            .Replace(";", "")
                            .Replace(" ", "")
                                .Contains(PrefabricatedBeamTakenFromTheFolder
                                    .Replace(".ini", "")
                                    .Replace(@"\", ""));

                    if (isThePrefabricatedBeamInTheFolderDesignatedForUse)
                    {
                        var item =
                            ScriptSettings
                                .Load(prefabricatedBeamFromTheFolder);

                        _prefabricatedBeamScriptSettingsFiles
                            .Add(item);
                    }
                }
            }
        }
        private string[] GetAllPrefabricatedBeamsToBeUsed()
        {
            var settingsString = new[]
            {
                new StStringsForTheLaserOperationSettings()
                        .Get()[5],
                new StStringsForTheLaserOperationSettings()
                        .Get()[6],
            };

            return ScriptSettingsFiles[0]
                    .GetAllValues<string>(settingsString[0],
                                          settingsString[1]);
        }
        private string[] GetAllPrefabricatedBeamsFromTheFolder()
        {
            var nameOfThePrefabricatedBeams =
                    Directory
                        .GetFiles(SettingsDirectory[2], "*.ini");

            return nameOfThePrefabricatedBeams;
        }


        internal bool GetIfItIsToEnableTheSingleBeam()
        {
            var settingsString = new[]
            {
                new StStringsForTheLaserOperationSettings()
                        .Get()[0],
                new StStringsForTheLaserOperationSettings()
                        .Get()[1],
                new StStringsForTheLaserOperationSettings()
                        .Get()[3]
            };

            var isToEnableTheSingleBeam =
                false;

            var value =
                ScriptSettingsFiles[0]
                    .GetValue(settingsString[0],
                              settingsString[1],
                              settingsString[2]).Replace(";", "")
                                                .Replace(" ", "");
            if (value is "Yes")
            {
                isToEnableTheSingleBeam =
                    true;
            }


            return isToEnableTheSingleBeam;
        }

        internal bool GetIfItIsToEnableThePrefabricatedBeams()
        {
            var settingsString = new[]
            {
                new StStringsForTheLaserOperationSettings()
                        .Get()[0],
                new StStringsForTheLaserOperationSettings()
                        .Get()[2],
                new StStringsForTheLaserOperationSettings()
                        .Get()[4]
            };
            var isToEnableThePrefabricatedBeams =
                false;

            var value =
                ScriptSettingsFiles[0]
                    .GetValue(settingsString[0],
                              settingsString[1],
                              settingsString[2]).Replace(";", "")
                                                .Replace(" ", "");
            if (value is "Yes")
            {
                isToEnableThePrefabricatedBeams =
                    true;
            }


            return isToEnableThePrefabricatedBeams;
        }

        internal void ClearAllLists()
        {
            if (_prefabricatedBeamScriptSettingsFiles.Count != 0)
            {
                _prefabricatedBeamScriptSettingsFiles.Clear();
            }
            if (_prefabricatedBeamManager.Count != 0)
            {
                _prefabricatedBeamManager.Clear();
            }
        }
    }
}
