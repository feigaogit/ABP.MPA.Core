using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MPACore.PhoneBook.PhoneBooks.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;

namespace MPACore.PhoneBook.PhoneBooks
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public Task CreateOrUpdatePersonAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonAsync(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PersonListDto> GetPersonByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
