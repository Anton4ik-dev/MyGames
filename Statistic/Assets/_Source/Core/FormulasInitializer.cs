using SO;
using System.Collections.Generic;
using UnityEngine;

namespace Formulas
{
    public class FormulasInitializer
    {
        private FieldsComponent _gravityFields;
        private FieldsComponent _heightOfFallFields;
        private FieldsComponent _newtonFields;
        private FieldsComponent _speedFields;
        private FieldsComponent _impulseFields;
        private ViewDataSO _viewDataSO;
        public FormulasInitializer(FieldsComponent gravityFields, FieldsComponent heightOfFallFields, FieldsComponent newtonFields, FieldsComponent speedFields, FieldsComponent impulseFields, ViewDataSO viewDataSO)
        {
            _gravityFields = gravityFields;
            _heightOfFallFields = heightOfFallFields;
            _newtonFields = newtonFields;
            _speedFields = speedFields;
            _impulseFields = impulseFields;
            _viewDataSO = viewDataSO;
            InitRules();
        }
        private void InitRules()
        {
            InitGravityRule();
            InitHeightOfFalling();
            InitSecondNewton();
            InitSpeed();
            InitImpulse();
        }
        private void InitGravityRule()
        {
            _gravityFields.calculateButton.onClick.AddListener(() => CalculateGravityRule(_gravityFields));
            _gravityFields.formula.text = _viewDataSO.gravityRule;
            for (int z = 0; z < _gravityFields.formulFields.Count; z++)
            {
                _gravityFields.formulFields[z].text = _viewDataSO.descriptionForGravityRule[z];
            }
        }
        private void CalculateGravityRule(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.inputFields[0].text, out float m1);
            float.TryParse(fieldComponent.inputFields[1].text, out float m2);
            float.TryParse(fieldComponent.inputFields[2].text, out float r);
            fieldComponent.answerField.text = Calculator.CountGravityRule(m1, m2, r).ToString();
        }
        private void InitHeightOfFalling()
        {
            _heightOfFallFields.calculateButton.onClick.AddListener(() => CalculateHeightOfFalling(_heightOfFallFields));
            _heightOfFallFields.formula.text = _viewDataSO.heightOfFalling;
            for (int z = 0; z < _heightOfFallFields.formulFields.Count; z++)
            {
                _heightOfFallFields.formulFields[z].text = _viewDataSO.descriptionForHeightOfFalling[z];
            }
        }
        private void CalculateHeightOfFalling(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.inputFields[0].text, out float t);
            fieldComponent.answerField.text = Calculator.CountHeightOfFalling(t).ToString();
        }
        private void InitSecondNewton()
        {
            _newtonFields.calculateButton.onClick.AddListener(() => CalculateSecondNewton(_newtonFields));
            _newtonFields.formula.text = _viewDataSO.secondNewton;
            for (int z = 0; z < _newtonFields.formulFields.Count; z++)
            {
                _newtonFields.formulFields[z].text = _viewDataSO.descriptionForSecondNewton[z];
            }
        }
        private void CalculateSecondNewton(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.inputFields[0].text, out float F);
            float.TryParse(fieldComponent.inputFields[1].text, out float m);
            fieldComponent.answerField.text = Calculator.CountSecondNewton(F, m).ToString();
        }
        private void InitSpeed()
        {
            _speedFields.calculateButton.onClick.AddListener(() => CalculateSpeed(_speedFields));
            _speedFields.formula.text = _viewDataSO.speed;
            for (int z = 0; z < _speedFields.formulFields.Count; z++)
            {
                _speedFields.formulFields[z].text = _viewDataSO.descriptionForSpeed[z];
            }
        }
        private void CalculateSpeed(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.inputFields[0].text, out float s);
            float.TryParse(fieldComponent.inputFields[1].text, out float t);
            fieldComponent.answerField.text = Calculator.CountSpeed(s, t).ToString();
        }
        private void InitImpulse()
        {
            _impulseFields.calculateButton.onClick.AddListener(() => CalculateImpulse(_impulseFields));
            _impulseFields.formula.text = _viewDataSO.impulse;
            for (int z = 0; z < _impulseFields.formulFields.Count; z++)
            {
                _impulseFields.formulFields[z].text = _viewDataSO.descriptionForImpulse[z];
            }
        }
        private void CalculateImpulse(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.inputFields[0].text, out float m);
            float.TryParse(fieldComponent.inputFields[1].text, out float v);
            fieldComponent.answerField.text = Calculator.CountImpulse(m, v).ToString();
        }
    }
}