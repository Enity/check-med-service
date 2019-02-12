using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckMed;
using CheckMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CheckController : ControllerBase
    {
        private readonly CheckMedService _med;
        
        public CheckController(CheckMedService med)
        {
            _med = med;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Specialty>> Specs(string url)
        {
            _med.SetUri(url);
            return await _med.GetSpecialtiesAsync();
        }
        
        [HttpGet]
        public async Task<IEnumerable<Doctor>> Doctors(string url, Specialty spec)
        {
            _med.SetUri(url);
            return await _med.GetDoctorsBySpec(spec);
        }
        
        [HttpGet]
        public async Task<IEnumerable<Ticket>> Tickets(string url, Doctor doctor)
        {
            _med.SetUri(url);
            return await _med.GetTicketsByDoc(doctor);
        }
        
        [HttpGet]
        public async Task<IEnumerable<Ticket>> TicketsSpec(string url, Specialty spec)
        {
            _med.SetUri(url);
            return await _med.GetTicketsBySpec(spec);
        }
    }
}