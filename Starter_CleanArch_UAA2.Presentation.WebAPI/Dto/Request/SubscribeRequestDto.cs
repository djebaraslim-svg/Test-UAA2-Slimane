namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request
{
    public class SubscribeRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public bool Nouveautes { get; set; }
        public bool RecapitulatifMois { get; set; }
        public bool FaitDuJour { get; set; }
    }
}
