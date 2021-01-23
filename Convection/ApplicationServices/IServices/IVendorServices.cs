using Convection.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.ApplicationServices.IServices
{
    public interface IVendorServices
    {
        List<TagDto> GetListTagServices();

        List<VendorDto> GetListVendorServices();

        JsonResult InsertNewVendorServices(InsertVendorDto vendor);

        JsonResult DeleteVendorServices(int id);

        JsonResult UpdateVendorServicesByPut(UpdateVendorDto dto, int id) ;
        JsonResult UpdateVendorServices(JsonPatchDocument<UpdateVendorDto> vendorDto, int id);
        VendorDto GetVendorByIdervices(int id);

    }
}
