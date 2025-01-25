using Newtonsoft.Json;
using QRCoder;
using TicketPurchaseAPI.Model;

namespace TicketPurchaseAPI.Services
{
    public class QRGeneratorService : IQRGeneratorService
    {
        private readonly IConfiguration _config;
        public QRGeneratorService(IConfiguration config)
        {
            _config = config;  
        }
        public async Task<byte[]> GenerateImage(Ticket ticketData)
        {
            string baseUrl = _config["BaseUrl"];

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"{baseUrl}/api/Ticket/qrcode/validate?id={ticketData.Id}", QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            byte[] qrCodeImage = qrCode.GetGraphic(20);

        
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "QRCodes");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, $"Ticket_{ticketData.Id}.png");

             await File.WriteAllBytesAsync(filePath, qrCodeImage);

            return qrCodeImage;
        }



    }
}
