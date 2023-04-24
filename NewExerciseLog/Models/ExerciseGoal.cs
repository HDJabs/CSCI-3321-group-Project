using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewExerciseLog.UI.Models
{
    [BindProperties]
    public class ExerciseGoal
	{

        [Key]
		public int ExerciseGoalId { get; set; } = 0;

        public int UserId { get; set; } = 0;

        public int ExerciseId { get; set; } = 0;

        public string ExerciseName { get; set; } = "error";

        public string Goal { get; set; } = "12:34";

        public string Total { get; set; } = "00:00";

        public double Percent { get; set; } = 0.0;
    }
}
