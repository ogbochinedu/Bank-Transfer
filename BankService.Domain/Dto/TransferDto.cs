namespace BankService.Domain.Dto
{
    public class TransferDto
    {
        public string? SenderAccountNumber { get; set; }
        public string? ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string? BankCode { get; set; }
        public string? Status { get; set; }
    }
}
