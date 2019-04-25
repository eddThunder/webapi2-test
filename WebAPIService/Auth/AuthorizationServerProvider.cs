

namespace WebAPIService.Auth
{
    using DataAccessLayer.Repositories;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.OAuth;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly UserRepository _userRepository;

        public AuthorizationServerProvider()
        {
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


            //Finding the user
            var user = await _userRepository.GetByCredentials(userName, password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var ticketPropierties = new Dictionary<string, string>();
                var roleClaims = new List<Claim>();

                identity.AddClaim(new Claim("Id", user.Id.ToString()));
                identity.AddClaim(new Claim("UserName", user.Username));

                var ticketRoles = new List<string>();

                //Adding the user's roles to claims
                foreach (var role in user.UsersRoles)
                {
                    roleClaims.Add(new Claim(ClaimTypes.Role, role.Roles.RoleName));
                    ticketRoles.Add(role.Roles.RoleName);
                }

                identity.AddClaims(roleClaims);

                identity.AddClaim(new Claim("scope", scope.FirstOrDefault()));
                ticketPropierties.Add("scope", scope.FirstOrDefault().ToString());
                ticketPropierties.Add("roles", Newtonsoft.Json.JsonConvert.SerializeObject(ticketRoles));

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