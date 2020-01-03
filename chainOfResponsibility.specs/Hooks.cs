using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace chainOfResponsibility.specs
{
    [Binding]
    public class Hooks
    {
        [StepArgumentTransformation(@"(.*)")]
        public double? ToNullableDouble(string value)
        {
            return value == null ? default(double?) : double.Parse(value);
        }
        [StepArgumentTransformation(@"null")]
        public string ToNull()
        {
            return null;
        }
    }
}
