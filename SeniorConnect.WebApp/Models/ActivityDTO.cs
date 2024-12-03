using System.ComponentModel.DataAnnotations;

namespace SeniorConnect.WebApp.Models
{
    public class ActivityDTO
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public string Description { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public DateOnly Date { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public TimeOnly StartTime { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public TimeOnly EndTime { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public int MaxParticipants { get; init; }


    }
}
