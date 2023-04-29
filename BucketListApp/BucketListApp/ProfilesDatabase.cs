using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BucketListApp
{
    public class ProfilesDatabase
    {
        private readonly SQLiteAsyncConnection database;
        
        public Task<int> Count => database.Table<Profile>().CountAsync();
        public ProfilesDatabase(string databasaPath)
        {
            database = new SQLiteAsyncConnection(databasaPath);
            database.CreateTableAsync<Profile>();   
        }

        public Task<List<Profile>> GetProfilesAsync()
        {
            return database
                .Table<Profile>()
                .ToListAsync();
        }

        public Task<Profile> GetProfileByLoginAsync(string login)
        {
            return database
                .Table<Profile>()
                .FirstOrDefaultAsync(profile => profile.Login == login);
        }

        public Task<Profile> GetProfileAsync(Profile profile)
        {
            return database.FindAsync<Profile>(profile);
        }

        public Task<int> AddProfileAsync(Profile profile)
        {
            return database.InsertAsync(profile);
        }

        public Task<int> DeleteProfileAsync(Profile profile)
        {
            return database.DeleteAsync(profile);
        }

        public bool Contains(string login)
        {
            return database.Table<Profile>().FirstOrDefaultAsync(profile => profile.Login == login) != null;
        }
    }
}
