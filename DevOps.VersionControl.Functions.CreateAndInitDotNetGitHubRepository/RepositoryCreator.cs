using Common.Structures.HttpBasicAuthentication;
using DevOps.VersionControl.Structures.GitCommitUser;
using System.Threading.Tasks;
using static DevOps.VersionControl.Functions.CreateGitHubRepository.GitHubRepositoryCreator;
using static DevOps.VersionControl.Functions.GetGitHubRepoRemoteUri.RemoteUriGetter;
using static DevOps.VersionControl.Functions.InitializeDotNetGnuGitRepository.GitRepositoryInitializer;

namespace DevOps.VersionControl.Functions.CreateAndInitDotNetGitHubRepository
{
    public static class RepositoryCreator
    {
        public static async Task CreateRepository(string directory, string name, string description, BasicAuthenticationCredentials? credentials = null, UserInfo? user = null)
        {
            await Create(name, description, credentials);
            InitializeRepository(directory, RemoteUri(name, credentials), user);
        }
    }
}
