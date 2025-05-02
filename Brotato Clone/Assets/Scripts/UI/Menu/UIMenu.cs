using UnityEngine;
using UnityEngine.UI;

namespace BrotatoClone.UI
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;

        private void Awake() => ShowUI();

        private void OnEnable()
        {
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            Debug.Log("Game Started");
            HideUI();
        }

        public void ShowUI() => this.gameObject.SetActive(true);
        public void HideUI() => this.gameObject.SetActive(false);
    }
}