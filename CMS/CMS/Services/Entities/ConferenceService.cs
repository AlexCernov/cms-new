using CMS.Models;
using CMS.Repositories;
using CMS.Repositories.Entities;
using System;
using System.Collections.Generic;

namespace CMS.Services.Entities
{
    public class ConferenceService : IEntityService<Conference>
    {
        private readonly IEntityRepository<Conference> conferenceRepository;

		public ConferenceService(ConferenceRepository conferenceRepository)
		{
			this.conferenceRepository = conferenceRepository;
		}

		public Conference Add(Conference entity)
        {
            return conferenceRepository.Add(entity);
        }

        public IList<Conference> FindAll()
        {
            return conferenceRepository.FindAll();
        }

        public Conference Delete(Conference entity)
        {
            return conferenceRepository.Delete(entity);
        }

        public Conference Update(Conference entity)
        {
            return conferenceRepository.Update(entity);
        }
        
    }
}