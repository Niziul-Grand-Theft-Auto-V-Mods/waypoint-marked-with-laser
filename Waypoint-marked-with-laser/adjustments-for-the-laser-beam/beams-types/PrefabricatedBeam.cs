using GTA;
using GTA.Math;
using GTA.Native;

using System.Drawing;

using Waypoint_marked_with_laser.laser_beam_settings_manager.prefabricated_beam;


namespace Waypoint_marked_with_laser.adjustments_for_the_laser_beam.beams_types
{
    class PrefabricatedBeam
    {
        public PrefabricatedBeam(StPrefabricatedBeamSetup stPrefabricatedBeamSetup)
        {
            Activate(stPrefabricatedBeamSetup);
        }
        void Activate(StPrefabricatedBeamSetup stPrefabricatedBeamSetup)
        {
            var playerPosition =
                Game.Player.Character.Position;

            var waypointPosition =
                new Vector3(World.WaypointPosition.X,
                            World.WaypointPosition.Y,
                            World.WaypointPosition.Z + 1960f);


            var faceCam =
                stPrefabricatedBeamSetup.FaceCamera;

            var rotateY =
                stPrefabricatedBeamSetup.RotateY;

            var isBobUpAndDown =
                stPrefabricatedBeamSetup.IsBobUpAndDown;

            var rotation =
                stPrefabricatedBeamSetup.Rotation;

            var direction =
                new Vector3(0f, 0f, 0f);

            var color =
                stPrefabricatedBeamSetup.Color;

            var shape =
                stPrefabricatedBeamSetup.MarkerType;

            var numberOfMarkers =
                stPrefabricatedBeamSetup.NumberOfMakers;

            var verticalSpace =
                stPrefabricatedBeamSetup.VerticalSpace;

            // 0.0100f; good!

            var baseScale =
                stPrefabricatedBeamSetup.Scale;

            for (int i = 0; i < numberOfMarkers; i++)
            {
                var position =
                    new Vector3(waypointPosition.X,
                                waypointPosition.Y,
                                waypointPosition.Z - (i * verticalSpace));

                var scale =
                    new Vector3(baseScale * ((playerPosition.X + playerPosition.Y) - (waypointPosition.X + waypointPosition.Y)),
                                baseScale * ((playerPosition.X + playerPosition.Y) - (waypointPosition.X + waypointPosition.Y)),
                                baseScale * ((playerPosition.X + playerPosition.Y) - (waypointPosition.X + waypointPosition.Y)));

                DrawMarker(shape,
                           position,
                           direction,
                           rotation,
                           scale,
                           color,
                           isBobUpAndDown,
                           faceCam,
                           rotateY);
            }
        }
        void DrawMarker(int type, Vector3 position, Vector3 direction, Vector3 rotation, Vector3 scale, Color color, bool isBobUpAndDown = false, bool isFaceCamera = false, bool isSpinningOnTheY_Axis = false, string textueDict = null, string textureName = null, bool isToDrawOnEntity = false)
        {
            if (!string.IsNullOrEmpty(textueDict) &&
                !string.IsNullOrEmpty(textureName))
            {
                Function.Call(Hash.DRAW_MARKER, type, position.X, position.Y, position.Z, direction.X, direction.Y, direction.Z, rotation.X, rotation.Y, rotation.Z, scale.X, scale.Y, scale.Z, color.R, color.G, color.B, color.A, isBobUpAndDown, isFaceCamera, 2, isSpinningOnTheY_Axis, textueDict, textureName, isToDrawOnEntity);
            }
            else
            {
                Function.Call(Hash.DRAW_MARKER, type, position.X, position.Y, position.Z, direction.X, direction.Y, direction.Z, rotation.X, rotation.Y, rotation.Z, scale.X, scale.Y, scale.Z, color.R, color.G, color.B, color.A, isBobUpAndDown, isFaceCamera, 2, isSpinningOnTheY_Axis, 0, 0, isToDrawOnEntity);
            }
        }
    }
}
