using Formulas;
using SO;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private FieldsComponent gravityFields;
        [SerializeField] private FieldsComponent heightOfFallFields;
        [SerializeField] private FieldsComponent newtonFields;
        [SerializeField] private FieldsComponent speedFields;
        [SerializeField] private FieldsComponent impulseFields;
        [SerializeField] private ViewDataSO viewDataSO;
        private void Awake()
        {
            new GravityRule(gravityFields, viewDataSO);
            new HeightOfFalling(heightOfFallFields, viewDataSO);
            new SecondNewton(newtonFields, viewDataSO);
            new Speed(speedFields, viewDataSO);
            new Impulse(impulseFields, viewDataSO);
        }
    }
}