using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Formulas
{
    public class FieldsComponent : MonoBehaviour
    {
        public TextMeshProUGUI formula;
        public TextMeshProUGUI answerField;
        public Button calculateButton;
        public List<TextMeshProUGUI> formulFields;
        public List<TMP_InputField> inputFields;
    }
}