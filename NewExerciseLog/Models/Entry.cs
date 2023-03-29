namespace NewExerciseLog.UI.Models
{
	public class Entry
	{
		public int EntryId { get; set; }

		public DateTime EntryDate { get; set; }
		
		public ExerciseGoal ExerciseGoal { get; set; }

		public int HoursExercised { get; set; }

		public int MinutesExercised { get; set; }
	}
}
