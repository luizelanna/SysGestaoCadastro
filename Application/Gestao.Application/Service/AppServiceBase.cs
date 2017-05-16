using Gestao.Application.Interface;
using Gestao.Application.Validation;
using Gestao.Domain.ValueObjects;
using Gestao.Infra.Data.Interfaces;

namespace Gestao.Application.Service
{
    public class AppServiceBase : IAppServiceBase
    {
        private IUnitOfWork _uow;
        public AppServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }

        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}
