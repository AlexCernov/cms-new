using CMS.Models;
using CMS.Repositories;
using CMS.Repositories.Entities;
using System;
using System.Collections.Generic;

namespace CMS.Services.Entities
{
    public class ConferenceService : IEntityService<Conference>
    {
        private readonly ConferenceRepository conferenceRepository;

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

        public void Delete(Conference entity)
        {
            conferenceRepository.Delete(entity);
        }

        public Conference Update(Conference entity)
        {
            return conferenceRepository.Update(entity);
        }

        public Conference FindById(int? id)
        {
            return conferenceRepository.FindById(id);
        }

    }
}