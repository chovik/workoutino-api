namespace Workoutino.Api.Domain.Entities
{
    public class Weight
    {
        public int? Value { get; set; }
        public int? ValueFrom { get; set; }
        public int? ValueTo { get; set; }
        public WeightType Type { get; set; }

        public Weight(int? value, WeightType type)
        {
            Value = value;
            Type = type;
        }

        public Weight(int? valueFrom, int? valueTo, WeightType type)
        {
            ValueFrom = valueFrom;
            ValueTo = valueTo;
            Type = type;
        }
    }
}
