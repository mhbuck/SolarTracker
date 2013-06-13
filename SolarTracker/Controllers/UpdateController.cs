using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SolarTracker.Models;

namespace SolarTracker.Controllers
{
    public class UpdateController : ApiController
    {
        private DataAccess _dataAccess;
        public UpdateController()
        {
            _dataAccess = new DataAccess();
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            string[] compassValues = value.Split(',');

            // Parse the post into an object that can be worked with and then passed to the data access
            var currentData = new CompassDetail
                {
                    Heading = Convert.ToDecimal(compassValues[1]),
                    Pitch = Convert.ToDecimal(compassValues[2]),
                    Roll = Convert.ToDecimal(compassValues[3]),
                    ImpVoltage = Convert.ToDecimal(compassValues[4]),
                    SolarAzimuth = Convert.ToDecimal(compassValues[5]),
                    SolarElevation = Convert.ToDecimal(compassValues[6]),
                    ImpId = Convert.ToInt32(compassValues[0])
                };

            _dataAccess.UpdatePosition(currentData);

        }
    }
}
