using SO;

namespace Formulas
{
    public class HeightOfFalling
    {
        private FieldsComponent _heightOfFallFields;
        private ViewDataSO _viewDataSO;
        public HeightOfFalling(FieldsComponent heightOfFallFields, ViewDataSO viewDataSO)
        {
            _heightOfFallFields = heightOfFallFields;
            _viewDataSO = viewDataSO;
            InitHeightOfFalling();
        }
        private void InitHeightOfFalling()
        {
            _heightOfFallFields.CalculateButton.onClick.AddListener(() => CalculateHeightOfFalling(_heightOfFallFields));
            _heightOfFallFields.Formula.text = _viewDataSO.heightOfFalling;
            for (int z = 0; z < _heightOfFallFields.FormulFields.Count; z++)
            {
                _heightOfFallFields.FormulFields[z].text = _viewDataSO.descriptionForHeightOfFalling[z];
            }
        }
        private void CalculateHeightOfFalling(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.InputFields[0].text, out float t);
            fieldComponent.AnswerField.text = Calculator.CountHeightOfFalling(t).ToString();
        }
    }
}