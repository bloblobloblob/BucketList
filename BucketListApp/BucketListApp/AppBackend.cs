using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;

namespace BucketListApp
{
    public partial class App : Application
    {
        private static ProfilesDatabase database;

        public (int InProgress, int Completed) Statistics
        {
            get
            {
                return (CurrentProfile.Goals.InProgress(), CurrentProfile.Goals.Completed());
            } 
        }
        public static ProfilesDatabase Database
        {
            get
            {
                if (Database == null)
                {
                    database = new
                    ProfilesDatabase(Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "profiles.db3"));
                }
                return database;
            }
        }
        private Profile DefaultProfile
        { 
            get 
            {
                if (DefaultProfile == null)
                    return new Profile()
                    { Name = String.Empty, Login = null, Password = null, Goals = new GoalList() };
                return DefaultProfile;
            } 
            set { } 
        }
        private Profile CurrentProfile
        {
            get
            {
                if (CurrentProfile == null)
                    CurrentProfile = DefaultProfile;
                return CurrentProfile;
            }
            set { }
        }

        public async void LoginAccount(string login, string password)
        {
            var account = await Database.GetProfileByLoginAsync(login);
            if (account != null)
            {
                if (account.Password == password)
                    SetProfile(account);
            }
        }

        public void LogoutAccount()
        {
            CurrentProfile = DefaultProfile;
        }

        public async void RegisterAccount(string login, string password)
        {
            if (!Database.Contains(login))
            {
                var accountNumber = await Database.Count;
                await Database.AddProfileAsync(new Profile()
                {
                    Name = "Пользователь" + accountNumber.ToString(),
                    Login = login,
                    Password = password,
                    Goals = new GoalList(DefaultProfile.Goals.GetGoals())
                });
            }
        }

        public void DeleteAccount()
        {
            Database.DeleteProfileAsync(CurrentProfile);
            CurrentProfile = DefaultProfile;
        }

        public void ChangePassword(string newPassword, string Confirmation)
        {
            if (IsAuthorized() && newPassword == Confirmation)
                CurrentProfile.Password = newPassword;
        }

        public void ChangeName(string name)
        {
            if (IsAuthorized())
                CurrentProfile.Name = name;
        }

        private void SetProfile(Profile profile)
        {
             CurrentProfile = profile;    
        }

        private bool IsAuthorized()
        {
            return CurrentProfile.Login != null;
        }
    }
}
