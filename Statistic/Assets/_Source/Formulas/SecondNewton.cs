using SO;

namespace Formulas
{
    public class SecondNewton
    {
        private FieldsComponent _newtonFields;
        private ViewDataSO _viewDataSO;
        public SecondNewton(FieldsComponent secondnewtonFields, ViewDataSO viewDataSO)
        {
            _newtonFields = secondnewtonFields;
            _viewDataSO = viewDataSO;
            InitSecondNewton();
        }
        private void InitSecondNewton()
        {
            _newtonFields.CalculateButton.onClick.AddListener(() => CalculateSecondNewton(_newtonFields));
            _newtonFields.Formula.text = _viewDataSO.secondNewton;
            for (int z = 0; z < _newtonFields.FormulFields.Count; z++)
            {
                _newtonFields.FormulFields[z].text = _viewDataSO.descriptionForSecondNewton[z];
            }
        }
        private void CalculateSecondNewton(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.InputFields[0].text, out float F);
            float.TryParse(fieldComponent.InputFields[1].text, out float m);
            fieldComponent.AnswerField.text = Calculator.CountSecondNewton(F, m).ToString();
        }
    }
}