using GTA;
using GTA.Math;

using Waypoint_marked_with_laser.laser_beam_settings_manager.single_beam;


namespace Waypoint_marked_with_laser.adjustments_for_the_laser_beam.beams_types
{
    class SingleBeam
    {
        public SingleBeam(StSingleBeamSetup stSingleBeamSetup)
        {
            Activate(stSingleBeamSetup);
        }
        void Activate(StSingleBeamSetup stSingleBeamSetup)
        {
            var color =
                stSingleBeamSetup.Color;

            var waypointPosition =
                World.WaypointPosition;

            var laserBeamHeight =
                new Vector3(waypointPosition.X,
                            waypointPosition.Y,
                            waypointPosition.Z + 2000f);


            World.DrawLine(waypointPosition,
                           laserBeamHeight,
                           color);
        }
    }
}
