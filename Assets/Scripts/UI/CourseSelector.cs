using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlowhardJamboree.Moonshot.UI.CourseSelect
{
    public class CourseSelector : MonoBehaviour
    {
        [SerializeField]
        private GameObject currentCourseOptionObject;
        private CourseOptionDisplay currentCourseOptionDisplay;

        [SerializeField]
        private GameObject nextCourseOptionObject;
        private CourseOptionDisplay nextCourseOptionDisplay;

        [SerializeField]
        private GameObject previousCourseOptionObject;
        private CourseOptionDisplay previousCourseOptionDisplay;

        private List<CourseOption> courseOptions;

        private int currentCourseIndex;

        // Start is called before the first frame update
        void Start()
        {
            courseOptions = new List<CourseOption>();

            currentCourseOptionDisplay = currentCourseOptionObject.GetComponent<CourseOptionDisplay>();
            nextCourseOptionDisplay = nextCourseOptionObject.GetComponent<CourseOptionDisplay>();
            previousCourseOptionDisplay = previousCourseOptionObject.GetComponent<CourseOptionDisplay>();

            MakeTestOptions( 5 );
            currentCourseIndex = 0;
            SetOptionsDisplay();
        }

        public void GoToNext()
        {
            if( CurrentIsLast())
            {
                currentCourseIndex = 0;
            }
            else
            {
                currentCourseIndex += 1;
            }

            SetOptionsDisplay();
        }

        public void GoToPrevious()
        {
            if( currentCourseIndex != 0 )
            {
                currentCourseIndex -= 1;
            }
            else
            {
                currentCourseIndex = courseOptions.Count - 1;
            }
            
            SetOptionsDisplay();
        }


        private void SetOptionsDisplay()
        {
            currentCourseOptionDisplay.SetCourseDisplay( courseOptions[currentCourseIndex] );
            

            if (currentCourseIndex == 0)
            {
                previousCourseOptionDisplay.SetCourseDisplay( courseOptions.Last() );
            }
            else
            {
                previousCourseOptionDisplay.SetCourseDisplay(courseOptions[currentCourseIndex - 1]);
            }

            if( CurrentIsLast() )
            {
                nextCourseOptionDisplay.SetCourseDisplay(courseOptions.First());
                Debug.Log("Reached last");
            }
            else
            {
                nextCourseOptionDisplay.SetCourseDisplay(courseOptions[currentCourseIndex + 1]);
                
            }
            Debug.Log("Index: " + currentCourseIndex + "   Next: " + courseOptions.Count);
        }

        private void MakeTestOptions(int amount)
        {
            for( int i=0; i < amount ; i++)
            {
                CourseOption courseOption = new CourseOption();
                courseOption.CourseName = "Course " + i;
                courseOption.CourseDifficulty = CourseOption.EDifficulty.Easy;

                courseOptions.Add(courseOption);
            }
        }

        private bool CurrentIsLast()
        {
            if (courseOptions.Count < currentCourseIndex + 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
