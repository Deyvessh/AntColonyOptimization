namespace TSPClassLib
{
    /// <summary>
    /// Class to generate City Result - this class contains the data that is loaded onto TSP GUI
    /// </summary>
    public class CityResult
    {
        #region Fields

        private City endCity;

        private City startCity;

        #endregion

        #region Constructors and Destructors

        public CityResult(City city1, City city2)
        {
            this.StartCity = city1;
            this.EndCity = city2;
        }

        #endregion

        #region Public Properties

        public double CityDistance { get; set; }

        public City EndCity
        {
            get
            {
                return this.endCity;
            }
            set
            {
                this.endCity = value;
                if (this.endCity != null)
                {
                    this.CityDistance = this.endCity.GetDistance(this.startCity);
                }
            }
        }

        public City StartCity
        {
            get
            {
                return this.startCity;
            }
            set
            {
                this.startCity = value;

                if (this.endCity != null)
                {
                    this.CityDistance = this.startCity.GetDistance(this.endCity);
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Override function ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("CityResult: {0} -> {1}", this.startCity.Id, this.EndCity.Id);
        }

        #endregion
    }
}