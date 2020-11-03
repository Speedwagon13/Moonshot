using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot
{

    public class GameManagerBehavior : MonoBehaviour
    {

        [SerializeField]
        GameObject uiPanel;

        [SerializeField, SerializeReference]
        private ICourseInspector inspect;

        public void InspectCourse()
        {
            StartCoroutine(InspectCourseAsync());
        }

        public void Put()
        {

        }

        IEnumerator InspectCourseAsync()
        {
            uiPanel.SetActive(false);
            yield return inspect.Inspect();
            uiPanel.SetActive(true);
        }

    }

}