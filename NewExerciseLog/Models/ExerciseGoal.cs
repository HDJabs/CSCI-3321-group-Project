using Microsoft.AspNetCore.Mvc;

namespace NewExerciseLog.UI.Models
{
    [BindProperties]
    public class ExerciseGoal
	{
		public ExerciseGoal() { }
		public ExerciseGoal(int userId, int exerciseId, string goal, string total)
		{
			UserId = userId;
			ExerciseId = exerciseId;
			Goal = goal;
			Total = total;
		}

		public int ExerciseGoalId { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

		public string ExerciseName { get; set; }

        public string Goal { get; set; }

        public string Total { get; set;}
    }
}
