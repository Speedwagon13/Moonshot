using UnityEngine;
using BlowhardJamboree.Moonshot.Course.Turret;

namespace BlowhardJamboree.Moonshot.Course
{

    public class ExampleGameManagerBehavior : MonoBehaviour
    {
        private GameManager manager;

        [SerializeField]
        PlanetBehavior startPosition;

        [SerializeField]
        GameObject overviewUI;

        [SerializeField]
        CourseInspectorBehavior inspect;

        [SerializeField]
        TurretShooterMethodBehavior shooter;

        void Start()
        {
            overviewUI.SetActive(true);
            manager = new GameManager(overviewUI, inspect, shooter, startPosition);
        }

        public void InspectCourse()
        {
            StartCoroutine(manager.InspectCourse());
        }

        public void Shoot()
        {
            StartCoroutine(manager.Shoot());
        }

    }

}