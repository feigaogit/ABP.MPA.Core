using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.Persons;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumbers
{
    public class PhoneNumber : Entity<long>, IHasCreationTime
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumber Type { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
