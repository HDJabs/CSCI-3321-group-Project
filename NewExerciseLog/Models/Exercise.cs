using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewExerciseLog.UI.Models
{
    [BindProperties]
    public class Exercise
	{
		[Key]
		public int ExerciseId { get; set; }

		public string ExerciseName { get; set;}
	}
}
