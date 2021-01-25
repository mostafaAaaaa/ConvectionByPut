using Convection.DTOs;
using Convection.Models;
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
        List<VendorDto> GetListVendorServices();

        ResponseInsertVendorDto InsertNewVendorServices(InsertVendorDto vendor);

        bool DeleteVendorServices(int id);

        bool UpdateVendorServicesByPut(UpdateVendorDto dto, int id) ;
        bool UpdateVendorServices(UpdateVendorDto vendorDto, int id);
        VendorDto GetVendorByIdervices(int id);

    }
}
