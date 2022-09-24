using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CRUDModel crModel = new CRUDModel();
            crModel.GetStudentByID(1);
            crModel.UpdateStudent(1, "cd", "ef", 10);
        }
    }
}