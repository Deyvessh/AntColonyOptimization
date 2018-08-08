namespace TSPClassLib
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    #endregion

    /// <summary>
    /// class for creating CIty Graph
    /// </summary>
    public class CityGraph
    {
        #region Fields

        private readonly string inputFilePath;

        private readonly int spaceCountForDataFile;

        private readonly int w_height;

        private readonly int w_width;

        private readonly int zoomfactor;

        #endregion

        #region Constructors and Destructors

        public CityGraph(string filepath, int wWidth, int wHeight)
        {
            this.inputFilePath = filepath;

            this.w_width = wWidth;
            this.w_height = wHeight;

            this.spaceCountForDataFile = 3;

            this.zoomfactor = 2;

            this.Cities = new List<City>();

            this.LoadCityGraph();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// List of cities
        /// </summary>
        public List<City> Cities { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Function to clone CityGraph
        /// </summary>
        /// <returns></returns>
        public CityGraph Clone()
        {
            return new CityGraph(this.inputFilePath, this.w_width, this.w_height);
        }

        /// <summary>
        /// function to get distance between cities
        /// </summary>
        /// <param name="sourceCity"></param>
        /// <param name="destinationCity"></param>
        /// <returns></returns>
        public double GetDistance(City sourceCity, City destinationCity)
        {
            if (sourceCity != null && destinationCity != null)
            {
                return
                    Convert.ToDouble(
                        Math.Sqrt(
                            Math.Pow(sourceCity.CityCoordinates.XValue - destinationCity.CityCoordinates.XValue, 2)
                            + Math.Pow(sourceCity.CityCoordinates.YValue - destinationCity.CityCoordinates.YValue, 2)))
                    / this.zoomfactor;
            }

            return 0;
        }

        /// <summary>
        /// overloaded function to get distance between cities
        /// </summary>
        /// <param name="city_1_Id"></param>
        /// <param name="city_2_Id"></param>
        /// <returns></returns>
        public double GetDistance(string city_1_Id, string city_2_Id)
        {
            City sourceCity = this.Cities.FirstOrDefault(c => c.Id == city_1_Id);
            City destinationCity = this.Cities.FirstOrDefault(c => c.Id == city_2_Id);

            if (sourceCity != null && destinationCity != null)
            {
                return
                    Convert.ToDouble(
                        Math.Sqrt(
                            Math.Pow(sourceCity.CityCoordinates.XValue - destinationCity.CityCoordinates.XValue, 2)
                            + Math.Pow(sourceCity.CityCoordinates.YValue - destinationCity.CityCoordinates.YValue, 2)));
            }

            return -1;
        }

        #endregion

        #region Methods

        private City CreateCityFromStringData(string line)
        {
            if (
                !line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                     .Count()
                     .Equals(this.spaceCountForDataFile) || !this.validateData(line))
            {
                throw new FormatException("Invalid data format for coordinates");
            }

            string[] data = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (this.spaceCountForDataFile < 3)
            {
                return
                    new City(
                        new Coordinates(
                            Convert.ToInt32(data[this.spaceCountForDataFile - 2]) * this.zoomfactor,
                            Convert.ToInt32(data[this.spaceCountForDataFile - 1]) * this.zoomfactor));
            }
            return
                new City(
                    new Coordinates(
                        Convert.ToInt32(data[this.spaceCountForDataFile - 2]) * this.zoomfactor,
                        Convert.ToInt32(data[this.spaceCountForDataFile - 1]) * this.zoomfactor))
                    {
                        Id =
                            data[
                                this
                                    .spaceCountForDataFile
                                - 3]
                    };
        }

        private void LoadCityGraph()
        {
            this.ValidateFilename();

            this.Loadgraphfromfile();

            this.NormalizeContext();
        }

        private void Loadgraphfromfile()
        {
            bool headerEnds = false;

            foreach (string line in File.ReadLines(this.inputFilePath))
            {
                //if header found
                if (
                    !line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                         .Count()
                         .Equals(this.spaceCountForDataFile) || !this.validateData(line))
                {
                    if (line.Trim().Equals("EOF"))
                    {
                        return;
                    }

                    if (headerEnds)
                    {
                        throw new FormatException("Invalid format of file");
                    }

                    headerEnds = false;
                    continue;
                }

                ////header ended
                headerEnds = true;
                ////loading cities from data file.
                this.Cities.Add(this.CreateCityFromStringData(line));
            }
        }

        private void NormalizeContext()
        {
        }

        private void ValidateFilename()
        {
            if (!File.Exists(this.inputFilePath))
            {
                throw new FileNotFoundException();
            }
        }

        private bool validateData(string line)
        {
            int integerConvertedData;

            return int.TryParse(line.Replace(" ", ""), out integerConvertedData);
        }

        #endregion
    }
}