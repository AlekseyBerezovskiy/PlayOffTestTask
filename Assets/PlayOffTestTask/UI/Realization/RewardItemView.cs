using PlayOffTestTask.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace PlayOffTestTask.UI
{
    public class RewardItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rewardText;

        public void SetData(RewardModel model)
        {
            rewardText.text = $"{model.Type} x{model.Amount}";
        }

        public class Pool : MonoMemoryPool<RewardItemView>
        { }
    }
}