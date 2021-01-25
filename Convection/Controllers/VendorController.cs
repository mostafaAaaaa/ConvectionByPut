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
        public IActionResult GetAllVendors([FromRoute] int id)
        {
            var result = _IVendorServices.GetVendorByIdervices(id);
            if (result!= null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }


        }
        [HttpPost]
        public IActionResult AddVendor(InsertVendorDto dto)
        {
            var VendorResponseDto = _IVendorServices.InsertNewVendorServices(dto);
            return Created(new Uri($"api/Vendor/{VendorResponseDto.Id}", UriKind.Relative), VendorResponseDto);

        }


        [HttpPut("{id}")]
        public IActionResult UpdateVendor([FromRoute] int id, UpdateVendorDto dto)
        {
          

                var result = _IVendorServices.UpdateVendorServicesByPut(dto, id);
                if (result)
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

            var result = _IVendorServices.UpdateVendorServices(updateVendorDto, id);
              
                if (result)
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
            var result= _IVendorServices.DeleteVendorServices(id);
            if (result)
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
