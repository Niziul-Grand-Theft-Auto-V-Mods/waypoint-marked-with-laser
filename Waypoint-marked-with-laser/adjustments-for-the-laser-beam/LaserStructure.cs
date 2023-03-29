using GTA;
using GTA.Math;

namespace Waypoint_marked_with_laser.adjustments_for_the_laser_beam
{
    class LaserStructure
    {
        private Prop[] _structures =
            new Prop[2];

        internal void CreateTheLaserStructure()
        {
            var modelName = new[]
            {
                "xs_prop_arena_bollard_side_01a_sf",
                "xs_prop_arena_barrel_01a_sf"
            };

            var waypointPosition =
                World.WaypointPosition;

            var hasPhysics =
                true;

            var IsToStayOnTheGround =
                false;

            var laserHeight =
                new Vector3(x: waypointPosition.X,
                            y: waypointPosition.Y,
                            z: waypointPosition.Z + 2000f);


            for (var i = (byte)0; i < _structures.Length; i++)
            {
                _structures[i] =
                    World
                        .CreateProp(model        : modelName[i],
                                    position     : laserHeight,
                                    dynamic      : hasPhysics,
                                    placeOnGround: IsToStayOnTheGround);


            }

            BasicLaserStructureSettings();
        }
        private void BasicLaserStructureSettings()
        {
            var rotation =
                new Vector3(x: 0.20512519f,
                            y: 179.459076f,
                            z: 101.254494f);

            var relativeRotation =
                new Vector3(x: 0f,
                            y: 2.49999976f,
                            z: -0.399999976f);


            _structures[1]
                .Rotation = rotation;

            _structures[0]
                .AttachTo(entity  : _structures[1],
                          position: relativeRotation);
        }
        internal void DestroyTheLaserStructure()
        {
            foreach (var structure in _structures)
            {
                if (structure != null)
                {
                    structure
                        .Delete();
                }
            }
        }
    }
}
