using Common.Structures.HttpBasicAuthentication;
using DevOps.VersionControl.Structures.GitCommitUser;
using System;
using System.Threading.Tasks;
using static DevOps.VersionControl.Functions.CreateGitHubRepository.GitHubRepositoryCreator;
using static DevOps.VersionControl.Functions.InitializeDotNetGnuGitRepository.GitRepositoryInitializer;
using static Metaproject.Users.CDorst.GitHubAccessToken.GitHubCredentials;

namespace DevOps.VersionControl.Functions.CreateAndInitDotNetGitHubRepository
{
    public static class RepositoryCreator
    {
        private const string RemoteRoot = "https://github.com/";

        public static async Task CreateRepository(string directory, string name, string description, BasicAuthenticationCredentials? credentials = null, UserInfo? user = null)
        {
            credentials = credentials ?? CDorst;
            await Create(name, description, credentials);
            InitializeRepository(directory, GetRemote(credentials.Value.User, name), user);
        }

        private static Uri GetRemote(string user, string name)
            => new Uri($"{RemoteRoot}{user}/{name}.git");
    }
}
