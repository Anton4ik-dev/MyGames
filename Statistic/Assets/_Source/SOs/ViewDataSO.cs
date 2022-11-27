using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ViewDataSO", menuName = "ScriptableObjects/ViewData", order = 1)]
    public class ViewDataSO : ScriptableObject
    {
        public string gravityRule;
        public List<string> descriptionForGravityRule;
        public string heightOfFalling;
        public List<string> descriptionForHeightOfFalling;
        public string secondNewton;
        public List<string> descriptionForSecondNewton;
        public string speed;
        public List<string> descriptionForSpeed;
        public string impulse;
        public List<string> descriptionForImpulse;
    }
}