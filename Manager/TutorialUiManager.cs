using System.Collections;
using UnityEngine;

namespace YDJ
{
    public class TutorialUiManager : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] WindowUI tutorialImagePrefab;

        [Space(15)]
        [Header("Property")]
        [SerializeField] bool startShow;

        [Space(15)]
        [SerializeField] bool whenStart_delayClose;
        [SerializeField] float delayTime;
        private WindowUI tutorial;

        [Space(15)]
        [SerializeField] bool singleUI;

        private void Start()
        {
            if (!startShow)
                return;
            ShowTutorial();
        }

        public void ShowTutorial()
        {
            if (singleUI)
            {
                if (Manager.Game.LobbyUIData.see)
                    return;
                else
                    Manager.Game.LobbyUIData.see = true;
            }

            tutorial = Manager.UI.ShowWindowUI(tutorialImagePrefab);

            if (whenStart_delayClose)
            {
                StartCoroutine(delay());
            }
        }

        public void CloseTutorial()
        {
            if (tutorial != null)
                tutorial.Close();
        }

        IEnumerator delay()
        {
            yield return new WaitForSeconds(delayTime);
            CloseTutorial();
        }
    }
}
