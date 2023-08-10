using TaskFrom1C.SceneObjectsStorage;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TaskFrom1C.UI
{
    public class UIEndGameWindow : SceneObject
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private TextMeshProUGUI windowText;

        private const string WinText = "Победа";
        private const string LoseText = "Поражение";
        
        public void SetText(bool isLose)
        {
            windowText.SetText(isLose ? LoseText : WinText);
        }
        
        private void OnEnable()
        {
            restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}