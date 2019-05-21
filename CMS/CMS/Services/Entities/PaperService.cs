using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Services.Entities
{
    public class PaperService : IEntityService<Paper>
    {

        private readonly IEntityRepository<Paper> entityRepository;

        public PaperService(IEntityRepository<Paper> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public Paper Add(Paper entity)
        {
            return this.entityRepository.Add(entity);
        }

        public Paper Delete(Paper entity)
        {
            return this.entityRepository.Delete(entity);
        }

        public IList<Paper> FindAll()
        {
            return this.entityRepository.FindAll();
        }

        public Paper Update(Paper enitity)
        {
            return this.entityRepository.Update(enitity);
        }
    }
}