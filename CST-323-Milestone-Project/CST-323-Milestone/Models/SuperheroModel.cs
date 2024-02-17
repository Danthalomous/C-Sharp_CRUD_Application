namespace CST_323_Milestone.Models
{
    public class SuperheroModel
    {
        // Declaring the properties for the model
        public int SuperheroID { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Powers { get; set; }
        public float PowerRating { get; set; }
        public string Alignment { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SuperheroModel()
        {
            SuperheroID = 0;
            Alias = null;
            Name = null;
            Powers = null;
            PowerRating = 0;
            Alignment = null;
            Price = 0;
            Qty = 0;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="superheroID"></param>
        /// <param name="alias"></param>
        /// <param name="name"></param>
        /// <param name="powers"></param>
        /// <param name="powerRating"></param>
        /// <param name="alignment"></param>
        /// <param name="price"></param>
        /// <param name="qty"></param>
        public SuperheroModel(int superheroID, string alias, string name, string powers, float powerRating, string alignment, float price, int qty)
        {
            SuperheroID = superheroID;
            Alias = alias;
            Name = name;
            Powers = powers;
            PowerRating = powerRating;
            Alignment = alignment;
            Price = price;
            Qty = qty;
        }
    }
}
