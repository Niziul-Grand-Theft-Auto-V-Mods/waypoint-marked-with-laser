using GTA;

using System.Drawing;

using Waypoint_marked_with_laser.settings.the_damn_strings_for_the_configuration_files;


namespace Waypoint_marked_with_laser.laser_beam_settings_manager.single_beam
{
    class SingleBeamManager
    {
        private ScriptSettings _scriptSettings;

        private StSingleBeamSetup _singleBeamSetup;


        public SingleBeamManager()
        {
        }
        public SingleBeamManager(ScriptSettings scriptSettings)
        {
            _scriptSettings = scriptSettings;
        }

        internal StSingleBeamSetup ReturnStSingleBeamSetup()
        {
            return _singleBeamSetup;
        }
        internal void SetTheColor()
        {
            var colorSingleBeam =
                PickTheColor();

            _singleBeamSetup.Color =
                Color
                    .FromArgb(colorSingleBeam[0],
                              colorSingleBeam[1],
                              colorSingleBeam[2],
                              colorSingleBeam[3]);
        }
        int[] PickTheColor()
        {
            var stringToSettings =
                new StStringsForSetTheSingleBeamColor().Get();

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
    }
}
