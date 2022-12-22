using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Formulas
{
    public class FieldsComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _formula;
        [SerializeField] private TextMeshProUGUI _answerField;
        [SerializeField] private Button _calculateButton;
        [SerializeField] private List<TextMeshProUGUI> _formulFields;
        [SerializeField] private List<TMP_InputField> _inputFields;
        public TextMeshProUGUI Formula { get => _formula;}
        public TextMeshProUGUI AnswerField { get => _answerField; }
        public Button CalculateButton { get => _calculateButton;}
        public List<TextMeshProUGUI> FormulFields { get => _formulFields;}
        public List<TMP_InputField> InputFields { get => _inputFields;}
    }
}