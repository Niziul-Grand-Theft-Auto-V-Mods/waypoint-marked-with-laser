using GTA;
using GTA.Math;

namespace Waypoint_marked_with_laser.creative_table
{
    class LaserSource
    {
        private readonly Prop[] laserStructures = new Prop[2];

        private readonly string[] modelNameLaser =
        {
            "xs_prop_arena_barrel_01a_sf",
            "xs_prop_arena_bollard_side_01a_sf"
        };


        private Vector3 Position
        { get; set; }

        public LaserSource() { }


        internal void LaserCreator()
        {
            Position = World.WaypointPosition;

            CreateTheLaserStructure();
        }
        internal void DestroyTheLaserStructure()
        {
            foreach (var laserStructure in laserStructures)
            {
                if (laserStructure != null)
                {
                    laserStructure.Delete();
                }
            }
        }
        private void CreateTheLaserStructure()
        {
            var hasPhysics =
                true;

            var IsToStayOnTheGround =
                false;

            var laserHeight =
                new Vector3(Position.X, Position.Y, Position.Z + 2000f);


            laserStructures[0] = World.CreateProp(modelNameLaser[1], laserHeight, hasPhysics, IsToStayOnTheGround);
            laserStructures[1] = World.CreateProp(modelNameLaser[0], laserHeight, hasPhysics, IsToStayOnTheGround);


            BasicLaserStructureSettings();
        }
        private void BasicLaserStructureSettings()
        {
            var rotation = new Vector3(0.20512519f, 179.459076f, 101.254494f);
            var relativeRotation = new Vector3(0f, 2.49999976f, -0.399999976f);

            laserStructures[1].Rotation = rotation;

            laserStructures[0].AttachTo(entity: laserStructures[1],
                                       position: relativeRotation);
        }
    }
}
