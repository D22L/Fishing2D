using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fishing2D
{
    public class UIPopupWindow : UiWindow
    {
        [SerializeField] private Image _targetImage;
        [SerializeField] private TextMeshProUGUI _targetNameField;
        [SerializeField] private TextMeshProUGUI _targetWeightField;
        [SerializeField] private CollectFishButton _collectFishButton;
        public void Show(ICanGetCaught objData)
        {
            Show();
            _targetImage.sprite = objData.SpriteObj;
            _targetNameField.text = objData.SpriteObj.name;
            _targetWeightField.text = $"Weight: {Random.Range(1,5)}";
            _collectFishButton.SetCaughtObj(objData);
            
        }
    }
}
