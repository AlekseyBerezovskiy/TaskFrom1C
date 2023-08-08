using TaskFrom1C.SceneObjectsStorage;
using TMPro;
using UnityEngine;

namespace TaskFrom1C.UI
{
    public class UIHealthBar : SceneObject
    {
        [SerializeField] private TextMeshProUGUI healthText;

        public void SetHealthValue(int health)
        {
            healthText.SetText(health.ToString());
        }
    }
}