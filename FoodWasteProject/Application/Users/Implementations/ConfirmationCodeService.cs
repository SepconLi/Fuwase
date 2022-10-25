using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Repositories;
using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public class ConfirmationCodeService : IConfirmationCodeService
    {
        private readonly IConfirmationCodeRepository _confirmationCodeRepository;
        public ConfirmationCodeService(IConfirmationCodeRepository confirmationCodeRepository)
        {
            _confirmationCodeRepository = confirmationCodeRepository;
        }
        /// <summary>
        /// Service to get a code by its email
        /// </summary>
        /// <param name="email"></param>
        public async Task AddConfirmationCode(ConfirmationCode code)
        {
            await _confirmationCodeRepository.SaveCodeAsync(code);
        }
        /// <summary>
        /// Service to delete a code for a certain email
        /// </summary>
        /// <param name="email"></param>
        public async Task DeleteCodeForEmail(string email)
        {
            await _confirmationCodeRepository.DeleteCodeForEmail(email);
        }
        /// <summary>
        /// Service to get a code by its email
        /// </summary>
        /// <param name="email"></param>
        public async Task<ConfirmationCode?> GetCodeByEmail(string email)
        {
            return await _confirmationCodeRepository.GetCodeByEmail(email);
        }
    }
}
