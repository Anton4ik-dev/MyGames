using SO;

namespace Formulas
{
    public class Speed
    {
        private FieldsComponent _speedFields;
        private ViewDataSO _viewDataSO;
        public Speed(FieldsComponent speedFields, ViewDataSO viewDataSO)
        {
            _speedFields = speedFields;
            _viewDataSO = viewDataSO;
            InitSpeed();
        }
        private void InitSpeed()
        {
            _speedFields.CalculateButton.onClick.AddListener(() => CalculateSpeed(_speedFields));
            _speedFields.Formula.text = _viewDataSO.speed;
            for (int z = 0; z < _speedFields.FormulFields.Count; z++)
            {
                _speedFields.FormulFields[z].text = _viewDataSO.descriptionForSpeed[z];
            }
        }
        private void CalculateSpeed(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.InputFields[0].text, out float s);
            float.TryParse(fieldComponent.InputFields[1].text, out float t);
            fieldComponent.AnswerField.text = Calculator.CountSpeed(s, t).ToString();
        }
    }
}