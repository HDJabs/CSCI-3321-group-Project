namespace NewExerciseLog.UI.Models
{
	public class ExerciseGoal
	{
		public int ExerciseGoalId { get; set; }

        public User User { get; set; }

        public Exercise Exercise { get; set; }

        public string Goal { get; set; }

        public string Total { get; set;}
    }
}
