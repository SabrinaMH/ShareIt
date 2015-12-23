using ShareIt.DiscussionCtx.Domain;
using ShareIt.EventStore;
using ShareIt.UserCtx.Domain;

namespace ShareIt.UserCtx.Commands
{
    public class UserCommandHandler
    {
        private readonly EventStoreRepository<User> _repository;

        public UserCommandHandler(EventStoreRepository<User> repository)
        {
            _repository = repository;
        }

        public void Handle(RegisterUser registerUser)
        {
            var user = _repository.GetById(registerUser.Email);
            if (user != null)
            {
                throw new EmailAlreadyRegisteredException(registerUser.Email);
            }
            var name = new Name(registerUser.Name);
            var emailAddress = new EmailAddress(registerUser.Email);
            user = new User(name, emailAddress);
            _repository.Save(user);
        }
    }
}