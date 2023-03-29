using GTA.Math;

using System.Drawing;

namespace Waypoint_marked_with_laser.laser_beam_settings_manager.prefabricated_beam
{
    struct StPrefabricatedBeamSetup
    {
        internal bool IsBobUpAndDown
        { get; set; }
        internal bool FaceCamera
        { get; set; }
        internal bool RotateY
        { get; set; }

        internal float VerticalSpace
        { get; set; }
        internal float Scale
        { get; set; }

        internal int NumberOfMakers
        { get; set; }
        internal int MarkerType
        { get; set; }

        internal Vector3 Rotation
        { get; set; }

        internal Color Color
        { get; set; }
    }
}