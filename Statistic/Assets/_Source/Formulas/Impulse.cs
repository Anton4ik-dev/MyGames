using SO;

namespace Formulas
{
    public class Impulse
    {
        private FieldsComponent _impulseFields;
        private ViewDataSO _viewDataSO;
        public Impulse(FieldsComponent impulseFields, ViewDataSO viewDataSO)
        {
            _impulseFields = impulseFields;
            _viewDataSO = viewDataSO;
            InitImpulse();
        }
        private void InitImpulse()
        {
            _impulseFields.CalculateButton.onClick.AddListener(() => CalculateImpulse(_impulseFields));
            _impulseFields.Formula.text = _viewDataSO.impulse;
            for (int z = 0; z < _impulseFields.FormulFields.Count; z++)
            {
                _impulseFields.FormulFields[z].text = _viewDataSO.descriptionForImpulse[z];
            }
        }
        private void CalculateImpulse(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.InputFields[0].text, out float m);
            float.TryParse(fieldComponent.InputFields[1].text, out float v);
            fieldComponent.AnswerField.text = Calculator.CountImpulse(m, v).ToString();
        }
    }
}