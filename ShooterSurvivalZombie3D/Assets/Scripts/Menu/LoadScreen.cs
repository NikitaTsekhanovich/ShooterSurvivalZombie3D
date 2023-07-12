using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class LoadScreen : MonoBehaviour
    { 
        [SerializeField] private Text _loadingPercentage;
        [SerializeField] private Image _loadingProgressBar;
    
        private static LoadScreen _loadScreen;
        private static bool _shouldPlayOpeningAnimation; 
    
        private Animator _animator;
        private AsyncOperation _loadingSceneOperation;
        
        private void Start()
        {
            _loadScreen = this;
            _animator = GetComponent<Animator>();
            FadeScreen();
        }

        private void FadeScreen()
        {
            if (_shouldPlayOpeningAnimation)
            {
                _animator.SetTrigger("sceneEnd");
                _loadScreen._loadingProgressBar.fillAmount = 1;
                _shouldPlayOpeningAnimation = false;
            }
        }

        private void Update()
        {
            StartLoadScreen();
        }

        private void StartLoadScreen()
        {
            if (_loadingSceneOperation != null)
            {
                _loadingPercentage.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";
                _loadingProgressBar.fillAmount = _loadingSceneOperation.progress;
                _loadingProgressBar.fillAmount = Mathf.Lerp(_loadingProgressBar.fillAmount, _loadingSceneOperation.progress,
                    Time.deltaTime * 5);
            }
        }

        public static void SwitchToScene(string sceneName)
        {
            _loadScreen._animator.SetTrigger("sceneStart");

            _loadScreen._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            
            _loadScreen._loadingSceneOperation.allowSceneActivation = false;
            _loadScreen._loadingProgressBar.fillAmount = 0;
        }

        public void OnAnimationOver()
        {
            _shouldPlayOpeningAnimation = true;
            _loadingSceneOperation.allowSceneActivation = true;
        }
    }
}