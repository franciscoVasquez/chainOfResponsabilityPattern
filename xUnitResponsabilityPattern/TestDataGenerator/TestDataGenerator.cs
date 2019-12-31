using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using responsibilityPattern;
using startingTestconsoleApp.Models;

namespace xUnitResponsabilityPattern.TestDataGenerator
{
    [ExcludeFromCodeCoverage]
    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly string _expected = string.Join("\n", 
            "Client: Who wants a Nut?   Squirrel: I'll eat the Nut.",
            "Client: Who wants a Banana?   Monkey: I'll eat the Banana.",
            "Client: Who wants a Milk?   Milk was left untouched.\n");
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Animal>(), string.Empty
            };
            yield return new object[]
            {
                null, string.Empty
            };
            yield return new object[]
            {
                new List<Animal>
                {
                    new Animal {Food = "Nut", Specie = "Squirrel"},
                    new Animal {Food = "Banana", Specie = "Monkey"},
                    new Animal {Food = "Milk", Specie = "Cat"}
                },
                _expected
            };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}