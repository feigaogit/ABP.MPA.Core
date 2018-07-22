using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;

namespace MPACore.PhoneBook.PhoneBooks
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {
            if (input.PersonEditDto.Id.HasValue)
            {
                await UpdatePersonAysnc(input.PersonEditDto);
            }
            else
            {
                await CreatePersonAysnc(input.PersonEditDto);
            }
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var entity = _personRepository.GetAsync(input.Id);

            if (entity == null)
            {
                throw new UserFriendlyException("联系人不存在或已删除");
            }

            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            var query = _personRepository.GetAll();
            var personCount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = persons.MapTo<List<PersonListDto>>();
            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            var person = await _personRepository.GetAsync(input.Id.Value);
            return person.MapTo<PersonListDto>();
        }

        protected async Task UpdatePersonAysnc(PersonEditDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);

            await _personRepository.UpdateAsync(input.MapTo(entity));
        }

        protected async Task CreatePersonAysnc(PersonEditDto input)
        {
            await _personRepository.InsertAsync(input.MapTo<Person>());
        }
    }
}
