using InsurHackMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsurHackMobile.Services
{
    public interface IProfessionService
    {
        Task<List<Profession>> GetAllProfessions();
    }
}
