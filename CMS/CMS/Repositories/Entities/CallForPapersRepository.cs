using CMS.Exceptions;
using CMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System;

namespace CMS.Repositories.Entities
{
	public class CallForPapersRepository : IEntityRepository<CallForPapers>
	{
		public CallForPapers Add(CallForPapers entity)
		{
			try
			{
				using (DatabaseContext context = new DatabaseContext())
				{
					var result = context.CallsForPapers.SingleOrDefault(c => c.Id == entity.Id);
					if (result == null)
					{
						context.CallsForPapers.Add(entity);
						context.SaveChanges();
					}
				}
			}
			catch
			{
				throw new DatabaseException("Cannot connect to Database!\n");
			}
			return entity;
		}

		public CallForPapers Delete(CallForPapers entity)
		{
			try
			{
				using (DatabaseContext context = new DatabaseContext())
				{
					var result = context.CallsForPapers.SingleOrDefault(c => c.Id == entity.Id);
					if (result != null)
					{
						context.CallsForPapers.Remove(entity);
						context.SaveChanges();
					}
				}
			}
			catch
			{
				throw new DatabaseException("Cannot connect to Database!\n");
			}
			return entity;
		}

		public IList<CallForPapers> FindAll()
		{
			IList<CallForPapers> callforpapers = new List<CallForPapers>();
			try
			{
				using (var context = new DatabaseContext())
				{
					callforpapers = context.CallsForPapers.ToList();
				}
			}
			catch (System.Exception)
			{
				throw new DatabaseException("Cannot connect to Database!\n");
			}

			return callforpapers;
		}

		public CallForPapers Update(CallForPapers entity)
		{
			try
			{
				using (DatabaseContext context = new DatabaseContext())
				{
					var result = context.CallsForPapers.SingleOrDefault(c => c.Id == entity.Id);
					if (result != null)
					{
						result.Acronym = entity.Acronym;
						result.DeadlineAbstract = entity.DeadlineAbstract;
						result.DeadlineProposal = entity.DeadlineProposal;
						result.Name = entity.Name;
						result.StartDate = entity.StartDate;
						result.Topics = entity.Topics;
						context.SaveChanges();
					}
				}
			}
			catch (System.Exception)
			{
				throw new DatabaseException("Cannot connect to Database!\n");
			}

			return entity;
		}
	}
}