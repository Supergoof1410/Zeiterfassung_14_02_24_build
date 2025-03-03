namespace Zeiterfassung_WPF
{
    public class Person
    {
        internal int? Person_ID { get; set; }
        public string? Tn_Value { get; set; }
        internal string? Firstname { get; set; }
        internal string? Lastname { get; set; }
        internal string? LoginTime { get; set; }
        internal string? LogoutTime { get; set; }
        internal int? Day { get; set; }
        internal int? Month { get; set; }
        internal int? Year { get; set; }
        internal string? diffTime { get; set; }
        internal int SummaryHoursMonth { get; set; }
    }
}
