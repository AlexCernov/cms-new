using CMS.Models;
using CMS.Repositories;
using CMS.Repositories.Entities;
using System;
using System.Collections.Generic;

namespace CMS.Services.Entities
{
    public class ComiteeService : IEntityService<Comitee>
    {
        private readonly IEntityRepository<Comitee> comiteeRepository;

        public ComiteeService(ComiteeRepository comiteeRepository)
        {
            this.comiteeRepository = comiteeRepository;
        }

        public Comitee Add(Comitee entity)
        {
            return comiteeRepository.Add(entity);
        }

        public IList<Comitee> FindAll()
        {
            return comiteeRepository.FindAll();
        }

        public Comitee Delete(Comitee entity)
        {
            return comiteeRepository.Delete(entity);
        }

        public Comitee Update(Comitee entity)
        {
            return comiteeRepository.Update(entity);
        }

    }
}