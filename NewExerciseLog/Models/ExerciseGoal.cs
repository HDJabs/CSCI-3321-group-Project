namespace NewExerciseLog.UI.Models
{
	public class ExerciseGoal
	{
		public int ExerciseGoalId { get; set; }

        public int UserId { get; set; }

        public int ExerciseID { get; set; }

        public string Goal { get; set; }

        public string Total { get; set;}
    }
}
