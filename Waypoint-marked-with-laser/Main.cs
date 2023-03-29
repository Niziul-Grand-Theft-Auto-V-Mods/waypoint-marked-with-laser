using GTA;
using GTA.Math;


using System;
using System.Drawing;

using Waypoint_marked_with_laser.creative_table;
using Waypoint_marked_with_laser.setup_manager;

namespace Waypoint_marked_with_laser
{
    public class Main : Script
    {
        private Ped player =
            Game.Player.Character;

        private LaserSource laserSource =
            new LaserSource();

        private Boolean IsThereLaserOnTheMap =
            false;

        private Color colorOfTheLaserBeam =
            new Color();

        private Vector3 waypointPosition =
            new Vector3();
        private Vector3 currentWaypointPosition =
            new Vector3();


        public Main()
        {
            new Settings(GetRelativeFilePath(@"WaypointMarkedWithLaser"));

            colorOfTheLaserBeam =
                SettingColor.ColorOfTheLaserBeam;

            Tick += (o, e) =>
            { Start(); };

            Aborted += (o, e) =>
            { Finish(); };
        }



        private void Start()
        {
            var waypointBlip =
                World.WaypointBlip;

            var isItPossibleToGenerateTheStructureThatFiresTheLaser =
                (waypointBlip != null && !IsThereLaserOnTheMap);


            if (isItPossibleToGenerateTheStructureThatFiresTheLaser)
            {
                GenerateTheLaserStructure();

                currentWaypointPosition = World.WaypointPosition;
            }
            else if (waypointBlip != null)
            {
                waypointPosition = World.WaypointPosition;

                if (currentWaypointPosition == waypointPosition)
                {
                    LaserBeam();
                }
                else
                {
                    Finish();
                }
            }
        }
        private void Finish()
        {
            laserSource.DestroyTheLaserStructure();
            IsThereLaserOnTheMap = false;
        }

        void GenerateTheLaserStructure()
        {
            laserSource.LaserCreator();
            IsThereLaserOnTheMap = true;
        }
        void LaserBeam()
        {
            var laserBeamHeight = new Vector3(waypointPosition.X, waypointPosition.Y, waypointPosition.Z + 2000f);

            World.DrawLine(waypointPosition,
                           laserBeamHeight,
                           colorOfTheLaserBeam);
        }
    }
}
