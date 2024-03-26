namespace UdemyCarBook.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public virtual List<RentACar> RentACars { get; set; }
    }
}
