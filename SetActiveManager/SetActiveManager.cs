using UnityEngine;

namespace YDJ
{
    public class SetActiveManager : MonoBehaviour
    {
        [SerializeField] int stageNum;
        [SerializeField] GameObject[] stage1Start;

        private void Start()
        {
            switch (stageNum)
            {
                case 1:
                    stage1();
                    break;

            }
        }

        public void stage1()
        {
            foreach (GameObject stage1 in stage1Start)
            {
                stage1.SetActive(true);
            }
        }
    }
}
