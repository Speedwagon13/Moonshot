using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BlowhardJamboree.Moonshot.UI.CourseSelect
{


    public class CourseOptionDisplay : MonoBehaviour
    {

        [SerializeField]
        private GameObject difficultyObject;
        private Text difficultyComponent;

        [SerializeField]
        private GameObject imageObject;
        private Image imageComponent;

        [SerializeField]
        private GameObject nameObject;
        private Text nameComponent;

        private void Start()
        {
            difficultyComponent = difficultyObject.GetComponent<Text>();
            //imageComponent = imageComponent.GetComponent<Image>();
            nameComponent = nameObject.GetComponent<Text>();
        }

        public void SetCourseDisplay( CourseOption courseOption)
        {
            difficultyComponent.text = courseOption.CourseDifficulty.ToString();
            nameComponent.text = courseOption.CourseName;
        }
    }
}

