using BrotatoClone.Data;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoClone.UI
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;

        private UIMenuController uiMenuController;

        private void Awake() => ShowUI();

        private void OnEnable()
        {
            startButton.onClick.AddListener(StartGame);
        }

        public void SetController(UIMenuController uIMenuController)
        {
            this.uiMenuController = uIMenuController;
        }

        private void StartGame()
        {
            uiMenuController.HandleStartGame();
            HideUI();
        }

        public void ShowUI() => this.gameObject.SetActive(true);
        public void HideUI() => this.gameObject.SetActive(false);
    }
}