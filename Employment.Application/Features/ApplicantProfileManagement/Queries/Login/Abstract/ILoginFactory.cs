namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract
{
    internal interface ILoginFactory
    {
        BaseLogin Login(LoginType loginType);
    }
}
