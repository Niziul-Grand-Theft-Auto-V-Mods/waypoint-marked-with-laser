using GTA;
using GTA.Math;

using System.Drawing;

using Waypoint_marked_with_laser.settings.the_damn_strings_for_the_configuration_files;

namespace Waypoint_marked_with_laser.laser_beam_settings_manager.prefabricated_beam
{
    class PrefabricatedBeamManager
    {
        private string[] _stringToSettings;

        private ScriptSettings _scriptSettings;

        private StPrefabricatedBeamSetup _stPrefabricatedBeamSetup;


        public PrefabricatedBeamManager()
        {
        }
        public PrefabricatedBeamManager(ScriptSettings scriptSettings)
        {
            _scriptSettings = scriptSettings;

            _stringToSettings =
                new StStringsForBaseToCreateThePrefabricatedBeams().Get();
        }

        internal StPrefabricatedBeamSetup ReturnStPrefabricatedBeamSetup()
        {
            return _stPrefabricatedBeamSetup;
        }



        bool PickTheValueOfTheSettingIsBobUpAndDown()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[1] // isBobUpAndDown
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: false);
        }
        internal void SetTheValueOfTheSettingIsBobUpAndDown()
        {
            _stPrefabricatedBeamSetup.IsBobUpAndDown =
                PickTheValueOfTheSettingIsBobUpAndDown();
        }

        bool PickTheValueOfTheSettingFaceCamera()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[2] // faceCam
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: false);
        }
        internal void SetTheValueOfTheSettingFaceCamera()
        {
            _stPrefabricatedBeamSetup.FaceCamera =
                PickTheValueOfTheSettingFaceCamera();
        }

        bool PickTheValueOfTheSettingRotateY()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[3] // rotateY
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: false);
        }
        internal void SetTheValueOfTheSettingRotateY()
        {
            _stPrefabricatedBeamSetup.RotateY =
                PickTheValueOfTheSettingRotateY();
        }



        int PickTheMakerType()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[4] // markerType
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: 0);
        }
        internal void SetTheMakerType()
        {
            _stPrefabricatedBeamSetup.MarkerType =
                PickTheMakerType();
        }

        int PickTheNumberOfMarkers()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[5] // numberOfMarkers
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: 0);
        }
        internal void SetTheNumberOfMarkers()
        {
            _stPrefabricatedBeamSetup.NumberOfMakers =
                PickTheNumberOfMarkers();
        }



        float PickTheVerticalSpace()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[6] // verticalSpace
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: 0f);
        }
        internal void SetTheVerticalSpace()
        {
            _stPrefabricatedBeamSetup.VerticalSpace =
                PickTheVerticalSpace();
        }

        float PickTheScale()
        {
            var stringsToSettings = new[]
            {
                _stringToSettings[0], // Settings
                _stringToSettings[7] // scale
            };

            return _scriptSettings
                    .GetValue(stringsToSettings[0],
                              stringsToSettings[1],
                              defaultvalue: 0f);
        }
        internal void SetTheScale()
        {
            _stPrefabricatedBeamSetup.Scale =
                PickTheScale();
        }



        int[] PickTheColor()
        {
            var stringToSettings = new[]
            {
                _stringToSettings[0],   // Settings
                _stringToSettings[11],  // color.A
                _stringToSettings[12],  // color.R
                _stringToSettings[13],  // color.G
                _stringToSettings[14]   // color.B
            };


            return new[]
            {
                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[1],
                              defaultvalue: 0),

                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[2],
                              defaultvalue: 0),

                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[3],
                              defaultvalue: 0),

                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[4],
                              defaultvalue: 0)
            };
        }
        internal void SetTheColor()
        {
            var color =
                PickTheColor();

            _stPrefabricatedBeamSetup.Color =
                Color
                    .FromArgb(color[0],
                              color[1],
                              color[2],
                              color[3]);
        }


        internal void SetTheRotation()
        {
            var rotation =
                PickTheRotation();

            _stPrefabricatedBeamSetup.Rotation =
                new Vector3(rotation[0],
                            rotation[1],
                            rotation[2]);
        }
        float[] PickTheRotation()
        {
            var stringToSettings = new[]
            {
                _stringToSettings[0],   // Settings
                _stringToSettings[8],   // rotation.X
                _stringToSettings[9],   // rotation.Y
                _stringToSettings[10]   // rotation.Z
            };

            return new[]
            {
                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[1],
                              defaultvalue: 0f),

                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[2],
                              defaultvalue: 0f),

                _scriptSettings
                    .GetValue(stringToSettings[0],
                              stringToSettings[3],
                              defaultvalue: 0f)
            };
        }
    }
}
