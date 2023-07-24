using DevFreela.Core.DTOs;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPaymentAsync(PaymentInfoDTO paymentInfoDTO);
    }
}
