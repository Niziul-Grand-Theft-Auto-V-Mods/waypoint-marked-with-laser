using GTA;

using System.Drawing;


namespace Waypoint_marked_with_laser.setup_manager
{
    class Settings
    {
        private ScriptSettings fileSetBlipColor;

        public Settings(string directory)
        {
            fileSetBlipColor =
                ScriptSettings.Load($"{directory}/ColorForTheLaserBeam.ini");

            SetTheColor();
        }

        void SetTheColor()
        {
            var colorsFromArgb =
                PickTheColorForTheLaserBeam();

            SettingColor.ColorOfTheLaserBeam = Color.FromArgb(colorsFromArgb[0],
                                                              colorsFromArgb[1],
                                                              colorsFromArgb[2],
                                                              colorsFromArgb[3]);

        }
        int[] PickTheColorForTheLaserBeam()
        {
            return new[]
            {
                fileSetBlipColor.GetValue<int>("Color From Argb", "Alpha:", 255),
                fileSetBlipColor.GetValue<int>("Color From Argb", "Red:", 255),
                fileSetBlipColor.GetValue<int>("Color From Argb", "Green:", 215),
                fileSetBlipColor.GetValue<int>("Color From Argb", "Blue:", 255)
            };
        }
    }
}
