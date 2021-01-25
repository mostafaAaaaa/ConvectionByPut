using Convection.ApplicationServices.IServices;
using Convection.DTOs;
using Convection.Inferastructure.IRepositores;
using Convection.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Convection.ApplicationServices.Services
{
    public class VendorServices : IVendorServices
    {
        private readonly IVendorRepository _vendorRepository;


        public VendorServices(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public bool DeleteVendorServices(int id)
        {
            int deleteResult = _vendorRepository.DeleteVendorRepository(id);

            if (deleteResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



       

        public List<VendorDto> GetListVendorServices()
        {
            var listVendor = _vendorRepository.GetListVendorRepository();
            var listTag = _vendorRepository.GetListTagRepository();

         
            var listTagDtos = listTag.Select(x => new TagDto
            {               
                Name = x.Name
            }).ToList();

            
            var listVendorDto = listVendor.Select(x => new VendorDto
            {
              
                Adress = x.Adress,
                Email = x.Email,
                Gender = x.Gender,
                PhoneNumber = x.PhoneNumber,
                Title = x.Title,
                VendorName = x.VendorName,
                Date = x.Date,
                tagDtos = listTagDtos


            }).ToList();





            return listVendorDto;
        }

        public VendorDto GetVendorByIdervices(int id)
        {
            var vendor = _vendorRepository.GetVendorByIdRepository(id);

            var listTag = _vendorRepository.GetTagByIdRepository(id);

            var listTagDto = listTag.Select(x => new TagDto
            {
                Name = x.Name
            }).ToList();


            VendorDto vendorDto = new VendorDto()
            {
                Adress = vendor.Adress,
                Date = vendor.Date,
                Email = vendor.Email,
                Gender = vendor.Gender,
                PhoneNumber = vendor.PhoneNumber,
                Title = vendor.Title,
                VendorName = vendor.VendorName,
                tagDtos = listTagDto
            };
            return vendorDto;
        }

        public ResponseInsertVendorDto InsertNewVendorServices(InsertVendorDto vendor)
        {
            List<Tag> listTag = new List<Tag>();

            
            for (int i = 0; i < vendor.InseragDtos.Count; i++)
            {
                Tag tag = new Tag();
                tag.Name = vendor.InseragDtos[i].Name;
                listTag.Add(tag);
            }
          

            Vendor VendorForInsert = new Vendor();
            VendorForInsert.Adress = vendor.Adress;
            VendorForInsert.Email = vendor.Email;
            VendorForInsert.Date = vendor.Date;
            VendorForInsert.Gender = vendor.Gender;
            VendorForInsert.Title = vendor.Title;
            VendorForInsert.PhoneNumber = vendor.PhoneNumber;
            VendorForInsert.VendorName = vendor.VendorName;
            VendorForInsert.Tags = listTag;

          
            var result = _vendorRepository.InsertVendorRepository(VendorForInsert);
            var ResponseDto= new ResponseInsertVendorDto(){
                Adress= result.Adress,
                Date= result.Date,
                Email= result.Email,
                Id= result.Id,
                Gender= result.Gender,
                PhoneNumber= result.PhoneNumber,
                Title= result.Title,
                VendorName=result.VendorName,
                 InseragDtos= result.Tags.Select(t => new InsertTagDto
                 {
                     Name = t.Name
                 }).ToList()

            };

            if (ResponseDto != null)
            {            
                return ResponseDto;
            }
            else
            {              
                return null;
            }
        }



        public bool UpdateVendorServices(UpdateVendorDto updateVendorDto, int id)
        {


            Vendor vendorUpdate = new Vendor();
            vendorUpdate.Id = id;
            vendorUpdate.Adress = updateVendorDto.Adress;
            vendorUpdate.Date = updateVendorDto.Date;
            vendorUpdate.Email = updateVendorDto.Email;
            vendorUpdate.Gender = updateVendorDto.Gender;
            vendorUpdate.PhoneNumber = updateVendorDto.PhoneNumber;
            vendorUpdate.VendorName = updateVendorDto.VendorName;
            vendorUpdate.Title = updateVendorDto.Title;


            int result = _vendorRepository.UpdateVendorRepository(vendorUpdate);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateVendorServicesByPut(UpdateVendorDto dto, int id)
        {

            var tags = _vendorRepository.GetTagByIdRepository(id);
            for (int i = 0; i < tags.Count; i++)
            {
                _vendorRepository.DeleteListTagsRepository(tags[i]);
            }


            List<Tag> listTag = new List<Tag>();
            for (int i = 0; i < dto.InseragDtos.Count; i++)
            {
                Tag tag = new Tag();
                tag.Name = dto.InseragDtos[i].Name;
                listTag.Add(tag);
            }
       
           
            Vendor VendorForUpdate = new Vendor();
            VendorForUpdate.Id = id;
            VendorForUpdate.Adress = dto.Adress;
            VendorForUpdate.Email = dto.Email;
            VendorForUpdate.Date = dto.Date;
            VendorForUpdate.Gender = dto.Gender;
            VendorForUpdate.Title = dto.Title;
            VendorForUpdate.PhoneNumber = dto.PhoneNumber;
            VendorForUpdate.VendorName = dto.VendorName;
            VendorForUpdate.Tags = listTag;

            int result = _vendorRepository.UpdateVendorRepository(VendorForUpdate);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
    }

}
