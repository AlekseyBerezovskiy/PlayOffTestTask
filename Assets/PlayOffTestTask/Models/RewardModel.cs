namespace PlayOffTestTask.Models
{
    public class RewardModel
    {
        public string Type { get; }
        public int Amount { get; }

        public RewardModel(string type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}