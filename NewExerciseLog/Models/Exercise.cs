using Microsoft.AspNetCore.Mvc;

namespace NewExerciseLog.UI.Models
{
    [BindProperties]
    public class Exercise
	{
		public int ExerciseId { get; set; }

		public string ExerciseName { get; set;}
	}
}
