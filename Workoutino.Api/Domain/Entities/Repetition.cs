namespace Workoutino.Api.Domain.Entities
{
    public class Repetition
    {
        public int? Value { get; set; }
        public int? ValueFrom { get; set; }
        public int? ValueTo { get; set; }
        public RepetitionType Type { get; set; }

        public Repetition(int? value, RepetitionType type)
        {
            Value = value;
            Type = type;
        }

        public Repetition(int? valueFrom, int? valueTo, RepetitionType type)
        {
            ValueFrom = valueFrom;
            ValueTo = valueTo;
            Type = type;
        }
    }
}
