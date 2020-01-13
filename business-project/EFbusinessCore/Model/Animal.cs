using System.ComponentModel.DataAnnotations;

namespace EFBusinessCore.Model
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Specie { get; set; }
        public string Food { get; set; }
    }
}