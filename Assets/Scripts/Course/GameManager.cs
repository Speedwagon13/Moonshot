using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot.Course
{

    /// <summary>
    /// Takes care of core game logic that flows between the different portions 
    /// of shooting the moon into the black hole.
    /// </summary>
    public class GameManager
    {
        private GameObject overviewUI;

        private ICourseInspector courseInspector;

        private IShooter shooter;

        private ICelestialBody currentGolfingPosition;

        private Vector3 normal;

        public GameManager(GameObject ui, ICourseInspector courseInspector, IShooter shooter, ICelestialBody startingPosition)
        {
            this.overviewUI = ui;
            this.courseInspector = courseInspector;
            this.shooter = shooter;
            this.currentGolfingPosition = startingPosition;
            this.normal = Vector3.up;
        }

        public IEnumerator InspectCourse()
        {
            overviewUI.SetActive(false);
            yield return courseInspector.Inspect();
            overviewUI.SetActive(true);
        }

        public IEnumerator Shoot()
        {
            overviewUI.SetActive(false);
            var shotCmd = shooter.Shoot(currentGolfingPosition, Vector3.up);
            yield return shotCmd.Run();
            var results = shotCmd.Results();

            currentGolfingPosition = results.WhereShotEndedUp;
            normal = results.Normal;

            overviewUI.SetActive(true);
        }

    }

}