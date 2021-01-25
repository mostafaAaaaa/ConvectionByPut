using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convection.ApplicationServices.IServices;
using Convection.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Convection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorServices _IVendorServices;



        public VendorController(IVendorServices iVendorServices)
        {
            _IVendorServices = iVendorServices;
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorById([FromRoute] int id)
        {
            var responseGetVendorById = _IVendorServices.GetVendorByIdervices(id);
            if (responseGetVendorById != null)
            {
                return Ok(responseGetVendorById);
            }
            else
            {
                return StatusCode(500);
            }


        }
        [HttpPost]
        public IActionResult AddVendor(InsertVendorDto dto)
        {
            var responseInsert = _IVendorServices.InsertNewVendorServices(dto);
            return Created(new Uri($"api/Vendor/{responseInsert.Id}", UriKind.Relative), responseInsert);

        }


        [HttpPut("{id}")]
        public IActionResult UpdateVendor([FromRoute] int id, UpdateVendorDto dto)
        {
          

                var responseUpdateVendorByPut = _IVendorServices.UpdateVendorServicesByPut(dto, id);
                if (responseUpdateVendorByPut)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
        


        [HttpPatch("{id}")]
        public IActionResult UpdateVendor([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateVendorDto> vendorPatch)
        {

            var vendor = _IVendorServices.GetVendorByIdervices(id);
            UpdateVendorDto updateVendorDto = new UpdateVendorDto();
            updateVendorDto.Adress = vendor.Adress;
            updateVendorDto.Date = vendor.Date;
            updateVendorDto.Email = vendor.Email;
            updateVendorDto.Gender = vendor.Gender;
            updateVendorDto.PhoneNumber = vendor.PhoneNumber;
            updateVendorDto.Title = vendor.Title;
            updateVendorDto.VendorName = vendor.VendorName;
            vendorPatch.ApplyTo(updateVendorDto);

            var responseUpdateVendorByPatch = _IVendorServices.UpdateVendorServices(updateVendorDto, id);
              
                if (responseUpdateVendorByPatch)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
        


        [HttpDelete("{id}")]
        public IActionResult DeleteVendor([FromRoute] int id)
        {
            var responseDelete= _IVendorServices.DeleteVendorServices(id);
            if (responseDelete)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
