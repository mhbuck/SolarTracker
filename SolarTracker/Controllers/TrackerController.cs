using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SolarTracker.Models;

namespace SolarTracker.Controllers
{
    public class TrackerController : ApiController
    {
        private DataAccess _dataAccess;
        public TrackerController()
        {
            _dataAccess = new DataAccess();
        }

        [HttpGet]
        public CompassDetail Get()
        {
            // returning just the object will result in the object getting parsed into json so no need to manually do it.
            return _dataAccess.GetCurrentDetail();
        }

        [HttpPost]
        public void Post([FromBody] MotionDetail motion)
        {
            // The [FromBody] looks in the posted form data and creates an object with the properties based on the name posted in the form
            // I changed the index file to post different names
            _dataAccess.SaveMoveDetails(motion);
        }
    }
}
