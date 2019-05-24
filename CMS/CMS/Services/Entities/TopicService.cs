using CMS.Models;
using CMS.Repositories;
using CMS.Repositories.Entities;
using System;
using System.Collections.Generic;

namespace CMS.Services.Entities
{
	public class TopicService : IEntityService<Topic>
	{
		private readonly IEntityRepository<Topic> topicRepository;

		public TopicService(TopicRepository topicRepository)
		{
			this.topicRepository = topicRepository;
		}

        public Topic Add(Topic entity)
		{
			return this.topicRepository.Add(entity);
		}

		public IList<Topic> FindAll()
		{
			return this.topicRepository.FindAll();
		}

		public Topic Delete(Topic entity)
		{
			return this.topicRepository.Delete(entity);
		}

		public Topic Update(Topic entity)
		{
			return this.topicRepository.Update(entity);
		}
	}
}