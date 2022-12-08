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

    public class FuelInfoController : Controller
    {
        private readonly IStationServices<FuelInfo> _fuelInfoIs;

        public FuelInfoController(IStationServices<FuelInfo> FuelInfo)
        {
            _fuelInfoIs = FuelInfo;
        }

        // GET: FuelInfo
        [HttpGet]
        public ActionResult GetFuelInfo()
        {
            var fuelInfoData = _fuelInfoIs.GetAllRows();
            return Ok(fuelInfoData);
        }

        // GET: FuelInfoController/Details/5
        [HttpGet("Details")]
        public ActionResult Details(FuelInfo GetFuelInfo)
        {
            FuelInfo fuelDetails = _fuelInfoIs.GetRowById(GetFuelInfo.FuelId);
            return Ok(fuelDetails);
        }

        // POST: FuelInfoController/Create
        [HttpPost]
        public ActionResult Create([FromBody] FuelInfo newFuel)
        {
            try
            {
                _fuelInfoIs.AddRow(newFuel);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
        // POST: FuelInfoController/Edit/5
        [HttpPut]
        public ActionResult Edit([FromBody] FuelInfo editFuel)
        {
            if (_fuelInfoIs.UpdateRow(editFuel.FuelId, editFuel))
                return Ok();
            else
                return NotFound();
        }

        // POST: FuelInfoController/Delete/5
        [HttpDelete]
        public ActionResult Delete([FromBody] FuelInfo deleteFuel)
        {
            try
            {
                FuelInfo fuelDetails = _fuelInfoIs.GetRowById(deleteFuel.FuelId);
                _fuelInfoIs.DeleteRow(fuelDetails);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}