using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using IdentityModel.Client;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Users.Commands.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MediaLink.Infrastructure.Identity;
public class CustomUserManager : UserManager<ApplicationUser>
{
    private readonly ISender _mediator;
    private readonly IApplicationDbContext _context;

    public CustomUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger,
        ISender mediator, IApplicationDbContext context)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _mediator = mediator;
        _context = context;
    }

    public override async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        // Add your custom logic here

        //from me
        CreateUserCommand command = new CreateUserCommand();
        command.Email = user.Email;
        command.UserName = user.UserName;
        command.Password = password;
        command.FirstName = user.FirstName;
        command.LastName = user.LastName;
        user.User = await _mediator.Send(command);
        //from me

        // Call the base CreateAsync method to create the user
        var result = await base.CreateAsync(user, password);

        return result;
    }

    public override Task<IdentityResult> UpdateAsync(ApplicationUser user)
    {
        return base.UpdateAsync(user);
    }
    public override async Task<IdentityResult> DeleteAsync(ApplicationUser user)
    {
/*        var innerUser = await _context.InnerUsers.FirstOrDefaultAsync(x => x.UserName == user.UserName);

        if (innerUser == null)
        {
            throw new DirectoryNotFoundException(nameof(user));
        }

        _context.InnerUsers.Remove(innerUser);

        await _context.SaveChangesAsync(CancellationToken.None);*/

        return await base.DeleteAsync(user);
    }

    public override async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
    {
        var innerUser = await _context.InnerUsers.FirstOrDefaultAsync(x => x.UserName == user.UserName);

        if (innerUser == null)
        {
            throw new DirectoryNotFoundException(nameof(user));
        }

        innerUser!.Password = newPassword;
        _context.InnerUsers.Update(innerUser);

        await _context.SaveChangesAsync(CancellationToken.None);
        return await base.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public override async Task<IdentityResult> ChangeEmailAsync(ApplicationUser user, string newEmail, string token)
    {
        var innerUser = await _context.InnerUsers.FirstOrDefaultAsync(x => x.UserName == user.UserName);
      
        if (innerUser == null)
        {
            throw new DirectoryNotFoundException(nameof(user));
        }

        innerUser!.Email = newEmail;
        _context.InnerUsers.Update(innerUser);

        await _context.SaveChangesAsync(CancellationToken.None);
        return await base.ChangeEmailAsync(user, newEmail, token);
    }
}
