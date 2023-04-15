using MediaLink.Application.Users.Commands.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MediaLink.Infrastructure.Identity;
public class CustomUserManager : UserManager<ApplicationUser>
{
    private readonly ISender _mediator;
    public CustomUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger,
        ISender mediator)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _mediator = mediator;
    }

    public override async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        // Add your custom logic here
        CreateUserCommand command = new CreateUserCommand();

        command.Email = user.UserName;
        command.Password = password;

        var InnerMyUser = await _mediator.Send(command);

        user.User = InnerMyUser;
        
        // Call the base CreateAsync method to create the user
        var result = await base.CreateAsync(user, password);

        return result;
    }
}
