using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid Id)
        {
            var walkDomainModel = await GetByIdAsync(Id);
            if (walkDomainModel == null)
            {
                return null;
            }
            dbContext.Walks.Remove(walkDomainModel);
            dbContext.SaveChanges();
            return walkDomainModel;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;
            
            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            // return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid Id)
        {
            var walkDomainModel = await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == Id);

            return walkDomainModel;
        }

        public async Task<Walk?> UpdateAsync(Guid Id, Walk walk)
        {
            var walkDomainModel = await dbContext.Walks.FirstOrDefaultAsync(walk => walk.Id == Id);
            if (walkDomainModel == null)
            {
                return null;
            }
            walkDomainModel.Name = walk.Name;
            walkDomainModel.Description = walk.Description;
            walkDomainModel.LengthInKm = walk.LengthInKm;
            walkDomainModel.RegionId = walk.RegionId;
            walkDomainModel.WalkImageUrl = walk.WalkImageUrl;
            walk.DifficultyId = walk.DifficultyId;

            await dbContext.SaveChangesAsync();

            return walkDomainModel;
        }
    }
}
