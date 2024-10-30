﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Domain;
namespace PersonAdmin.BusinessLogic
{
    public class PersonService(IPersonDao personDao,TextWriter writer)
    {
        public void TestFindAll()
        {
            writer.WriteLine("TestFindAll");
            personDao.FindAll()
                .ToList()
                .ForEach(p => writer.WriteLine(
                    $"{p.Id,5} | {p.FirstName,-10} | {p.LastName,-15} | {p.DateOfBirth,10:dd.MM.yyyy}"));

            writer.WriteLine();
        }
        public void TestFindById()
        {
            Person? person1 = personDao.FindById(1);
            writer.WriteLine($"FindById(1): {person1?.ToString() ?? "<null>"}");

            Person? person2 = personDao.FindById(10);
            writer.WriteLine($"FindById(10): {person2?.ToString() ?? "<null>"}");

            writer.WriteLine();
        }
    }
}
