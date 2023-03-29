using GTA;
using GTA.Math;

using System.Collections.Generic;

using Waypoint_marked_with_laser.settings;

using Waypoint_marked_with_laser.adjustments_for_the_laser_beam;
using Waypoint_marked_with_laser.adjustments_for_the_laser_beam.beams_types;

using Waypoint_marked_with_laser.laser_beam_settings_manager.single_beam;
using Waypoint_marked_with_laser.laser_beam_settings_manager.prefabricated_beam;


namespace Waypoint_marked_with_laser
{
    public class Main : Script
    {
        private Settings _settings =
            new Settings();

        private LaserStructure _laserStructure =
            new LaserStructure();

        private Vector3 _currentWaypointPosition =
            new Vector3();

        private Vector3 _initialWaypointPosition =
            new Vector3();

        private bool _isThereLaserStructureOnTheMap =
            false;

        private readonly bool _isToEnableTheSingleBeam =
            false;

        private readonly bool _isToEnableThePrefabricatedBeams =
            false;

        private StSingleBeamSetup _stSingleBeamSetup =
            new StSingleBeamSetup();

        private IList<StPrefabricatedBeamSetup> _allStPrefabricatedBeamSetup =
            new List<StPrefabricatedBeamSetup>();



        public Main()
        {
            _settings =
                new Settings(GetRelativeFilePath($@"WaypointMarkedWithLaser"));

            _isToEnableTheSingleBeam =
                _settings.GetIfItIsToEnableTheSingleBeam();

            _isToEnableThePrefabricatedBeams =
                _settings.GetIfItIsToEnableThePrefabricatedBeams();
            
            if (_isToEnableTheSingleBeam)
                _stSingleBeamSetup =
                    _settings.ReturnTheCurrentStSingleBeamSetup();

            if (_isToEnableThePrefabricatedBeams)
                _allStPrefabricatedBeamSetup =
                    _settings.ReturnAllStPrefabricatedBeamSetup();


            Tick += (o, e) =>
            { Start(); };

            Aborted += (o, e) =>
            { Finish(); };
        }

        private void Start()
        {
            var waypointBlip =
                World.WaypointBlip;

            var isTheWaypointActive =
                waypointBlip != null;


            switch (isTheWaypointActive)
            {
                case true:
                    {
                        if (!_isThereLaserStructureOnTheMap)
                        {
                            _initialWaypointPosition =
                                waypointBlip.Position;

                            PreConfigureTheLaserStructure();
                        }
                        else
                        {
                            _currentWaypointPosition =
                                waypointBlip.Position;

                            switch (_initialWaypointPosition == _currentWaypointPosition)
                            {
                                case true:
                                    {
                                        FireTheLaserBeam();
                                    }
                                    break;
                                case false:
                                    {
                                        ReconfigureTheLaserStructure();
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                case false:
                    {
                        return;
                    }
            }
        }

        private void Finish()
        {
            ReconfigureTheLaserStructure();
            _settings.ClearAllLists();
        }

        void ReconfigureTheLaserStructure()
        {
            _laserStructure.DestroyTheLaserStructure();
            _isThereLaserStructureOnTheMap = false;
        }
        void PreConfigureTheLaserStructure()
        {
            _laserStructure.CreateTheLaserStructure();
            _isThereLaserStructureOnTheMap = true;
        }
        void FireTheLaserBeam()
        {
            if (_isToEnableTheSingleBeam)
            {
                new SingleBeam(_stSingleBeamSetup);
            }

            if (_isToEnableThePrefabricatedBeams)
            {
                foreach (var stPrefabricatedBeamSetup in _allStPrefabricatedBeamSetup)
                {
                    new PrefabricatedBeam(stPrefabricatedBeamSetup);
                }
            }
        }
    }
}