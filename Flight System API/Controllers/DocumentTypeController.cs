using Flight_System_API.Repository.DocumentTypeRepository;
using FlightSystemAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flight_System_API.Controllers
{

    [ApiController]
    [Route("api/documenttype")]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository,
           UserManager<IdentityUser> userManager)
        {
            _documentTypeRepository = documentTypeRepository;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<DocumentType> documentTypes = _documentTypeRepository.GetAll();
            return Ok(documentTypes);
        }
        [HttpGet("{id}")]
        public IActionResult GetDocumentTypeById(int id)
        {
            DocumentType documentType = _documentTypeRepository.GetById(id);
            if (documentType != null)
            {
                return Ok(documentType);
            }
            return NotFound($"Không tìm thấy Id {id}");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentType documentType)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                documentType.Creator = currentUser.UserName;
            }
            bool created = _documentTypeRepository.CreateDocumentType(documentType);
            if (created)
            {
                return Ok(new { Message = "Tạo thành công", DocumentType = documentType });
            }
            return BadRequest("Tạo thất bại");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DocumentType documentType)
        {

            bool updated = _documentTypeRepository.UpdateDocumentType(documentType);
            if (updated)
            {
                return Ok(new { Message = "Cập nhật thành công", DocumentType = documentType });
            }
            return BadRequest($"Cập nhật ID {id} thất bại");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool deleted = _documentTypeRepository.DeleteDocumentType(id);
            if (deleted)
            {
                return Ok($"Xóa ID {id} thành công");
            }
            return BadRequest($"Xóa ID {id} thất bại");
        }
    }
}
