namespace NancyByExample.API.Model
{
    public class Address
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }

        protected bool Equals(Address other)
        {
            return string.Equals(StreetName, other.StreetName) && string.Equals(StreetNumber, other.StreetNumber) && string.Equals(Postcode, other.Postcode) && string.Equals(City, other.City);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (StreetName != null ? StreetName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StreetNumber != null ? StreetNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Postcode != null ? Postcode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}