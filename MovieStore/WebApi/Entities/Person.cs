using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPassive { get; set; } = false;
        public string FullName => $"{FirstName} {LastName}";
    }
}