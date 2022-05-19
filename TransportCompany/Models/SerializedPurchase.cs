namespace TransportCompany.Models
{
    public class SerializedPurchase
    {
        public string Serialized { get; set; }

        public SerializedPurchase(string serialized)
        {
            Serialized = serialized;
        }

        public SerializedPurchase() { }
    }
}
