using CMS.Exceptions;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Repositories.Entities
{
    public class ConferenceRepository : IEntityRepository<Conference>
    {
        public Conference Add(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
            
        }

        public Conference Delete(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<Conference> FindAll()
        {
            IList<Conference> conferences = new List<Conference>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    conferences = context.Conferences.ToList();
                
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }
            return conferences;
        }

        public IList<Conference> FindAllConferencesOrganizedByACommittee(int committeeID)
        {
            IList<Conference> conferences = new List<Conference>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    conferences = context.Conferences.Where(t => t.Comitee.Id == committeeID).ToList();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }
            return conferences;
        }

        public IList<Conference> FindAllConferencesWhereAMemberExists(int pcMemberID)
        {
            IList<Conference> conferences = new List<Conference>();
            IList<Comitee> allCommittees = new List<Comitee>();
            IList<Comitee> pcCommittees = new List<Comitee>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    allCommittees = context.Comitees.ToList();
                    foreach (Comitee committee in allCommittees)
                    {
                        IList<PCMember> members = committee.PCMembers.ToList();
                        foreach (PCMember member in members)
                        {
                            if (member.Id == pcMemberID)
                            {
                                pcCommittees.Add(committee);
                            }
                        }
                    }

                    foreach (Comitee comitee in pcCommittees)
                    {
                        IList<Conference> partialResult = this.FindAllConferencesOrganizedByACommittee(comitee.Id);
                        if (partialResult.Count > 0)
                        {
                            conferences.Add(partialResult[0]);
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }
            return conferences;
        }

        public Conference Update(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Remove(entity);
                    context.SaveChanges();
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