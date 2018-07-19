using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBooks.Dtos;

namespace MPACore.PhoneBook.PhoneBooks
{
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);

        /// <summary>
        /// 根据id获取相关信息
        /// </summary>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync();

        /// <summary>
        /// 新增或更改联系人信息
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdatePersonAsync();

        Task DeletePersonAsync(EntityDto input);
    }
}
