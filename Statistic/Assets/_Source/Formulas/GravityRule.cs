using SO;
using UnityEngine;

namespace Formulas
{
    public class GravityRule
    {
        private FieldsComponent _gravityFields;
        private ViewDataSO _viewDataSO;
        public GravityRule(FieldsComponent gravityFields, ViewDataSO viewDataSO)
        {
            _gravityFields = gravityFields;
            _viewDataSO = viewDataSO;
            InitGravityRule();
        }
        private void InitGravityRule()
        {
            _gravityFields.CalculateButton.onClick.AddListener(() => CalculateGravityRule(_gravityFields));
            _gravityFields.Formula.text = _viewDataSO.gravityRule;
            for (int z = 0; z < _gravityFields.FormulFields.Count; z++)
            {
                _gravityFields.FormulFields[z].text = _viewDataSO.descriptionForGravityRule[z];
            }
        }
        private void CalculateGravityRule(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.InputFields[0].text, out float m1);
            float.TryParse(fieldComponent.InputFields[1].text, out float m2);
            float.TryParse(fieldComponent.InputFields[2].text, out float r);
            fieldComponent.AnswerField.text = Calculator.CountGravityRule(m1, m2, r).ToString();
        }
    }
}