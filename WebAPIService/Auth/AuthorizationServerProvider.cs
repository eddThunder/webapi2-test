

namespace WebAPIService.Auth
{
    using DataAccessLayer.DataModel;
    using DataAccessLayer.Repositories;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.OAuth;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //private readonly IUserBusiness _userBusinessService;
        private readonly UserRepository _userRepository;

        public AuthorizationServerProvider()
        {
            // _userBusinessService = userBusinessService;
            _userRepository = new UserRepository();
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            string userName = context.UserName;
            string password = context.Password;
            var scope = context.Scope;


            //Buscar usuario...
            var user = await _userRepository.GetByCredentials(userName, password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var ticketPropierties = new Dictionary<string, string>();
                var roleClaims = new List<Claim>();

                identity.AddClaim(new Claim("Id", user.Id.ToString()));
                identity.AddClaim(new Claim("UserName", user.Username));


                foreach (var role in user.UsersRoles)
                {
                    roleClaims.Add(new Claim("RoleName", role.Roles.RoleName));
                }

                identity.AddClaims(roleClaims);

                identity.AddClaim(new Claim("scope", scope.FirstOrDefault()));
                ticketPropierties.Add("scope", scope.FirstOrDefault().ToString());

                var ticket = new AuthenticationTicket(identity, new AuthenticationProperties(ticketPropierties));
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                context.Rejected();
            }
        }

       
    }
}