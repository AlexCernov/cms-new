using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;

namespace CMS.Services.Entities
{
	public class CallForPaperService : IEntityService<CallForPapers>
	{
		private readonly IEntityRepository<CallForPapers> callForPapersRepository;

		public CallForPaperService(IEntityRepository<CallForPapers> callForPapersRepository)
		{
			this.callForPapersRepository = callForPapersRepository;
		}

		public CallForPapers Add(CallForPapers entity)
		{
			return this.callForPapersRepository.Add(entity);
		}

		public IList<CallForPapers> FindAll()
		{
			return this.callForPapersRepository.FindAll();
		}

		public CallForPapers Delete(CallForPapers entity)
		{
			return this.callForPapersRepository.Delete(entity);
		}

		public CallForPapers Update(CallForPapers entity)
		{
			return this.callForPapersRepository.Update(entity);
		}
	}
}