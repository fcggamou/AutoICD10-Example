using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AutoICD10_Example.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string Output { get; set; }

        [BindProperty]
        public string ClinicalText { get; set; } = "Acute kidney injury on chronic kidney disease. Anemia. Chronic renal failure. No evidence of cardiovascular disease or liver dysfunction was found. Patient presents with uncontrolled hypertension, hyperlipidemia, and obesity. Blood tests indicate impaired glucose tolerance. Family history includes a high incidence of coronary artery disease and type 2 diabetes. Physical exam reveals peripheral edema and mild shortness of breath upon exertion.";
        private readonly AutoIcdSettings _autoIcdSettings;
        public IndexModel(ILogger<IndexModel> logger, IOptions<AutoIcdSettings> autoIcdSettings)
        {
            _logger = logger;
            _autoIcdSettings = autoIcdSettings.Value;
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _autoIcdSettings.AuthToken);
            var jsonContent = new { text = ClinicalText };
            var content = new StringContent(JsonSerializer.Serialize(jsonContent), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_autoIcdSettings.BaseApiUrl + "code", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var prettyJson = JsonDocument.Parse(responseContent).RootElement.GetRawText();
                var options = new JsonSerializerOptions { WriteIndented = true };
                Output = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(prettyJson), options);
            }
        }

    }
}