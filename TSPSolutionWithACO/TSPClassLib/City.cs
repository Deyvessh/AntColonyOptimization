namespace TSPClassLib
{
    using System;
    
    /// <summary>
    /// class to define a city 
    /// </summary>
    public class City
    {
        #region Constructors and Destructors

        public City(Coordinates coordinates)
        {
            this.Name = String.Format("City {0}_{1}", coordinates.XValue, coordinates.YValue);

            this.CityCoordinates = new Coordinates(coordinates.XValue, coordinates.YValue);
        }

        public City(Coordinates coordinates, string cityName)
            : this(coordinates)
        {
            this.Name = cityName;
        }

        public City(Coordinates coordinates, string cityName, string id)
            : this(coordinates, cityName)
        {
            this.Name = cityName;
            this.Id = id;
        }

        #endregion

        #region Public Properties

        public Coordinates CityCoordinates { get; set; }

        public string Id { get; set; }

        public bool IsVisited { get; set; }

        public string Name { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// funcion to get distance between a city from current city
        /// </summary>
        /// <param name="destinationCity"></param>
        /// <returns></returns>
        public double GetDistance(City destinationCity)
        {
            if (destinationCity != null)
            {
                return
                    Convert.ToDouble(
                        Math.Sqrt(
                            Math.Pow(this.CityCoordinates.XValue - destinationCity.CityCoordinates.XValue, 2)
                            + Math.Pow(this.CityCoordinates.YValue - destinationCity.CityCoordinates.YValue, 2)));
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} ({1},{2}), {3}",
                this.Id,
                this.CityCoordinates.XValue,
                this.CityCoordinates.YValue,
                this.IsVisited ? "Visited" : "Not-Visited");
        }

        #endregion
    }
}