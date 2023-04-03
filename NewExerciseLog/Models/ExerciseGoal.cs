﻿using Microsoft.AspNetCore.Mvc;

namespace NewExerciseLog.UI.Models
{
    [BindProperties]
    public class ExerciseGoal
	{
		public int ExerciseGoalId { get; set; }

        public int UserId { get; set; }

        public string Exercise { get; set; }

        public string Goal { get; set; }

        public string Total { get; set;}
    }
}
