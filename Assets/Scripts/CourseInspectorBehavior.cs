using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot
{

    public class CourseInspectorBehavior : MonoBehaviour, ICourseInspector
    {

        [SerializeField]
        private GameObject ui;

        private bool exitedOverview;

        void Start()
        {
            ui.SetActive(false);
        }

        public void StopInspecting()
        {
            exitedOverview = true;
        }

        public IEnumerator Inspect()
        {
            ui.SetActive(true);
            exitedOverview = false;
            yield return new WaitUntil(() => exitedOverview);
            ui.SetActive(false);
        }

    }

}