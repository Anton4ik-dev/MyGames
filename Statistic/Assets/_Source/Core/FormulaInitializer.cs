using SO;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class FormulaInitializer : MonoBehaviour
    {
        [SerializeField] private List<FieldsComponent> fieldsComponents;
        [SerializeField] private ViewDataSO viewDataSO;
        private void Awake()
        {
            InitGravityRule();
            InitHeightOfFalling();
            InitSecondNewton();
            InitSpeed();
            InitImpulse();
        }
        private void InitGravityRule()
        {
            fieldsComponents[0].calculateButton.onClick.AddListener(() => CalculateGravityRule(fieldsComponents[0]));
            fieldsComponents[0].formula.text = viewDataSO.gravityRule;
            for (int z = 0; z < fieldsComponents[0].formulFields.Count; z++)
            {
                fieldsComponents[0].formulFields[z].text = viewDataSO.descriptionForGravityRule[z];
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
            fieldsComponents[1].calculateButton.onClick.AddListener(() => CalculateHeightOfFalling(fieldsComponents[1]));
            fieldsComponents[1].formula.text = viewDataSO.heightOfFalling;
            for (int z = 0; z < fieldsComponents[1].formulFields.Count; z++)
            {
                fieldsComponents[1].formulFields[z].text = viewDataSO.descriptionForHeightOfFalling[z];
            }
        }
        private void CalculateHeightOfFalling(FieldsComponent fieldComponent)
        {
            float.TryParse(fieldComponent.inputFields[0].text, out float t);
            fieldComponent.answerField.text = Calculator.CountHeightOfFalling(t).ToString();
        }
        private void InitSecondNewton()
        {
            fieldsComponents[2].calculateButton.onClick.AddListener(() => CalculateSecondNewton(fieldsComponents[2]));
            fieldsComponents[2].formula.text = viewDataSO.secondNewton;
            for (int z = 0; z < fieldsComponents[2].formulFields.Count; z++)
            {
                fieldsComponents[2].formulFields[z].text = viewDataSO.descriptionForSecondNewton[z];
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
            fieldsComponents[3].calculateButton.onClick.AddListener(() => CalculateSpeed(fieldsComponents[3]));
            fieldsComponents[3].formula.text = viewDataSO.speed;
            for (int z = 0; z < fieldsComponents[3].formulFields.Count; z++)
            {
                fieldsComponents[3].formulFields[z].text = viewDataSO.descriptionForSpeed[z];
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
            fieldsComponents[4].calculateButton.onClick.AddListener(() => CalculateImpulse(fieldsComponents[4]));
            fieldsComponents[4].formula.text = viewDataSO.impulse;
            for (int z = 0; z < fieldsComponents[4].formulFields.Count; z++)
            {
                fieldsComponents[4].formulFields[z].text = viewDataSO.descriptionForImpulse[z];
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