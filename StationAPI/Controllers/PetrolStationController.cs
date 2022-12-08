using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StationAPI.DataAccess;
using StationAPI.Models;

namespace StationAPI.Controllers
{
    [Route("api/[controller]")]

    public class PetrolStationController : Controller
    {
        private readonly IStationServices<PetrolStation> _stationIs;

        public PetrolStationController(IStationServices<PetrolStation> PetrolStationervice,
            IStationServices<FuelInfo> FuelInfo)
        {
            _stationIs = PetrolStationervice;
        }

        // GET: PetrolStation
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var stationData = _stationIs.GetAllRows();
            return Ok(stationData);
        }


        //https://localhost:44310/api/stations/Details?CustomerId=1
        // GET: Customer/Details/5
        [HttpGet("Details")]
        public ActionResult Details(PetrolStation GetStation)
        {
            PetrolStation stationDetails = _stationIs.GetRowById(GetStation.StationId);
            return Ok(stationDetails);
        }

        // POST: CustomerController/Create
        [HttpPost]
        public ActionResult Create([FromBody] PetrolStation newCustomer)
        {
            try
            {
                _stationIs.AddRow(newCustomer);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Customer/Edit/5
        [HttpPut]
        public ActionResult Edit([FromBody] PetrolStation editPetrolStation)
        {
            if (_stationIs.UpdateRow(editPetrolStation.StationId, editPetrolStation))
                return Ok();
            else
                return NotFound();
        }

        // POST: CustomerController/Delete/5
        [HttpDelete]
        public ActionResult Delete([FromBody] PetrolStation deleteCustomer)
        {
            try
            {
                PetrolStation stationDetails = _stationIs.GetRowById(deleteCustomer.StationId);
                _stationIs.DeleteRow(stationDetails);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
